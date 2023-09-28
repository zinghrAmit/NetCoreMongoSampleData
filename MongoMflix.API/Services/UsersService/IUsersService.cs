using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.UsersService
{
    public interface IUsersService
    {
        Task<List<Users>> GetAllAsycn();
    }
}