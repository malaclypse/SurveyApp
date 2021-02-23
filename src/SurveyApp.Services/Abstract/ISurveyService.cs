using System;
using System.Collections.Generic;
using System.Text;
using SurveyApp.Services.Dtos;
using System.Threading.Tasks;

namespace SurveyApp.Services.Abstract
{
    public interface ISurveyService
    {
        Task<Survey> InsertAsync(string email);

        Task<IEnumerable<Survey>> GetAll(string email);

        Task<IEnumerable<Survey>> GetAllSurveys();

        Task<Survey> GetAsync( int surveyId);

        Task<Survey> UpdateAsync(int surveyId, UpdateSurveyRequest updateRequest);
    }
}
