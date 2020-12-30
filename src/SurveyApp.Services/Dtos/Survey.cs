using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Services.Dtos
{
    public class Survey
    {
        public int SurveyId { get; set; }

        public int VariantId { get; set; }

        public string UserEmail { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public DateTime? FinishedOnDate { get; set; }

    }
}
