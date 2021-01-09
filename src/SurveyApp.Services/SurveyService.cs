﻿using System;
using System.Collections.Generic;
using System.Text;
using SurveyApp.Services.Dtos;
using System.Threading.Tasks;
using SurveyApp.Services.Abstract;
using SurveyApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Data.Models;
using SurveyApp.Services.MappingExtensions;

namespace SurveyApp.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly SurveyContext _dbContext;

        public SurveyService(SurveyContext dbContext)
        {
            _dbContext = dbContext;
        }

		public async Task<Survey> GetAsync( int surveyId)
		{
            var userSurvey = await _dbContext.Survey.SingleOrDefaultAsync(survey => survey.SurveyId == surveyId );
            if (userSurvey == null)
            {
                return null;
            }
            return userSurvey.ToSurveyModel();
        }

        public async Task<IEnumerable<Survey>> GetAll(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {

            }
            var userSurveys = await _dbContext.Survey.Where(survey => survey.UserEmail == email).ToListAsync();
            return userSurveys.Select(survey=>survey.ToSurveyModel());
        }

        public async Task<Survey> InsertAsync(string email)
        {
            Random rnd = new Random();

            var user = await _dbContext.User.FindAsync(email);
            var userSurveys = await _dbContext.Survey.Where(survey=>survey.UserEmail==email).ToListAsync();
            var userVariants = userSurveys.Select(survey => survey.VariantId);
            var variants = await _dbContext.Variant.Where(variant => !userVariants.Contains(variant.VariantId)).ToListAsync();
            int r = rnd.Next(variants.Count);
            var nextVariant = variants[r];

            var survey = new SurveyEntity()
            {
                VariantId = nextVariant.VariantId,
                UserEmail = email,
                IsCompleted = false,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
            };

            await _dbContext.Survey.AddAsync(survey);
            await _dbContext.SaveChangesAsync();

            return survey.ToSurveyModel();
        }

		public async Task<Survey> UpdateAsync(int surveyId, UpdateSurveyRequest updateRequest)
		{
            var userSurvey = await _dbContext.Survey.SingleOrDefaultAsync(survey => survey.SurveyId == surveyId );
			if (updateRequest.IsCompleted.HasValue)
			{
                userSurvey.IsCompleted = updateRequest.IsCompleted.Value;
                if(updateRequest.IsCompleted.Value)
				{
                    userSurvey.FinishedOnDate = DateTime.UtcNow;
				}
			}
            if (updateRequest.IsDeleted.HasValue)
            {
                userSurvey.IsDeleted = updateRequest.IsDeleted.Value;
                userSurvey.LastModifiedDate = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();
            return userSurvey.ToSurveyModel();
        }

    }
}
