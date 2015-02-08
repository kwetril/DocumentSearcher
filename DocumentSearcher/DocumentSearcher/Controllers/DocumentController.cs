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
                ModelState.AddModelError("", "File was not selected.");
                return View(document);
            }

            if (!document.HasValidExtension())
            {
                ModelState.AddModelError("", "Document's extension is not supported.");
                return View(document);
            }

            var user = userRepository.FindByLogin(User.Identity.Name);

            var indexedDocument = new IndexedDocument(document, user);
            documentRepository.Save(indexedDocument);

            return RedirectToAction("Index");
        }
	}
}