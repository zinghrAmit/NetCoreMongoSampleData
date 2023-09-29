using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.UsersService
{
    public interface IUsersService
    {
        Task<List<Users>> GetAllAsycn();
        Task<List<Users>> GetByName(string name);
        Task PostUserAsync(Users user);
        Task UpdateUserNameAsync(string currentName, string newName);
        Task DeleteUserAsync(string email);
    }
}