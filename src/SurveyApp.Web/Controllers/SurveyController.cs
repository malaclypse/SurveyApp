namespace SurveyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SurveyApp.Services.Abstract;
    using SurveyApp.Services.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/user/{userEmail}/survey")]
    [Produces("application/json")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly IUserService _userService;
        public SurveyController(ISurveyService surveyService, IUserService userService)
        {
            _surveyService = surveyService;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Survey>> Post([FromRoute] string userEmail)
        {
            var user = await _userService.GetAsync(userEmail);
            if (user == null)
            {
                return NotFound(user);
            }

            var survey = await _surveyService.InsertAsync(userEmail);

            return new ObjectResult(survey) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Survey>>> Get([FromRoute] string userEmail)
        {
            var user = await _userService.GetAsync(userEmail);
            if (user == null)
            {
                return NotFound(user);
            }

            var surveys = await _surveyService.GetAll(userEmail);
            return new ObjectResult(surveys) { StatusCode = 200 };
        }

        [HttpGet("{surveyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Survey>>> Get([FromRoute] int surveyId)
        {
            var survey = await _surveyService.GetAsync(surveyId);

            if (survey == null)
            {
                return NotFound(survey);
            }

            return new ObjectResult(survey) { StatusCode = 200 };
        }
        [HttpPut ("{surveyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Survey>> Put([FromRoute] string userEmail, [FromRoute] int surveyId, [FromBody] UpdateSurveyRequest updateRequest)
        {
            var user = await _userService.GetAsync(userEmail);
            if (user == null)
            {
                return NotFound(user);
            }

            var survey = await _surveyService.GetAsync(surveyId);
            if (survey == null)
            {
                return NotFound(survey);
            }
            survey = await _surveyService.UpdateAsync(surveyId, updateRequest);
            return new ObjectResult(survey) { StatusCode = 200 };
        }
    }

}
