namespace SurveyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using SurveyApp.Services.Abstract;
    using SurveyApp.Services.Dtos;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    [Route("api/admin")]
    [Produces("application/json")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMappingService _mappingService;
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        private readonly ISurveyService _surveyService;
        private readonly IConfiguration _configuration;

        public AdminController(IMappingService mappingService, 
            IUserService userService, 
            IPasswordService passwordService, 
            IConfiguration configuration, 
            ISurveyService surveyService)
        {
            _mappingService = mappingService;
            _userService = userService;
            _passwordService = passwordService;
            _configuration = configuration;
            _surveyService = surveyService;
        }

        [HttpGet]
        [Authorize]
        [Route("mappings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Mapping>>> GetAllMappings()
        {
            var mappings = await _mappingService.GetAllMappings();
            if (mappings == null)
            {
                return NotFound(mappings);
            }

            return new ObjectResult(mappings) { StatusCode = 200 };
        }



        [HttpGet]
        [Authorize]
        [Route("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            if (users == null)
            {
                return NotFound(users);
            }

            return new ObjectResult(users) { StatusCode = 200 };
        }

        [HttpGet]
        [Authorize]
        [Route("surveys")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Survey>>> GetAllSurveys()
        {
            var surveys = await _surveyService.GetAllSurveys();
            if (surveys == null)
            {
                return NotFound(surveys);
            }

            return new ObjectResult(surveys) { StatusCode = 200 };
        }

        [HttpGet]
        [Route("matrix")]
        [Produces("text/csv")]
        public async Task<FileResult> DownloadMatrixCsv()
        {
            var matrix = await _mappingService.ExportMatrixCsv();
            string fileName = $"matrix{DateTime.Now:yyyyMMdd-HHmm}.csv";
            var data = Encoding.UTF8.GetBytes(matrix);

            return File(data, "text/csv", fileName);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string password)
        {
            var userFromRepo = await _passwordService.Login(password);
            if (!userFromRepo) //User login failed
                return Unauthorized();

            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, "Id"),
                    new Claim(ClaimTypes.Name, "1")
                }),
                Expires = DateTime.Now.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { tokenString });
        } 
    }
}
