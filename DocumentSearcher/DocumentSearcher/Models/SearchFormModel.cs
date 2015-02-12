using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentSearcher.Models
{
    public class SearchFormModel
    {
        public QueryModel Query { get; set; }
        public SearchSettingsModel Settings { get; set; }
        public IEnumerable<SearchResultItem> Results { get; set; }

        public SearchFormModel()
        {
            Query = new QueryModel();
            Settings = new SearchSettingsModel();
            Results = new List<SearchResultItem>();
        }
    }
}