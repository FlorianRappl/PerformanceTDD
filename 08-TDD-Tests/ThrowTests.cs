using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    public class ThrowTests
    {
        Throw t;

        [TestInitialize]
        public void Setup()
        {
            t = new Throw();
        }

        [TestMethod]
        public void ValueCorrect()
        {
            t.Pins = 9;
            Assert.AreEqual(9, t.Pins);
        }

        [TestMethod]
        public void LowerRangeValue()
        {
            t.Pins = -1;
            Assert.AreEqual(0, t.Pins);
        }

        [TestMethod]
        public void UpperRangeValue()
        {
            t.Pins = 11;
            Assert.AreEqual(0, t.Pins);
        }

        [TestMethod]
        public void IsStrikeCorrect()
        {
            t.Pins = 10;
            Assert.AreEqual(10, t.Pins);
            Assert.IsTrue(t.IsStrike);
        }
    }
}
