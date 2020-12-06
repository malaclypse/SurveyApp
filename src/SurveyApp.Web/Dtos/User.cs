namespace SurveyApp.Web.Dtos
{
    using SurveyApp.Data.Models;
    using System;

    public class User
    {
        public string Email { get; set; }

        public string EnglishLevelSelfDefined { get; set; }

        public Gender Gender { get; set; }
    }
}