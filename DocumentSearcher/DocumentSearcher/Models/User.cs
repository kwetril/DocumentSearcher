using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DocumentSearcher.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}