using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentSearcher.Models;
using DocumentSearcher.Models.DatabaseAccess.RepositoryInterface;
using SearchCore.SearchHelpers;
using SearchCore.TextProcessors;

namespace DocumentSearcher.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        IIndexedDocumentRepository documentRepository;
        IUserRepository userRepository;
        DocumentIndexator documentIndexator;
        RelevancyCounter relevancyCounter;

        public SearchController(
            IIndexedDocumentRepository documentRepository, 
            IUserRepository userRepository,
            DocumentIndexator documentIndexator,
            RelevancyCounter relevancyCounter)
        {
            this.documentRepository = documentRepository;
            this.userRepository = userRepository;
            this.documentIndexator = documentIndexator;
            this.relevancyCounter = relevancyCounter;
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
                var queryFrequencies = documentIndexator.ExtractWordFrequency(searchModel.Query.QueryString);

                string login = User.Identity.Name;
                var user = userRepository.FindByLogin(login);
                var documents = documentRepository.GetAllForUser(user); 
                IEnumerable<Dictionary<string, double> > allFrequencies = documents.Select(doc => doc.WordFrequency);
                searchModel.Results = documents.Select(doc => new SearchResultItem() {
                    Document = doc,
                    Relevancy = relevancyCounter.GetDocumentRelevancy(queryFrequencies, doc.WordFrequency, allFrequencies)
                }).Where(result => result.Relevancy > 0).OrderByDescending(result => result.Relevancy).ToList();
            }
            return View(searchModel);
        }
	}
}