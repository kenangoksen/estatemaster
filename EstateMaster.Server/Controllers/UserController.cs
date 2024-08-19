using EstateMaster.Server.Core.Models;
using EstateMaster.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstateMaster.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly EMDBContext _dbContext;

        public UserController(EMDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Hata günlüğüne yaz
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest addUserRequest)
        {
            try
            {
                var user = new User()
                {
                    name = addUserRequest.name,
                    surname = addUserRequest.surname,
                    phone = addUserRequest.phone,
                    state = addUserRequest.state
                };

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Hata günlüğüne yaz
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
