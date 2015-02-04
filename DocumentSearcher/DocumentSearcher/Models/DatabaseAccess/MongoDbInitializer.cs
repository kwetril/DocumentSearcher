using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;

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
            return databaseServer.GetDatabase(connectionUrl.DatabaseName);
        }
    }
}