using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCore.TextProcessors.Interfaces
{
    public interface IStopWordsProvider
    {
        ImmutableHashSet<string> GetStopWords();
    }
}
