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
                EnglishLevel = Enum.Parse<EnglishLevel>(user.EnglishLevel, true),
                Gender = Enum.Parse<Gender>(user.Gender, true),
                NativeLanguage = user.NativeLanguage
            };
        }

        public static UserEntity ToUserEntity(this UpdateUserRequest user, string email)
        {
            return new UserEntity()
            {
                Email = email,
                EnglishLevel = Enum.Parse<EnglishLevel>(user.EnglishLevel, true),
                Gender = Enum.Parse<Gender>(user.Gender, true),
                NativeLanguage = user.NativeLanguage
            };
        }

        public static UserEntity UpdateUserEntity(this UserEntity userEntity, UpdateUserRequest user)
        {
            userEntity.EnglishLevel = Enum.Parse<EnglishLevel>(user.EnglishLevel, true);
            userEntity.Gender = Enum.Parse<Gender>(user.Gender, true);
            userEntity.NativeLanguage = user.NativeLanguage;
            
            return userEntity;
        }

        public static User ToUserModel(this UserEntity userEntity)
        {
            return new User()
            {
                Email = userEntity.Email,
                EnglishLevel = userEntity.EnglishLevel.ToString(),
                Gender = userEntity.Gender.ToString(),
                NativeLanguage = userEntity.NativeLanguage
            };
        }
    }
}
