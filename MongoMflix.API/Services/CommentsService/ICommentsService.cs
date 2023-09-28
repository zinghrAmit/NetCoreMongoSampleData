using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.CommentsService
{
    public interface ICommentsService
    {
        Task<List<Comments>> GetAllAsync();
    }
}