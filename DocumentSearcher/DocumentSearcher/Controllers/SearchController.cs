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
    public class SearchController : Controller
    {
        IIndexedDocumentRepository documentRepository;
        IUserRepository userRepository;

        public SearchController(
            IIndexedDocumentRepository documentRepository, 
            IUserRepository userRepository)
        {
            this.documentRepository = documentRepository;
            this.userRepository = userRepository;
        }

        //
        // GET: /Search/
        public ActionResult Index()
        {
            var searchModel = new SearchFormModel();
            return View(searchModel);
        }

        [HttpPost]
        public ActionResult Index(SearchFormModel searchModel)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Query.QueryString))
            {
                string login = User.Identity.Name;
                var user = userRepository.FindByLogin(login);
                searchModel.Results = documentRepository.GetAllForUser(user);
            }
            return View(searchModel);
        }
	}
}