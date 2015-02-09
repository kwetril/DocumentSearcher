using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DocumentSearcher.Models.Helpers.TextExtractors
{
    public class TxtTextExtractor : ITextExtractor
    {
        public string ExtractText(DocumentModel document)
        {
            TextReader textReader = new StreamReader(document.File.InputStream);
            return textReader.ReadToEnd();
        }
    }
}