namespace SurveyApp.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public string Email { get; set; }

        public List<Survey> Surveys { get; set; }
        
        public string EnglishLevelSelfDefined { get; set; }
        
        public string EnglishLevelCertified { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime LastModifiedDate { get; set; }
    }
}
