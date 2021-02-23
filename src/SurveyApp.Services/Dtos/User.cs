namespace SurveyApp.Services.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public string Email { get; set; }

        public string EnglishLevel { get; set; }

        public string NativeLanguage { get; set; }

        public string Gender { get; set; }

        public string Education { get; set; }

        public string Country { get; set; }

        public bool? IsInterestedInMoreInfo { get; set; }
    }
}
