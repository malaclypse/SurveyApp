namespace SurveyApp.Services.Dtos
{
    using SurveyApp.Data.Models;
    using System;

    public class User
    {
        public string Email { get; set; }

        public string EnglishLevel { get; set; }

        public string NativeLanguage { get; set; }

        public string Gender { get; set; }
    }
}