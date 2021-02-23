using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Abstract
{
    public interface IPasswordService
    {
        public Task<bool> Login(string password);
    }
}
