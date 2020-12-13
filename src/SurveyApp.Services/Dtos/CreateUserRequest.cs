namespace SurveyApp.Services.Dtos
{
    public class CreateUserRequest
    {
        public string Email { get; set; }

        public string EnglishLevel { get; set; }

        public string NativeLanguage { get; set; }

        public string Gender { get; set; }
    }
}
