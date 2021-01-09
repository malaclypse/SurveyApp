using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Services.Abstract;
using SurveyApp.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyApp.Web.Controllers
{
    [Route("api/text")]
    [Produces("application/json")]
    [ApiController]
    public class TextController: ControllerBase
    {
        private readonly ITextService _textService;

        public TextController(ITextService textService)
        {
            _textService = textService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TextEntry>>> Get([FromQuery] int variantId)
        {
            var texts = await _textService.GetAllAsync(variantId);
            if (texts == null)
            {
                return NotFound(texts);
            }

            return new ObjectResult(texts) { StatusCode = 200 };
        }
    }
}
