using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSearcher.Models.Helpers.TextExtractors
{
    public interface ITextExtractor
    {
        string ExtractText(DocumentModel document);
    }
}
