using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentSearcher.Models;
using DocumentSearcher.Models.DatabaseAccess.RepositoryInterface;
using DocumentSearcher.Models.Helpers.TextExtractors;
using SearchCore.TextProcessors;

namespace DocumentSearcher.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        IUserRepository userRepository;
        IIndexedDocumentRepository documentRepository;
        ITermsInDocumentsRepository termsInDocsRepository;
        DocumentIndexator documentIndexator;

        public DocumentController(IIndexedDocumentRepository documentRepository,
            IUserRepository userRepository, 
            ITermsInDocumentsRepository termsInDocsRepository,
            DocumentIndexator documentIndexator)
        {
            this.documentRepository = documentRepository;
            this.userRepository = userRepository;
            this.termsInDocsRepository = termsInDocsRepository;
            this.documentIndexator = documentIndexator;
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
                ModelState.AddModelError("", "File was not selected.");
                return View(document);
            }

            if (!document.HasValidExtension())
            {
                ModelState.AddModelError("", "Document's extension is not supported.");
                return View(document);
            }

            var user = userRepository.FindByLogin(User.Identity.Name);

            var indexedDocument = new IndexedDocument(document, user, documentIndexator);
            documentRepository.Save(indexedDocument);
            termsInDocsRepository.AddDocumentForUser(indexedDocument, user);

            return RedirectToAction("Index");
        }
	}
}