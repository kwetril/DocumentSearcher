using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCore.TextProcessors.Implementation;

namespace TestSearchCore
{
    [TestClass]
    public class TestTextTokenizer
    {
        public TestTextTokenizer()
        {
        }

        [TestMethod]
        public void TestSplitToWords()
        {
            TextTokenizer tokenizer = new TextTokenizer();

            string text1 = "Я, ты, он, ,она - оно! Они: их 123, им?";
            string[] expected1 = new string[] { "Я", "ты", "он", "она", "оно", "Они", "их", "им" };
            string[] result1 = tokenizer.SplitToWords(text1);
            CollectionAssert.AreEqual(result1, expected1);
        }
    }
}
