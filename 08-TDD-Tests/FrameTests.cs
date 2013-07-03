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
    public class FrameTests
    {
        Frame f;

        [TestInitialize]
        public void Setup()
        {
            f = new Frame();
        }

        [TestMethod]
        public void ScoreNoThrows()
        {
            Assert.AreEqual(10, f.RestPins);
            Assert.AreEqual(0, f.Score);
        }

        [TestMethod]
        public void AddOneThrow()
        {
            var pins = 5;
            f.Add(new Throw(pins));

            Assert.AreEqual(5, f.RestPins);
            Assert.AreEqual(pins, f.Score);
        }

        [TestMethod]
        public void AddTwoThrows()
        {
            var pins1 = 5;
            var pins2 = 4;
            f.Add(new Throw(pins1));
            f.Add(new Throw(pins2));

            Assert.AreEqual(0, f.RestPins);
            Assert.AreEqual(pins1 + pins2, f.Score);
        }

        [TestMethod]
        public void AddThreeThrowsIllegal()
        {
            var pins1 = 5;
            var pins2 = 4;
            var pins3 = 3;
            f.Add(new Throw(pins1));
            f.Add(new Throw(pins2));
            f.Add(new Throw(pins3));

            Assert.AreEqual(0, f.RestPins);
            Assert.AreEqual(pins1 + pins2, f.Score);
        }

        [TestMethod]
        public void AddThreeThrowsLegal()
        {
            var pins1 = 5;
            var pins2 = 5;
            var pins3 = 3;
            f.Add(new Throw(pins1));
            f.Add(new Throw(pins2));
            f.Add(new Throw(pins3));

            Assert.AreEqual(0, f.RestPins);
            Assert.AreEqual(pins1 + pins2 + pins3, f.Score);
        }

        [TestMethod]
        public void AddFourThrowsIllegalAfterTwo()
        {
            var pins1 = 1;
            var pins2 = 1;
            var pins3 = 1;
            var pins4 = 1;
            f.Add(new Throw(pins1));
            f.Add(new Throw(pins2));
            f.Add(new Throw(pins3));
            f.Add(new Throw(pins4));

            Assert.AreEqual(0, f.RestPins);
            Assert.AreEqual(pins1 + pins2, f.Score);
        }

        [TestMethod]
        public void AddFourThrowsIllegalAfterSpare()
        {
            var pins1 = 5;
            var pins2 = 5;
            var pins3 = 1;
            var pins4 = 1;
            f.Add(new Throw(pins1));
            f.Add(new Throw(pins2));
            f.Add(new Throw(pins3));
            f.Add(new Throw(pins4));

            Assert.AreEqual(0, f.RestPins);
            Assert.AreEqual(pins1 + pins2 + pins3, f.Score);
        }

        [TestMethod]
        public void AddFourThrowsIllegalAfterStrike()
        {
            var pins1 = 10;
            var pins2 = 1;
            var pins3 = 1;
            var pins4 = 1;
            f.Add(new Throw(pins1));
            f.Add(new Throw(pins2));
            f.Add(new Throw(pins3));
            f.Add(new Throw(pins4));

            Assert.AreEqual(0, f.RestPins);
            Assert.AreEqual(pins1 + pins2 + pins3, f.Score);
        }
    }
}
