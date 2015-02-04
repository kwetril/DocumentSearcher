using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DocumentSearcher.Models.DatabaseAccess
{
    public static class MongoDbInitializer
    {
        public static MongoDatabase Init()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            MongoUrl connectionUrl = MongoUrl.Create(connectionString);
            var databaseClient = new MongoClient(connectionString);
            var databaseServer = databaseClient.GetServer();
            var database = databaseServer.GetDatabase(connectionUrl.DatabaseName);
            EnsureIndexesForUserCollection(database);
            return databaseServer.GetDatabase(connectionUrl.DatabaseName);
        }

        private static void EnsureIndexesForUserCollection(MongoDatabase database)
        {
            var collection = database.GetCollection("User");
            collection.CreateIndex(IndexKeys.Ascending("Login"), IndexOptions.SetUnique(true));
        }
    }
}