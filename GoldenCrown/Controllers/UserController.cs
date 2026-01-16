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
        public async Task<IActionResult> Post([FromBody] RegisterRequest request)
        {
            var result = await _userService.RegisterAsync(request);

            if (result)
            {
                return Ok(new { Message = "User registred successfully" });
            }

            return BadRequest(new { Message = "User registration failed" });
        }

        [HttpGet("")]
    }
}
