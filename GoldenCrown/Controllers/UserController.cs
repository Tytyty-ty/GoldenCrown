using GoldenCrown.DTOs;
using GoldenCrown.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GoldenCrown.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _userService.RegisterAsync(request);

            if (result.IsSuccess)
            {
                return Ok(new { Message = "User registred successfully" });
            }

            return result.ErrorCode switch { 
                ErrorCodes.Conflict => Conflict(new { Message = result.ErrorMessage }),
                _ => BadRequest(new { Message = result.ErrorMessage })
            };
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.LoginAsync(request);

            if (result)
            {
                return Ok(new {Token = result.Value});
            }

            return result.ErrorCode switch
            {
                ErrorCodes.NotFound => NotFound(new { Message = result.ErrorMessage }),
                ErrorCodes.Unauthorized => Unauthorized(new { Message = result.ErrorMessage }),
                _ => BadRequest(new { Message = result.ErrorMessage })
            };
        }


    }
}
