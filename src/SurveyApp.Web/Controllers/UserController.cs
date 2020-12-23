namespace SurveyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
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

        public async Task<ActionResult<User>> Post([FromBody] CreateUserRequest userRequest)
        {
            var user = _userService.GetAsync(userRequest.Email);
            if (user != null)
            {
                return new RedirectResult($"api/user/Get/{userRequest.Email}/");
            }

            var userResponse = await _userService.InsertAsync(userRequest);

            return new ObjectResult(user) { StatusCode = 200 };
        }

        [HttpPut("{email}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> Put([FromRoute] string email, [FromBody] UpdateUserRequest userRequest)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound(user);
            }

            user = await _userService.UpdateAsync(email, userRequest);

            return new ObjectResult(user) { StatusCode = 200 };
        }

        [HttpGet("{email}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> Get([FromRoute] string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound(user);
            }

            return new ObjectResult(user) { StatusCode = 200 };
        }
    }
}
