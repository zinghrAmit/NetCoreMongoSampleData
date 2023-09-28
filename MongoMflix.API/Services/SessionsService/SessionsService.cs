using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoMflix.API.Models.Domain;


namespace MongoMflix.API.Services.SessionsService
{
    public class SessionsService : ISessionsService
    {
        private readonly IMongoCollection<Sessions> _sessionsCollection;
        private readonly IOptions<DataBaseSettings> _dataBaseSettins;

        public SessionsService(IOptions<DataBaseSettings> dbSettings)
        {
            _dataBaseSettins = dbSettings;

            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DataBaseName);
            _sessionsCollection = mongoDatabase.GetCollection<Sessions>(dbSettings.Value.SessionsCollectionName);
        }

        public async Task<List<Sessions>> GetAllAsync()
        {
            return await _sessionsCollection.Find(_ => true).Limit(5).ToListAsync();
        }

        [HttpGet("{user_id}")]
        public async Task<List<Sessions>> GetByUserIdAsync(string user_id)
        {
            var result = await _sessionsCollection.Find(x => x.user_id == user_id).ToListAsync();
            return result;
        }
    }
}
