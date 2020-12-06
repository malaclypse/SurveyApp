namespace SurveyApp.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class UserEntity
    {
        public string Email { get; set; }

        public List<SurveyEntity> Surveys { get; set; }
        
        public string EnglishLevelSelfDefined { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime LastModifiedDate { get; set; }

        public Gender Gender { get; set; }
    }
}
