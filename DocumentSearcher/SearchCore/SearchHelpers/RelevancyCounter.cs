using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCore.SearchHelpers
{
    public class RelevancyCounter
    {
        public double GetDocumentRelevancy(
            Dictionary<string, double> queryFrequencies,
            Dictionary<string, double> documentFrequencies,
            IEnumerable<Dictionary<string, double>> allDocuments)
        {
            double result = 0.0;
            var tfidf = GetTfIdf(documentFrequencies, allDocuments);
            foreach (string keyWord in queryFrequencies.Keys)
            {
                if (tfidf.ContainsKey(keyWord))
                {
                    result += queryFrequencies[keyWord] * tfidf[keyWord];
                }
            }
            result /= GetEuclidianNorm(queryFrequencies);
            result /= GetEuclidianNorm(documentFrequencies);
            return result;
        }

        private double GetEuclidianNorm(Dictionary<string, double> frequencies)
        {
            double result = 0.0;
            foreach (double f in frequencies.Values)
            {
                result += f * f;
            }
            return Math.Sqrt(result);
        }

        private Dictionary<string, double> GetTfIdf(
            Dictionary<string, double> document, 
            IEnumerable<Dictionary<string, double>> allDocuments)
        {
            int documentsCount = allDocuments.Count() + 1;
            var result = new Dictionary<string,double>();
            foreach (string word in document.Keys)
            {
                int docsWithWord = DocumentsWithWord(word, allDocuments);
                double idf = Math.Log10(Convert.ToDouble(documentsCount) / docsWithWord);
                result.Add(word, document[word] * idf);
            }
            return result;
        }

        private int DocumentsWithWord(string word, IEnumerable<Dictionary<string, double>> allDocuments)
        {
            int result = 0;
            foreach (var doc in allDocuments)
            {
                if (doc.ContainsKey(word))
                {
                    result++;
                }
            }
            return result;
        }
    }
}
