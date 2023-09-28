using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.CommentsService
{
    public interface ICommentsService
    {
        Task<List<Comments>> GetAllAsync();
        Task<List<Comments>> GetCommentsById([FromRoute] string id);
        Task<List<Comments>> GetCommentsByEmail(string email);
        Task<List<Comments>> GetCommentsByDate(DateTime date);
    }
}