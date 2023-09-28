using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.EmbeddedMoviesService
{
    public interface IEmbeddedService
    {
        Task<List<EmbeddedMovies>> GetAllAsync();
    }
}