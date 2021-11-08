using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using to_do_listServer.Models;
using to_do_listServer.Services.Interfaces;
using to_do_listServer.ViewModels;

namespace to_do_listServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private IBaseRepository<Image> Repository { get; }

        private readonly IConfiguration _configuration;
        private readonly IPostService _postRepository;

        public ImageController(IBaseRepository<Image> repository, IPostService postRepository,
            IConfiguration configuration)
        {
            Repository = repository;
            _configuration = configuration;
            _postRepository = postRepository;
        }


        [HttpGet("getPreview/{postId:guid}")]
        public IActionResult GetFirst(Guid postId)
        {
            var image = Repository.GetAll().FirstOrDefault(i => i.ParentId == postId);
            if (image is null)
                return new PhysicalFileResult(Path.Combine(Directory.GetCurrentDirectory(), "Resourses/NoImage/images.png"),
                    $"image/png");
            return new PhysicalFileResult(Path.Combine(Directory.GetCurrentDirectory(), image.ImagePath),
                $"image/{image.ImageType}");
        }

        [HttpGet("getById/{imageId:guid}")]
        public IActionResult Get(Guid imageId)
        {
            var image = Repository.GetById(imageId);
            if (image is null)
                return NotFound();
            return new PhysicalFileResult(Path.Combine(Directory.GetCurrentDirectory(), image.ImagePath),
                $"image/{image.ImageType}");
        }

        [HttpGet("getIds/{postId:guid}")]
        public ActionResult<List<Guid>> GetIds(Guid postId)
        {
            var images = new List<Guid>();
            Repository.GetAll().ForEach(i =>
            {
                if (i.ParentId == postId) images.Add(i.Id);
            });
            return images;
        }

        [HttpPost("add/{postId:guid}"), DisableRequestSizeLimit]
        public async Task<IActionResult> Add([FromForm] FileView file, Guid postId)
        {
            try
            {
                var Image = file.File;
                var relativePath = _configuration["ImageFolder"] + '/' + postId.ToString() + '/';

                if (Image.Length <= 0) return Ok(file.Source);
                var imageType = Path.GetExtension(Image.FileName)[1..];
                var imageName = Guid.NewGuid().ToString();


                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), relativePath));
                relativePath += imageName + '.' + imageType;
                await using (var fs = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), relativePath),
                    FileMode.Create))
                {
                    await Image.CopyToAsync(fs);
                }

                file.Source = relativePath;
                file.Extension = Path.GetExtension(Image.FileName)[1..];
                var image = new Image
                {
                    ImageType = imageType,
                    ImageName = imageName,
                    ImagePath = relativePath,
                    ParentId = postId
                };
                Repository.Create(image);
                return Ok(image);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e}");
            }
        }
    }
}