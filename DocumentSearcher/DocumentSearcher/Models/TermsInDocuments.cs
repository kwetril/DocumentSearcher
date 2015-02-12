using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DocumentSearcher.Models
{
    public class TermsInDocuments
    {
        public ObjectId Id { get; set; }

        public ObjectId UserId { get; set; }
        public Dictionary<string, int> WordInDocumentsAppearance {get; set; }

        public TermsInDocuments()
        {
            WordInDocumentsAppearance = new Dictionary<string, int>();
        }

        public void AddDocumentTerms(IndexedDocument document)
        {            
            foreach (string term in document.WordFrequency.Keys)
            {
                int currentValue;
                if (!WordInDocumentsAppearance.TryGetValue(term, out currentValue))
                {
                    currentValue = 0;
                }
                WordInDocumentsAppearance[term] = currentValue + 1;
            }
        }
    }
}