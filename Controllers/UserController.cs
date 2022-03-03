using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Expension.Database.Dto.User;
using Expension.Services.User;
using Microsoft.AspNetCore.Authorization;

namespace Expension.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public ActionResult<List<UserFullDataDto>> GetAll()
        {
            return _userService.GetUsers();
        }

        // POST api/users/register
        [HttpPost("register")]
        public ActionResult Register([FromBody] UserInputDataDto user)
        {
        return _userService.AddUser(user)
            ? (ActionResult) NoContent()
            : BadRequest(new {message = "This mail already exists in the database"});
        }

        // POST api/users/login
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserInputDataDto user)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var _user = _userService.GetUserByEmail(user.Email);

            if (_user == null)
            {
                return BadRequest(new { message = "No such mail in database" });
            }

            var userTokenData = _userService.Authenticate(user.Password, _user);

            if (userTokenData == null)
            {
                return BadRequest(new { message = "Password is incorrect" });
            }

            return Ok(userTokenData);
        }

        // DELETE api/users/{id}
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            return _userService.DeleteUser(id)
                ? (ActionResult) NoContent()
                : BadRequest(new {message = "There is no user with such id"});
        }
    }
}
