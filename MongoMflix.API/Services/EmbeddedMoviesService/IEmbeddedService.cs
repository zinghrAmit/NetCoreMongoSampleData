using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.EmbeddedMoviesService
{
    public interface IEmbeddedService
    {
        Task<List<EmbeddedMovies>> GetAllAsync();
        Task<List<EmbeddedMovies>> GetByTitle(string title);
        Task<List<EmbeddedMovies>> GetByYear(int year);
    }
}