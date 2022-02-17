namespace Exam.Repositories.Repositories;

using Exam.Domain.Entities;
using Exam.Domain.Interfaces;
using Exam.Repositories.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private static IMongoClient client;
    private static IMongoDatabase database;

    private readonly IMongoCollection<User> userCollection;

    public UserRepository(DatabaseSettings databaseSettings)
    {
        if (client is null)
        {
            client = new MongoClient(databaseSettings.ConnectionString);
            database = client.GetDatabase(databaseSettings.DatabaseName);
        }

        this.userCollection = database.GetCollection<User>(databaseSettings.UserCollectionName);
    }

    public async Task<User?> CreateUser(User user)
    {
        if (user is null)
        {
            return null;
        }

        await this.userCollection.InsertOneAsync(user);
        return user;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await this.userCollection.Find(_ => true).ToListAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await this.userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User?> UpdateUser(User user)
    {
        var result = await this.userCollection.ReplaceOneAsync(u => u.Id == user.Id, user);

        if (result.ModifiedCount != 1)
        {
            return null;
        }

        return user;
    }

    public async Task DeleteAllUsers()
    {
        await this.userCollection.DeleteManyAsync(_ => true);
    }
}
