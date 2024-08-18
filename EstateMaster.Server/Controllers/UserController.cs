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

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                name = addUserRequest.name,
                surnname = addUserRequest.surnname,
                phone = addUserRequest.phone,
                state = addUserRequest.state
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }
    }
}
