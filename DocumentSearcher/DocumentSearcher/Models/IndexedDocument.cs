using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentSearcher.Models.Helpers.TextExtractors;
using MongoDB.Bson;
using SearchCore.TextProcessors;

namespace DocumentSearcher.Models
{
    public class IndexedDocument
    {
        public IndexedDocument()
        {
        }

        public IndexedDocument(DocumentModel uploadedDocument, User user, DocumentIndexator documentIndexator)
        {
            var uploadedFile = uploadedDocument.File;
            FileName = uploadedFile.FileName;
            CreatedDate = DateTime.Now;
            UserId = user.Id;

            ITextExtractor textExtractor = TextExtractorFactory.GetTextExtractor(uploadedDocument.DocumentExtension);
            string text = textExtractor.ExtractText(uploadedDocument) + ' ' + FileName;
            WordCount = documentIndexator.ExtractWordCounts(text);
        }

        public ObjectId Id { get; set; }

        public string FileName { get; set; }
        public ObjectId UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Dictionary<string, int> WordCount {get; set; }
    }
}