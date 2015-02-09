using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCore.TextProcessors.Interfaces
{
    public interface IWordCounter
    {
        Dictionary<string, int> CountWords(string[] text);
    }
}
