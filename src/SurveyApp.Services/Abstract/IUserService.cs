namespace SurveyApp.Services.Abstract
{
    using SurveyApp.Services.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<User> GetAsync(string email);

        Task<User> InsertAsync(CreateUserRequest user);

        Task<User> UpdateAsync(string email, UpdateUserRequest user);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
