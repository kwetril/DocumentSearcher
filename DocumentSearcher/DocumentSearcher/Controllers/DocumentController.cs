using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentSearcher.Models;

namespace DocumentSearcher.Controllers
{
    public class DocumentController : Controller
    {
        //
        // GET: /Document/
        public ActionResult Index()
        {
            return View();
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

            byte[] uploadedFile = new byte[document.File.InputStream.Length];
            document.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            return View();
        }
	}
}