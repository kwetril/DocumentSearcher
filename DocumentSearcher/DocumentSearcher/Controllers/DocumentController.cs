using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentSearcher.Models;
using DocumentSearcher.Models.DatabaseAccess.RepositoryInterface;

namespace DocumentSearcher.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        IUserRepository userRepository;
        IIndexedDocumentRepository documentRepository;

        public DocumentController(IIndexedDocumentRepository documentRepository, IUserRepository userRepository)
        {
            this.documentRepository = documentRepository;
            this.userRepository = userRepository;
        }

        //
        // GET: /Document/
        public ActionResult Index()
        {
            var user = userRepository.FindByLogin(User.Identity.Name);
            var documents = documentRepository.GetAllForUser(user);
            return View(documents.ToArray());
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(DocumentModel document)
        {
            if (!ModelState.IsValid)
            {
                return View(document);
            }
            
            var indexedDocument = ConstructIndexedDocument(document);
            documentRepository.Save(indexedDocument);

            return RedirectToAction("Index");
        }

        private IndexedDocument ConstructIndexedDocument(DocumentModel document)
        {
            var uploadedFile = document.File;

            IndexedDocument indexedDocument = new IndexedDocument();
            indexedDocument.FileName = uploadedFile.FileName;
            indexedDocument.FileContent = new byte[uploadedFile.InputStream.Length];
            uploadedFile.InputStream.Read(indexedDocument.FileContent, 0, indexedDocument.FileContent.Length);

            indexedDocument.CreatedDate = DateTime.Now;

            var user = userRepository.FindByLogin(User.Identity.Name);
            indexedDocument.UserId = user.Id;

            return indexedDocument;
        }
	}
}