using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Data.Models
{
    public class PasswordEntity
    {
        public long PasswordId { get; set;  }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
