using MongoMflix.API.Models.Domain;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http.HttpResults;

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

        // GET ALL USERS
        public async Task<List<Users>> GetAllAsycn()
        {
            var result = await _usersCollection.Find(_ => true).Limit(100).ToListAsync();
            return result;
        }

        // GET USERS BY 'NAME'
        public async Task<List<Users>> GetByName(string name)
        {
            var result = await _usersCollection.Find(x => x.name == name).ToListAsync();
            return result;
        }

        // ADD A NEW USER TO DATA BASE
        public async Task PostUserAsync(Users user)
        {
            try
            {
                await _usersCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UPDATE USER
        public async Task UpdateUserNameAsync(string currentName, string newName)
        {
            try
            {
                var filter = Builders<Users>.Filter.Eq(x => x.name, currentName);
                var update = Builders<Users>.Update.Set(x => x.name, newName);
                await _usersCollection.UpdateOneAsync(filter, update);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE USER
        public async Task DeleteUserAsync(string email)
        {
            try
            {
                var filter = Builders<Users>.Filter.Eq(x => x.email, email);
                await _usersCollection.DeleteOneAsync(filter);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
