using MongoMflix.API.Models.Domain;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace MongoMflix.API.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IMongoCollection<Users> _usersCollection;
        private readonly IOptions<DataBaseSettings> _dataBaseSettings;

        public UsersService(IOptions<DataBaseSettings> dbSettings)
        {
            _dataBaseSettings = dbSettings;

            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(dbSettings.Value.DataBaseName);
            _usersCollection = mongoDataBase.GetCollection<Users>(dbSettings.Value.UsersCollectonName);
        }

        public async Task<List<Users>> GetAllAsycn()
        {
            var result = await _usersCollection.Find(_ => true).Limit(100).ToListAsync();
            return result;
        }
    }
}
