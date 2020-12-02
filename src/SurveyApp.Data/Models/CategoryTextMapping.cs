using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Data.Models
{
    public class CategoryTextMapping
    {
        public int MappingId { get; set; }
        
        public TextEntry TextEntry { get; set; }
        
        public Category Category { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    } 
}
