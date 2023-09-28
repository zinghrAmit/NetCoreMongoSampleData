using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.SessionsService
{
    public interface ISessionsService
    {
        Task<List<Sessions>> GetAllAsync();
    }
}