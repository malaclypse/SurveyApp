namespace SurveyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SurveyApp.Services.Abstract;
    using SurveyApp.Services.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/user/{userEmail}/survey/{surveyId}/map")]
    [Produces("application/json")]
    public class MappingController : ControllerBase
    {
        private readonly IMappingService _mappingService;

        public MappingController(IMappingService mappingService)
        {
            _mappingService = mappingService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Mapping>>> Get([FromRoute] string userEmail, [FromRoute] int surveyId, [FromQuery] int? textId )
        {
            var mappings = await _mappingService.GetAllMappingsForSurvey(userEmail, surveyId, textId);

            if (mappings == null)
            {
                return NotFound(mappings);
            }

            return new ObjectResult(mappings) { StatusCode = 200 };
        }

        [HttpGet("{mappingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Mapping>> Get([FromRoute] string userEmail, [FromRoute] int surveyId, [FromRoute] int mappingId)
        {
            var mapping = await _mappingService.GetSurveyMappingAsync(userEmail, surveyId, mappingId);

            if (mapping == null)
            {
                return NotFound(mapping);
            }

            return new ObjectResult(mapping) { StatusCode = 200 };
        }

        [HttpDelete("{mappingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Mapping>> Delete([FromRoute] string userEmail, [FromRoute] int surveyId, [FromRoute] int mappingId)
        {
            var mapping = await _mappingService.DeleteSurveyMappingAsync(userEmail, surveyId, mappingId);

            if (mapping == null)
            {
                return NotFound(mapping);
            }

            return new ObjectResult(mapping) { StatusCode = 200 };
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Mapping>> Post([FromRoute] string userEmail, [FromRoute] int surveyId, [FromBody] CreateMappingRequest request)
        {
            request.SurveyId = surveyId;
            var mapping = await _mappingService.InsertSurveyMappingAsync(userEmail, request);

            return new ObjectResult(mapping) { StatusCode = 200 };
        }
    }
}
