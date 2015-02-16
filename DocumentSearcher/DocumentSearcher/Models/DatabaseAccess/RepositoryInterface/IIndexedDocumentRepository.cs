using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DocumentSearcher.Models.DatabaseAccess.RepositoryInterface
{
    public interface IIndexedDocumentRepository
    {
        IEnumerable<IndexedDocument> GetAllForUser(User user);

        IndexedDocument GetById(ObjectId documentId);

        void Save(IndexedDocument document);
    }
}
