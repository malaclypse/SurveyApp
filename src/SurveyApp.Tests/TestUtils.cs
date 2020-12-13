using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;
using System;

namespace SurveyApp.Tests
{
    public class TestUtils
    {
        public SurveyContext GetInMemoryDbContext()
        {
            DbContextOptions<SurveyContext> options;
            var builder = new DbContextOptionsBuilder<SurveyContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            options = builder.Options;
            SurveyContext surveyContext = new SurveyContext(options);
            surveyContext.Database.EnsureDeleted();
            surveyContext.Database.EnsureCreated();
            return surveyContext;
        }
    }
}
