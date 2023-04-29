using Microsoft.AspNetCore.Mvc;
using DAWM_Project.Services;
using DAWM_Project.Services.Dtos;
using DAWM_Project.Data.Entity;
using DAWM_Project.Data;
using System.IdentityModel.Tokens.Jwt;

namespace DAWM_Project.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/register")]
        public IActionResult Add(UserAddDto payload)
        {
            var result = _userService.RegisterUser(payload);

            if (result == null)
            {
                return BadRequest("User cannot be added");
            }

            return Ok(result);
        }

        [HttpGet("/login")]
        public IActionResult Login(string username, string password)
        {
            var payload = new UserLoginDto { Username = username, Password = password };
            var result = _userService.LoginUser(payload);

            if (result == null)
            {
                return BadRequest("User does not exist");
            }

            return Ok(result);
        }
    }
}
