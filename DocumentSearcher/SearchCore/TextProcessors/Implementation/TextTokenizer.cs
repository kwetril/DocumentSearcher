using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SearchCore.TextProcessors.Interfaces;

namespace SearchCore.TextProcessors.Implementation
{
    public class TextTokenizer : ITokenizer
    {
        private static readonly Regex wordsSplitRegex = new Regex(@"[\W\d]");

        public string[] SplitToWords(string text)
        {
            return wordsSplitRegex.Split(text).Where(s => s != string.Empty).ToArray();
        }
    }
}
