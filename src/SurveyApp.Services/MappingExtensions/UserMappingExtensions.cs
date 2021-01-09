namespace SurveyApp.Services.MappingExtensions
{
    using SurveyApp.Data.Models;
    using SurveyApp.Services.Dtos;
    using System;

    public static class UserMappingExtensions
    {
        public static UserEntity ToUserEntity(this CreateUserRequest user)
        {
            return new UserEntity()
            {
                Email = user.Email,
                EnglishLevel = user.EnglishLevel == null ? (EnglishLevel?)null : Enum.Parse<EnglishLevel>(user.EnglishLevel, true),
                Gender = user.Gender == null ? (Gender?)null : Enum.Parse<Gender>(user.Gender, true),
                NativeLanguage = user.NativeLanguage,
                Education = user.Education == null ? (Education?)null : Enum.Parse<Education>(user.Education, true)
            };
        }

        public static UserEntity ToUserEntity(this UpdateUserRequest user, string email)
        {
            return new UserEntity()
            {
                Email = email,
                EnglishLevel = user.EnglishLevel == null ? (EnglishLevel?)null : Enum.Parse<EnglishLevel>(user.EnglishLevel, true),
                Gender = user.Gender == null ? (Gender?)null : Enum.Parse<Gender>(user.Gender, true),
                NativeLanguage = user.NativeLanguage,
                Education = user.Education == null ? (Education?)null : Enum.Parse<Education>(user.Education, true)
        };
        }

        public static UserEntity UpdateUserEntity(this UserEntity userEntity, UpdateUserRequest user)
        {
            userEntity.EnglishLevel = user.EnglishLevel == null ? (EnglishLevel?)null : Enum.Parse<EnglishLevel>(user.EnglishLevel, true);
            userEntity.Gender = user.Gender == null ? (Gender?)null : Enum.Parse<Gender>(user.Gender, true);
            userEntity.NativeLanguage = user.NativeLanguage;
            userEntity.Education = user.Education == null ? (Education?)null : Enum.Parse<Education>(user.Education, true);

            return userEntity;
        }

        public static User ToUserModel(this UserEntity userEntity)
        {
            return new User()
            {
                Email = userEntity.Email,
                EnglishLevel = userEntity.EnglishLevel?.ToString(),
                Gender = userEntity.Gender?.ToString(),
                NativeLanguage = userEntity.NativeLanguage,
                Education = userEntity.Education?.ToString()
            };
        }
    }
}
