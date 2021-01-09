namespace SurveyApp.Services.Dtos
{
    public class UpdateUserRequest
    {
        public string EnglishLevel { get; set; }

        public string NativeLanguage { get; set; }

        public string Gender { get; set; }

        public string Education { get; set; }
    }
}
