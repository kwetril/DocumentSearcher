using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentSearcher.Models.DatabaseAccess.RepositoryInterface;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DocumentSearcher.Models.DatabaseAccess.MongoRepositoryImpl
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoDatabase database;

        public UserRepository(MongoDatabase database)
        {
            this.database = database;
        }

        public void Create(User user)
        {
            UserCollection.Insert(user);
        }

        public User[] GetAll()
        {
            return UserCollection.FindAll().ToArray();            
        }

        public User FindByLogin(string login)
        {
            var query = Query<User>.EQ(u => u.Login, login);
            return UserCollection.FindOne(query);
        }

        private MongoCollection<User> UserCollection
        {
            get
            {
                return database.GetCollection<User>("User");
            }
        }
    }
}