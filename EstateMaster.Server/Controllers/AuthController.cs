// using EstateMaster.Server.Core.Models;
// using EstateMaster.Server.Models;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Identity.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// [ApiController]
// [Route("api/auth")]
// public class AuthController : ControllerBase
// {
//     //private readonly IUserService _userService;
//     private readonly string _secret;

//     // public AuthController(IUserService userService, IConfiguration configuration)
//     // {
//     //     _userService = userService;
//     //     _secret = configuration.GetValue<string>("JwtSecret");
//     // }

//     [HttpPost("login")]
//     public IActionResult Login([FromBody] userLoginRequest model)
//     {
//         var user = _userService.Authenticate(model.username, model.password);

//         if (user == null)
//             return Unauthorized(new { message = "Username or password is incorrect" });

//         var token = JwtTokenHelper.GenerateToken(user, _secret);
//         return Ok(new { token });
//     }
// }
