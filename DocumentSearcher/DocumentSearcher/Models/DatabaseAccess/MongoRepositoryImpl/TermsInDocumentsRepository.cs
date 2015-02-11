using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentSearcher.Models.DatabaseAccess.RepositoryInterface;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DocumentSearcher.Models.DatabaseAccess.MongoRepositoryImpl
{
    public class TermsInDocumentsRepository : ITermsInDocumentsRepository
    {
        private readonly MongoDatabase database;

        public TermsInDocumentsRepository(MongoDatabase database)
        {
            this.database = database;
        }

        public TermsInDocuments FindForUser(User user)
        {
            var query = Query<TermsInDocuments>.EQ(x => x.UserId, user.Id);
            return TermsInDocsCollection.FindOne(query);
        }

        public void AddDocumentForUser(IndexedDocument document, User user)
        {
            TermsInDocuments termsInDocs = FindForUser(user);
            if (termsInDocs == null)
            {
                termsInDocs = new TermsInDocuments();
            }
            termsInDocs.AddDocumentTerms(document);
            TermsInDocsCollection.Save(termsInDocs);
        }

        private MongoCollection<TermsInDocuments> TermsInDocsCollection
        {
            get
            {
                return database.GetCollection<TermsInDocuments>("TermsInDocuments");
            }
        }
    }
}