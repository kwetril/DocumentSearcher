using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentSearcher.Models.Helpers.TextExtractors
{
    public static class TextExtractorFactory
    {
        public static readonly string[] SupportedFormats = { "txt" };

        public static ITextExtractor GetTextExtractor(string documentExtension)
        {
            switch (documentExtension)
            {
                case "txt":
                    return new TxtTextExtractor();
                default:
                    return null;
            }
        }
    }
}