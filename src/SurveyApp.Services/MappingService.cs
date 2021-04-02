namespace SurveyApp.Services
{
    using Microsoft.EntityFrameworkCore;
    using SurveyApp.Data;
    using SurveyApp.Data.Models;
    using SurveyApp.Services.Abstract;
    using SurveyApp.Services.Dtos;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
                        TextId = mapping.TextEntry.TextId,
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

        public async Task<IEnumerable<Mapping>> GetAllMappingsForSurvey(string email, int surveyId, int? textId)
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
                    if (!textId.HasValue)
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
                            TextId = mapping.TextEntry.TextId,
                            GroupId = mapping.Group.GroupId,
                            SurveyId = mapping.Survey.SurveyId

                        }
                        );
                    }
                    else
                    {
                        var mappings = await _dbContext.GroupTextMapping
                            .Include(mapping => mapping.Group)
                            .Include(mapping => mapping.Survey)
                            .Include(mapping => mapping.TextEntry)
                            .Where(mapping => mapping.Survey.SurveyId == surveyId 
                                           && mapping.TextEntry.TextId == textId
                                           && mapping.IsDeleted == false)
                            .ToListAsync();

                        return mappings.Select(mapping => new Mapping()
                        {
                            MappingId = mapping.MappingId,
                            TextId = mapping.TextEntry.TextId,
                            GroupId = mapping.Group.GroupId,
                            SurveyId = mapping.Survey.SurveyId

                        });

                    }
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
                        TextId = mapping.TextEntry.TextId,
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
                    var mappings = await _dbContext.GroupTextMapping
                        .Where(mapping => mapping.Survey.SurveyId == mappingRequest.SurveyId
                                       && mapping.TextEntry.TextId == mappingRequest.TextId)
                        .ToListAsync();
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
                        TextId = map.TextEntry.TextId,
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

        public async Task<IEnumerable<Mapping>> GetAllMappings()
        {
            return await _dbContext.GroupTextMapping.Select(map => new Mapping()
            {
                MappingId = map.MappingId,
                TextId = map.TextEntry.TextId,
                GroupId = map.Group.GroupId,
                SurveyId = map.Survey.SurveyId,
                IsDeleted = map.IsDeleted
            }).ToListAsync();
        }

        public async Task<string> ExportMatrixCsv()
        {
            var texts = await _dbContext.TextEntry.ToListAsync();

            var maps = await _dbContext.GroupTextMapping
                .Include(map => map.TextEntry)
                .Include(map => map.Group)
                .Include(map => map.Survey)
                .Where(map => map.IsDeleted == false)
                .ToListAsync();

            int[,] results = new int[texts.Count + 1, texts.Count + 1];
            
            foreach (var map in maps)
            {
                foreach (var map2 in maps)
                {
                    if (map.TextEntry.TextId != map2.TextEntry.TextId)
                    {
                        if (map.Group.GroupId == map2.Group.GroupId)
                        {
                            results[map.TextEntry.TextId, map2.TextEntry.TextId] += 1;
                        }
                    }
                }
            }
            return ToCsv(results);
        }

        private static string ToCsv<T>(T[,] data, string separator = ",")
        {
            var sb = new StringBuilder();

            sb.AppendLine(" ," + string.Join(separator, Enumerable
                .Range(1, data.GetLength(1) - 1)
                .Select(j => $"T{j}")));


            for (int i = 1; i < data.GetLength(0); ++i)
            {
                sb.AppendLine($"T{i}," + string.Join(separator, Enumerable
                  .Range(1, data.GetLength(1) - 1)
                  .Select(j => data[i, j])));
            }

            return sb.ToString();
        }
    }
}
