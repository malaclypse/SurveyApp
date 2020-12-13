namespace SurveyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SurveyApp.Services.Abstract;
    using SurveyApp.Services.Dtos;
    using System.Threading.Tasks;

    [Route("api/user")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<User> Post([FromBody] CreateUserRequest userRequest)
        {
            User response = null;
            if (userRequest != null)
            {
                response = await _userService.InsertAsync(userRequest);
            }
            return response;
        }

        [HttpPut("{email}/")]
        public async Task<User> Put([FromRoute] string email, [FromBody] UpdateUserRequest userRequest)
        {
            User response = null;
            if (userRequest != null)
            {
                response = await _userService.UpdateAsync(email, userRequest);
            }
            return response;
        }

        [HttpGet("{email}/")]
        public async Task<User> Get([FromRoute] string email)
        {
            return await _userService.GetAsync(email);
        }
    }
}
