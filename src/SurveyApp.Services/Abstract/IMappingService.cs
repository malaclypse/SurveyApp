namespace SurveyApp.Services.Abstract
{
    using SurveyApp.Services.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMappingService
    {
        public Task<IEnumerable<Mapping>> GetAllMappingsForSurvey(string email, int surveyId, int? textId);

        public Task<Mapping> GetSurveyMappingAsync(string email, int surveyId, int mappingId);

        public Task<Mapping> DeleteSurveyMappingAsync(string email, int surveyId, int mappingId);

        public Task<Mapping> InsertSurveyMappingAsync(string email, CreateMappingRequest mappingRequest);

        public Task<IEnumerable<Mapping>> GetAllMappings();

        public Task<string> ExportMatrixCsv();
    }
}
