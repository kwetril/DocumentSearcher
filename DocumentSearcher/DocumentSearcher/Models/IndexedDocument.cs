using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DocumentSearcher.Models
{
    public class IndexedDocument
    {
        public ObjectId Id { get; set; }

        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public ObjectId UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}