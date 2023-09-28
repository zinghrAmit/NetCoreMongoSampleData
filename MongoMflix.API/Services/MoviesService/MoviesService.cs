using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoMflix.API.Models.Domain;


namespace MongoMflix.API.Services.MoviesService
{
    public class MoviesService : IMoviesService
    {
        private readonly IMongoCollection<Movies> _moviesCollection;
        private readonly IOptions<DataBaseSettings> _dataBaseSettings;

        public MoviesService(IOptions<DataBaseSettings> dbSettings)
        {
            _dataBaseSettings = dbSettings;

            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(dbSettings.Value.DataBaseName);
            _moviesCollection = mongoDataBase.GetCollection<Movies>(dbSettings.Value.MoviesCollectionName);
        }

        public async Task<List<Movies>> GetAllAsync()
        {
            var result = await _moviesCollection.Find(_ => true).Limit(50).ToListAsync();
            return result;
        }

        public async Task<List<Movies>> GetByYearAsync(int year)
        {
            var result = await _moviesCollection.Find(x => x.year == year).ToListAsync();
            return result;
        }
    }
}
