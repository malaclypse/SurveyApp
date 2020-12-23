namespace SurveyApp.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class UserEntity
    {
        public string Email { get; set; }
        
        public EnglishLevel? EnglishLevel { get; set; }

        public string NativeLanguage { get; set; }

        public Gender? Gender { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime LastModifiedDate { get; set; }

        public List<SurveyEntity> Surveys { get; set; }
    }
}
