using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.TheaterService
{
    public class TheatersService : ITheatersService
    {
        private readonly IMongoCollection<Theaters> _theatersCollection;
        private readonly IOptions<DataBaseSettings> _dataBaseSettings;

        public TheatersService(IOptions<DataBaseSettings> dbSettings)
        {
            _dataBaseSettings = dbSettings;

            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(dbSettings.Value.DataBaseName);
            _theatersCollection = mongoDataBase.GetCollection<Theaters>(dbSettings.Value.TheatersCollectionName);
        }

        public async Task<List<Theaters>> GetAllAsync()
        {
            var result =  await _theatersCollection.Find(_ => true).Limit(50).ToListAsync();
            return result;
        }
    }
}
