using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSearcher.Models.DatabaseAccess.RepositoryInterface
{
    public interface ITermsInDocumentsRepository
    {
        TermsInDocuments FindForUser(User user);

        void AddDocumentForUser(IndexedDocument document, User user);
    }
}
