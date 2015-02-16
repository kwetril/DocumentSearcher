using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentSearcher.Models.DatabaseAccess.RepositoryInterface;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DocumentSearcher.Models.DatabaseAccess.MongoRepositoryImpl
{
    public class IndexedDocumentRepository : IIndexedDocumentRepository
    {
        public MongoDatabase database;

        public IndexedDocumentRepository(MongoDatabase database)
        {
            this.database = database;
        }

        public void Save(IndexedDocument document)
        {
            DocumetCollection.Insert(document);
        }

        public IEnumerable<IndexedDocument> GetAllForUser(User user)
        {
            var query = Query<IndexedDocument>.EQ(doc => doc.UserId, user.Id);
            return DocumetCollection.Find(query);
        }

        public IndexedDocument GetById(ObjectId documentId)
        {
            return DocumetCollection.FindOneById(documentId);
        }

        private MongoCollection<IndexedDocument> DocumetCollection
        {
            get
            {
                return database.GetCollection<IndexedDocument>("Document");
            }
        }

    }
}