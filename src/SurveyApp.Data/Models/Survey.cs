namespace SurveyApp.Data.Models
{
    using System;

    public class Survey
    {
        public int SurveyId { get; set; }

        public int VariantId {get; set;}

        public bool IsCompleted { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime LastModifiedDate { get; set; }

        public DateTime FinishedOnDate { get; set; }

        public User User { get; set; }

        public string UserEmail { get; set; }
    }
}