using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.TheaterService
{
    public interface ITheatersService
    {
        Task<List<Theaters>> GetAllAsync();
        Task<List<Theaters>> GetByIdASync(int id);
        Task<List<Theaters>> GetAllCitiesAsync();
        Task<List<Theaters>> GetByZipcode(string zipcode);
    }
}