namespace SurveyApp.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class SurveyEntity
    {
        public int SurveyId { get; set; }

        public VariantEntity Variant { get; set; }

        public int VariantId {get; set;}

        public UserEntity User { get; set; }

        public string UserEmail { get; set; }

        public bool IsCompleted { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime? LastModifiedDate { get; set; }

        public DateTime? FinishedOnDate { get; set; }

        public List<GroupTextMappingEntity> Mappings { get; set; }
    }
}