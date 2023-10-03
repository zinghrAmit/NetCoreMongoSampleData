using Microsoft.Extensions.Options;
using MongoMflix.API.Models.Domain;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace MongoMflix.API.Services.CommentsService
{
    public class CommentsService : ICommentsService
    {
        private readonly IMongoCollection<Comments> _commentsCollection;
        private readonly IOptions<DataBaseSettings> _databaseSettings;

        public CommentsService(IOptions<DataBaseSettings> dbSettings)
        {
            _databaseSettings = dbSettings;

            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(dbSettings.Value.DataBaseName);
            _commentsCollection = mongoDataBase.GetCollection<Comments>(dbSettings.Value.CommentsCollectionName);
        }

        // GET FIRST 50 COMMENTS
        public async Task<List<Comments>> GetAllAsync()
        {
            var result = await _commentsCollection.Find(_ => true).Limit(10).ToListAsync();
            return result;
        }

        // GET COMMENTS BY MOVIE_ID,M i.e WHAT IS THE COMMENT ON A PARTICULAR MOVIE
        public async Task<List<Comments>> GetCommentsById(string id)
        {
            var result = await _commentsCollection.Find(x => x.movie_id == id).ToListAsync();
            return result;
        }

        // GET COMMENT BY EMAIL, i.e WHICH ACCOUNT IS COMMENTED WHAT WITH OTHER DETAILS IN API
        public async Task<List<Comments>> GetCommentsByEmail(string email)
        {
            var result = await _commentsCollection.Find(x => x.email == email).ToListAsync();
            return result;
        }

        // GET ALL COMMENTS ON A SPECIFIC DATE
        public async Task<List<Comments>> GetCommentsByDate(DateTime date)
        {
            var result = await _commentsCollection.Find( x => x.date == date).ToListAsync();
            return result;
        }

        // POST A COMMENT
        public async Task PostComment(Comments comment)
        {
            try
            {
                if (comment != null)
                {
                    await _commentsCollection.InsertOneAsync(comment);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UPDATE A COMMENT
        public async Task UpateCommentAsync(string email, string comment)
        {
            try
            {
                if(comment != null)
                {
                    var filter = Builders<Comments>.Filter.Eq(x => x.email, email);
                    var update = Builders<Comments>.Update.Set(x => x.text, comment);
                    await _commentsCollection.UpdateOneAsync(filter, update);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELTE A COMMENT
        public async Task DeleteCommentAsync(string email)
        {
            try
            {
                await _commentsCollection.DeleteOneAsync(x => x.email == email);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
