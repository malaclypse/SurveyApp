using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Services.Dtos
{
    public class CreateMappingRequest
    {
        public int SurveyId { get; set; }
        public int groupId { get; set; }
        public int textId { get; set; }
    }
}
