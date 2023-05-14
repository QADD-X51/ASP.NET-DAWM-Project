using Microsoft.AspNetCore.Mvc;
using DAWM_Project.Services;
using DAWM_Project.Services.Dtos;
using DAWM_Project.Data.Entity;
using DAWM_Project.Data;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace DAWM_Project.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : Controller
    {
        private UserService _userService { get; set; }

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("/register")]
        public IActionResult Add(UserAddDto payload)
        {
            _userService.RegisterUser(payload);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("/login")]
        public IActionResult Login(UserLoginDto payload)
        {
            var jwtToken = _userService.Validate(payload);

            return Ok(new { token = jwtToken });
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("/delete")]
        public IActionResult Delete(User user)
        {
            return Ok();
        }

        [HttpGet("test-auth")]
        public IActionResult TestLogin()
        {

            ClaimsPrincipal user = User;

            var result = "";

            foreach (var claim in user.Claims)
            {
                result += claim.Type + " : " + claim.Value + "\n";
            }



            return Ok(result);
        }
    }
}
