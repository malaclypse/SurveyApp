namespace SurveyApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SurveyApp.Data.Models;
    using SurveyApp.Web.Dtos;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private static readonly List<User> Users = new List<User>();

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<UserEntity>> PostTodoItem(User user)
        {
            Users.Add(user);

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(User), new { email = user.Email }, user);
        }
    }
}
