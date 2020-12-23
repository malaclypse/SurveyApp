namespace SurveyApp.Tests
{
    using NUnit.Framework;
    using SurveyApp.Data;
    using SurveyApp.Data.Models;
    using SurveyApp.Services;
    using SurveyApp.Services.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestFixture]
    public class UserServiceTests
    {
        private readonly SurveyContext _dbContext;

        private readonly UserService _userService;

        public UserServiceTests()
        {
            _dbContext = new TestUtils().GetInMemoryDbContext();
            _userService = new UserService(_dbContext);
        }

        [Test]
        public async Task Update_ValidRecord()
        {
            //ARRANGE
            var user = new UserEntity()
            {
                Email = "test@email.com",
                Gender = Gender.Male,
                CreatedDate = DateTime.UtcNow,
                EnglishLevel = EnglishLevel.FullProfessionalProficiency,
                Surveys = new List<SurveyEntity>(),
                NativeLanguage = "Dutch",
                LastModifiedDate = DateTime.UtcNow
            };

            _dbContext.User.Add(user);
            _dbContext.SaveChanges();

            var updateRequest = new UpdateUserRequest()
            {
                EnglishLevel = EnglishLevel.ElementaryProficiency.ToString(),
                Gender = Gender.NotSpecified.ToString(),
                NativeLanguage = "Bulgarian"
            };

            //ACT
            var actual = await _userService.UpdateAsync(user.Email, updateRequest);

            //ASSERT
            Assert.That(actual.Email, Is.EqualTo(user.Email));
            Assert.That(actual.EnglishLevel.ToString(), Is.EqualTo(updateRequest.EnglishLevel));
            Assert.That(actual.Gender.ToString(), Is.EqualTo(updateRequest.Gender));
            Assert.That(actual.NativeLanguage, Is.EqualTo(updateRequest.NativeLanguage));
        }
    }
}
