using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Data.Models
{
    public class CategoryTextMappingEntity
    {
        public int MappingId { get; set; }
        
        public TextEntryEntity TextEntry { get; set; }
        
        public CategoryEntity Category { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    } 
}
