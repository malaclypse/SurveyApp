using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Services.Dtos
{
    public class Mapping
    {
        public int MappingId { get; set; }
        public int TextId { get; set; }
        public int GroupId { get; set; }
        public int SurveyId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
