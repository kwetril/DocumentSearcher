using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSearcher.Models.DatabaseAccess.RepositoryInterface
{
    public interface IIndexedDocumentRepository
    {
        IEnumerable<IndexedDocument> GetAllForUser(User user);

        void Save(IndexedDocument document);
    }
}
