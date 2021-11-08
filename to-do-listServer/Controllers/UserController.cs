using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using to_do_listServer.Config;
using to_do_listServer.Services;
using to_do_listServer.ViewModels;

namespace to_do_listServer.Controllers
{
    [Config.Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            var user = _userService.Register(model);
            return Ok(user);
        }
        
        [HttpPost("subscribe")]
        public IActionResult Subscribe(SubscribeRequest model)
        {
             _userService.Subscribe(model);
            return Ok();
        }
        
        [HttpPost("unsubscribe")]
        public IActionResult Unsubscribe(SubscribeRequest model)
        {
            _userService.Unsubscribe(model);
            return Ok();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        
        // [AllowAnonymous]
        [HttpGet("getById/{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            user.Password = null;
            return Ok(user);
        }
        
        [AllowAnonymous]
        [HttpGet("getAuthorById/{id:guid}")]
        public IActionResult GetAuthorById(Guid id)
        {
            var user = _userService.GetAuthorById(id);
            user.Password = null;
            return Ok(user);
        }
        
        [AllowAnonymous]
        [HttpPut("update/{id:guid}")]
        public IActionResult Update(Guid id, UpdateRequest model)
        {
            var user = _userService.Update(id, model);
            return Ok(user);
        }
        
     
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}