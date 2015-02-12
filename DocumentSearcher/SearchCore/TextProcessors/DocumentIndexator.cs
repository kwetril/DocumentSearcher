using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iveonik.Stemmers;
using SearchCore.TextProcessors.Interfaces;

namespace SearchCore.TextProcessors
{
    public class DocumentIndexator
    {
        ITokenizer tokenizer;
        IStemmer stemmer;
        IStopWordsProvider stopWordsProvider;
        IWordCounter wordCounter;

        public DocumentIndexator(
            ITokenizer tokenizer,
            IStemmer stemmer,
            IStopWordsProvider stopWordsProvider,
            IWordCounter wordCounter)
        {
            this.tokenizer = tokenizer;
            this.stemmer = stemmer;
            this.stopWordsProvider = stopWordsProvider;
            this.wordCounter = wordCounter;
        }

        public Dictionary<string, double> ExtractWordFrequency(string documentText)
        {
            string[] words = tokenizer.SplitToWords(documentText);
            ImmutableHashSet<string> stopWords = stopWordsProvider.GetStopWords();
            words = words.Where(w => !stopWords.Contains(w.ToLower())).ToArray();
            for (int i = 0; i < words.Length; ++i)
            {
                words[i] = stemmer.Stem(words[i]);
            }
            int totalCount = words.Length;
            Dictionary<string, double> result = wordCounter.CountWordFrequencies(words);
            return result;
        }
    }
}
