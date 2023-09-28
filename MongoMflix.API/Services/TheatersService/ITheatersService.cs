using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.TheaterService
{
    public interface ITheatersService
    {
        Task<List<Theaters>> GetAllAsync();
    }
}