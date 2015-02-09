﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchCore.TextProcessors.Interfaces;

namespace SearchCore.TextProcessors.Implementation
{
    public class WordCounter : IWordCounter
    {
        public Dictionary<string, int> CountWords(string[] text)
        {
            var result = new Dictionary<string, int>();
            foreach (string word in text)
            {
                int currentValue;
                if (!result.TryGetValue(word, out currentValue))
                {
                    currentValue = 0;
                }
                result[word] = currentValue + 1;
            }
            return result;
        }
    }
}
