using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Services.MappingExtensions
{
    using SurveyApp.Data.Models;
    using SurveyApp.Services.Dtos;
    using System;
    public static class SurveyMappingExtentions
    {
        public static Survey ToSurveyModel(this SurveyEntity surveyEntity)
        {
            return new Survey
            {
                CreatedDate = surveyEntity.CreatedDate,
                IsCompleted = surveyEntity.IsCompleted,
                FinishedOnDate = surveyEntity.FinishedOnDate,
                IsDeleted = surveyEntity.IsDeleted,
                LastModifiedDate = surveyEntity.LastModifiedDate,
                SurveyId = surveyEntity.SurveyId,
                UserEmail = surveyEntity.UserEmail,
                VariantId = surveyEntity.VariantId
            };
        }
    }
}
