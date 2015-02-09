using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCore.TextProcessors.Implementation;

namespace TestSearchCore
{
    [TestClass]
    public class TestWordCounter
    {
        public TestWordCounter()
        {
        }

        [TestMethod]
        public void TestCountWords()
        {
            var wordCounter = new WordCounter();

            string[] text1 = new string[] { 
                "дом",
                "стол",
                "окно",
                "стена",
                "дом",
                "пол",
                "подоконник",
                "стена",
                "стена",
                "стена",
                "дом",
                "дом",
                "стул",
                "дом",
                "окно"
            };
            var expected1 = new Dictionary<string, int> ();
            expected1.Add("дом", 5);
            expected1.Add("стол", 1);
            expected1.Add("окно", 2);
            expected1.Add("стена", 4);
            expected1.Add("пол", 1);
            expected1.Add("подоконник", 1);
            expected1.Add("стул", 1);
            var result1 = wordCounter.CountWords(text1);

            Assert.AreEqual<int>(result1.Count, expected1.Count);
            foreach (string word in expected1.Keys)
            {
                Assert.AreEqual<int>(result1[word], expected1[word]);
            }
        }
    }
}
