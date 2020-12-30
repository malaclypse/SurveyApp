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
	public class GroupController: ControllerBase
	{
        private readonly IGroupService _categoryService;

        public GroupController(IGroupService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Group>>> Get()
        {
            var groups = await _categoryService.GetAllAsync();
            if (groups == null)
            {
                return NotFound(groups);
            }

            return new ObjectResult(groups) { StatusCode = 200 };
        }
    }
}

