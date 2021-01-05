namespace SurveyApp.Services
{
    using SurveyApp.Data;
    using SurveyApp.Services.Abstract;
    using SurveyApp.Services.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SurveyApp.Data.Models;

    public class MappingService : IMappingService
    {
        private readonly SurveyContext _dbContext;

        public MappingService(SurveyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Mapping> DeleteSurveyMappingAsync(string email, int surveyId, int mappingId)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email is mandatory!!");
            }
            try
            {
                var survey = await _dbContext.Survey.SingleOrDefaultAsync(survey => survey.UserEmail == email && survey.SurveyId == surveyId);
                if (survey != null)
                {
                    var mapping = await _dbContext.GroupTextMapping.SingleOrDefaultAsync(mapping => mapping.Survey.SurveyId == surveyId && mapping.MappingId == mappingId);
                    mapping.IsDeleted = true;
                    mapping.LastModifiedDate = DateTime.UtcNow;
                    await _dbContext.SaveChangesAsync();

                    return new Mapping()
                    {
                        MappingId = mapping.MappingId,
                        TextEntryTextId = mapping.TextEntry.TextId,
                        GroupId = mapping.Group.GroupId,
                        SurveyId = mapping.Survey.SurveyId

                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Mapping>> GetAllMappingsForSurvey(string email, int surveyId)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email is mandatory!!");
            }
            try
            {
                var survey = await _dbContext.Survey.SingleOrDefaultAsync(survey => survey.UserEmail == email && survey.SurveyId == surveyId);
                if (survey != null)
                {
                    var mappings = await _dbContext.GroupTextMapping
                        .Include(mapping => mapping.Group)
                        .Include(mapping => mapping.Survey)
                        .Include(mapping => mapping.TextEntry)
                        .Where(mapping => mapping.Survey.SurveyId == surveyId)
                        .ToListAsync();

                    return mappings.Select(mapping => new Mapping()
                        {
                            MappingId = mapping.MappingId,
                            TextEntryTextId = mapping.TextEntry.TextId,
                            GroupId = mapping.Group.GroupId,
                            SurveyId = mapping.Survey.SurveyId

                        }
                    );
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Mapping> GetSurveyMappingAsync(string email, int surveyId, int mappingId)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email is mandatory!!");
            }
            try
            {
                var survey = await _dbContext.Survey.SingleOrDefaultAsync(survey => survey.UserEmail == email && survey.SurveyId == surveyId);
                if (survey != null)
                {
                    var mapping = await _dbContext.GroupTextMapping
                        .Include(mapping => mapping.Group)
                        .Include(mapping => mapping.Survey)
                        .Include(mapping => mapping.TextEntry)
                        .SingleOrDefaultAsync(mapping => mapping.Survey.SurveyId == surveyId && mapping.MappingId == mappingId);

                    return new Mapping()
                    {
                        MappingId = mapping.MappingId,
                        TextEntryTextId = mapping.TextEntry.TextId,
                        GroupId = mapping.Group.GroupId,
                        SurveyId = mapping.Survey.SurveyId
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Mapping> InsertSurveyMappingAsync(string email, CreateMappingRequest mappingRequest)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email is mandatory!!");
            }
            try
            {
                var survey = await _dbContext.Survey.SingleOrDefaultAsync(survey => survey.UserEmail == email && survey.SurveyId == mappingRequest.SurveyId);
                if (survey != null)
                {
                    var mappings = await _dbContext.GroupTextMapping.Where(mapping => mapping.Survey.SurveyId == mappingRequest.SurveyId).ToListAsync();
                    foreach (var mapping in mappings)
                    {
                        mapping.IsDeleted = true;
                        mapping.LastModifiedDate = DateTime.UtcNow;
                    }
                    var text = await _dbContext.TextEntry.SingleOrDefaultAsync(text => text.TextId == mappingRequest.TextId);
                    var group = await _dbContext.Group.SingleOrDefaultAsync(group => group.GroupId == mappingRequest.GroupId);

                    var map = new GroupTextMappingEntity()
                    {
                        TextEntry = text,
                        Group = group,
                        Survey = survey,
                        IsDeleted = false,
                        CreatedDate = DateTime.UtcNow
                    };

                    await _dbContext.GroupTextMapping.AddAsync(map);
                    await _dbContext.SaveChangesAsync();

                    return new Mapping()
                    {
                        MappingId = map.MappingId,
                        TextEntryTextId = map.TextEntry.TextId,
                        GroupId = map.Group.GroupId,
                        SurveyId = map.Survey.SurveyId
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
