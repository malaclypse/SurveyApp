namespace SurveyApp.Services
{
    using SurveyApp.Data;
    using SurveyApp.Services.Abstract;
    using SurveyApp.Services.Dtos;
    using SurveyApp.Services.MappingExtensions;
    using System;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly SurveyContext _dbContext;

        public UserService(SurveyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email is mandatory!!");
            }
            try
            {
                var userEntity = await _dbContext.User.FindAsync(email);
                if(userEntity != null)
                {
                    return userEntity.ToUserModel();
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

        public async Task<User> InsertAsync(CreateUserRequest user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentNullException("Email is mandatory!!");
            }

            try
            {
                var userEntity = await _dbContext.User.FindAsync(user.Email);
                if (userEntity == null)
                {
                    userEntity = user.ToUserEntity();
                    userEntity.CreatedDate = DateTime.UtcNow;
                    userEntity.LastModifiedDate = DateTime.UtcNow;
                    await _dbContext.User.AddAsync(userEntity);
                    await _dbContext.SaveChangesAsync();
                }

                return (await _dbContext.User.FindAsync(userEntity.Email)).ToUserModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> UpdateAsync(string email, UpdateUserRequest user)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email is mandatory!!");
            }

            try
            {
                var userEntity = await _dbContext.User.FindAsync(email);
                if(userEntity != null)
                {
                    userEntity = userEntity.UpdateUserEntity(user);
                    
                }
                else
                {
                    userEntity = user.ToUserEntity(email);
                }

                userEntity.LastModifiedDate = DateTime.UtcNow;
                _dbContext.User.Update(userEntity);
                await _dbContext.SaveChangesAsync();

                return (await _dbContext.User.FindAsync(userEntity.Email)).ToUserModel();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
