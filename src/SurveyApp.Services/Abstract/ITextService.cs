using System;
using System.Collections.Generic;
using System.Text;
using SurveyApp.Services.Dtos;
using System.Threading.Tasks;

namespace SurveyApp.Services.Abstract
{
    public interface ITextService
    {
        Task<IEnumerable<TextEntry>> GetAllAsync(int variantId);
    }
}
