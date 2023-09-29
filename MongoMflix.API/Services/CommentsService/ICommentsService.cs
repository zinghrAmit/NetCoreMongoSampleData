using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.CommentsService
{
    public interface ICommentsService
    {
        Task<List<Comments>> GetAllAsync();
        Task<List<Comments>> GetCommentsById([FromRoute] string id);
        Task<List<Comments>> GetCommentsByEmail(string email);
        Task<List<Comments>> GetCommentsByDate(DateTime date);
        Task PostComment(Comments comment);
        Task UpateCommentAsync(string email, string comment);
        Task DeleteCommentAsync(string email);
    }
}