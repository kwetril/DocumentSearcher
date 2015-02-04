﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace DocumentSearcher.Models.DatabaseAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoDatabase database;

        public UserRepository(MongoDatabase database)
        {
            this.database = database;
        }

        public void InsertUser(User user)
        {
            UserCollection.Insert(user);
        }
        
        public User[] GetUsers()
        {
            return UserCollection.FindAll().ToArray();
        }

        private MongoCollection<User> UserCollection 
        { 
            get
            {
                return database.GetCollection<User>("Users");
            }
        }
    }
}