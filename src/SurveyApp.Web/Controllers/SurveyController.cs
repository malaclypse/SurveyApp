namespace SurveyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SurveyApp.Services.Abstract;
    using SurveyApp.Services.Dtos;
    using System.Threading.Tasks;

    [Route("api/user/{userEmail}/survey")]
    [Produces("application/json")]
    public class SurveyController
    {
    }
}
