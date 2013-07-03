using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace Performance
{
    [TestClass]
    public class ExampleTests
    {
        String globalString;

        [TestInitialize]
        public void Setup()
        {
            //Will be called in the beginning (before each test)
            globalString = "Hallo";
        }

        [TestCleanup]
        public void Cleanup()
        {
            //Will be called in the end (after each test)
            globalString = null;
        }

        [TestMethod]
        public void StringConcatAddingTwoStringsMatch()
        {
            var string2 = "There";
            var result = String.Concat(globalString, string2);
            Assert.AreEqual("HalloThere", result);
        }

        [TestMethod]
        public void StringRemoveLeadingLetter()
        {
            var result = globalString.Remove(0, 1);
            Assert.AreEqual("allo", result);
        }

        [TestMethod]
        public void StringEqualOrdinalIgnoreCaseCompareTwoEqualStrings()
        {
            var string2 = "hallo";
            var result = String.Equals(globalString, string2, StringComparison.OrdinalIgnoreCase);
            Assert.IsTrue(result);
        }
    }
}
