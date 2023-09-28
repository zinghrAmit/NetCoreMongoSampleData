using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoMflix.API.Models.Domain;

namespace MongoMflix.API.Services.EmbeddedMoviesService
{
    public class EmbeddedService : IEmbeddedService
    {
        private readonly IMongoCollection<EmbeddedMovies> _collectionName;
        private readonly IOptions<DataBaseSettings> _dataBaseSettings;

        public EmbeddedService(IOptions<DataBaseSettings> dbSettings)
        {
            _dataBaseSettings = dbSettings;

            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(dbSettings.Value.DataBaseName);
            _collectionName = mongoDataBase.GetCollection<EmbeddedMovies>(dbSettings.Value.EmbeddedMoviesCollectionName);
        }

        public async Task<List<EmbeddedMovies>> GetAllAsync()
        {
            var result = await _collectionName.Find(_ => true).Limit(50).ToListAsync();
            return result;
        }

        // EMBEDDED MOVIES BY TITLE
        public async Task<List<EmbeddedMovies>> GetByTitle(string title)
        {
            var result = await _collectionName.Find(x => x.title == title).ToListAsync();
            return result;
        }

        // BY YEAR
        public async Task<List<EmbeddedMovies>> GetByYear(int year)
        {
            var result = await _collectionName.Find(x => x.year == year).ToListAsync();
            return result;
        }
    }
}
