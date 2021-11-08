using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using to_do_listServer.Models;
using to_do_listServer.Services.Interfaces;

namespace to_do_listServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _repository;

        public PostController(IPostService repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")]
        public  ActionResult<List<Post>> GetAll()
        {
            return _repository.GetAll();
        }


        [HttpGet("getById/{id:guid}")]
        public  IActionResult Get(Guid id)
        {
            var tModel = _repository.GetById(id);
            if (tModel is null)
                return NotFound();

            return Ok(tModel);
        }
        
        [HttpGet("getAllByAuthorId/{authorId:guid}")]
        public  ActionResult<List<Post>> GetByAuthorId(Guid authorId)
        {
            var tModel = _repository.GetAllByAuthorId(authorId);
            if (tModel is null)
                return NotFound();

            return Ok(tModel);
        }

        [HttpPost("add")]
        public  IActionResult Create(Post tModel)
        {
            var model = _repository.Create(tModel);
            return CreatedAtAction(nameof(Create), new {id = model.Id}, model);
        }

        [HttpPut("update/{id:guid}")]
        public  IActionResult Update(Guid id, Post tModel)
        {
            if (id != tModel.Id)
                return BadRequest();

            var existing = _repository.GetById(id);
            if (existing is null)
                return NotFound();

            _repository.Update(tModel);

            return NoContent();
        }

        [HttpDelete("delete/{id:guid}")]
        public  IActionResult Delete(Guid id)
        {
            var tModel = _repository.GetById(id);

            if (tModel is null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}