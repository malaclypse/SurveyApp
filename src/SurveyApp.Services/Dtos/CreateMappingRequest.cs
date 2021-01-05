using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Services.Dtos
{
    public class CreateMappingRequest
    {
        public int SurveyId { get; set; }
        public int GroupId { get; set; }
        public int TextId { get; set; }
    }
}
