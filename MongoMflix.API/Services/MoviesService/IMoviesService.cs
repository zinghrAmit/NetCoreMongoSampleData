using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.MoviesService
{
    public interface IMoviesService
    {
        Task<List<Movies>> GetAllAsync();
        Task<List<Movies>> GetByYearAsync(int year);
    }
}