using Microsoft.Extensions.Options;
using MongoMflix.API.Models.Domain;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<List<Comments>> GetAllAsync()
        {
            var result = await _commentsCollection.Find(_ => true).Limit(50).ToListAsync();
            return result;

            //var filter = Builders<Comments>.Filter.Eq(x => x.Id, "5a9427648b0beebeb69579e7");
            //var filter = Builders<Comments>.Filter.Empty;
            //return await _commentsCollection.Find(filter).Limit(5).ToListAsync();
        }
    }
}
