using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Data.Models
{
    public class GroupTextMappingEntity
    {
        public int MappingId { get; set; }
        
        public TextEntryEntity TextEntry { get; set; }
        
        public GroupEntity Group { get; set; }

        public SurveyEntity Survey { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    } 
}
