namespace SurveyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SurveyApp.Services.Abstract;
    using SurveyApp.Services.Dtos;
    using System.Threading.Tasks;

    [Route("api/user/{userEmail}/survey")]
    [Produces("application/json")]
    public class SurveyController: ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly IUserService _userService;
        public SurveyController(ISurveyService surveyService, IUserService userService) 
        {
            _surveyService = surveyService;
            _userService = userService;
        }

        [HttpPost]

        public async Task<ActionResult<Survey>> Post([FromRoute] string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound(user);
            }

            var survey = await _surveyService.InsertAsync(email);

            return new ObjectResult(survey) { StatusCode = 200 };
        }
    }
}
