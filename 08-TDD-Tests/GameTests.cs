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
    public class GameTests
    {
        Game g;

        [TestInitialize]
        public void Setup()
        {
            g = new Game();
        }

        [TestMethod]
        public void OneThrow()
        {
            var pins = 5;
            g.Add(new Throw(pins));

            Assert.AreEqual(pins, g.Score);
            Assert.AreEqual(1, g.CurrentFrame.Number);
            Assert.IsTrue(g.Running);
        }

        [TestMethod]
        public void TwoThrowsNoMark()
        {
            var pins1 = 5;
            var pins2 = 4;
            g.Add(new Throw(pins1));
            g.Add(new Throw(pins2));

            Assert.AreEqual(pins1 + pins2, g.Score);
            Assert.AreEqual(2, g.CurrentFrame.Number);
            Assert.IsTrue(g.Running);
        }

        [TestMethod]
        public void FourThrowsNoMark()
        {
            var pins1 = 5;
            var pins2 = 4;
            var pins3 = 7;
            var pins4 = 2;
            g.Add(new Throw(pins1));
            g.Add(new Throw(pins2));
            g.Add(new Throw(pins3));
            g.Add(new Throw(pins4));

            Assert.AreEqual(pins1 + pins2 + pins3 + pins4, g.Score);

            Assert.AreEqual(pins1 + pins2, g.Frames[0].Score);
            Assert.AreEqual(pins3 + pins4, g.Frames[1].Score);

            Assert.AreEqual(pins1 + pins2, g.ScoreAtFrame(1));
            Assert.AreEqual(pins1 + pins2 + pins3 + pins4, g.ScoreAtFrame(2));

            Assert.AreEqual(3, g.CurrentFrame.Number);
            Assert.IsTrue(g.Running);
        }

        [TestMethod]
        public void SimpleFrameAfterSpare()
        {
            var pins1 = 3;
            var pins2 = 7;
            var pins3 = 3;
            var pins4 = 2;
            g.Add(new Throw(pins1));
            g.Add(new Throw(pins2));
            g.Add(new Throw(pins3));
            g.Add(new Throw(pins4));

            Assert.AreEqual(pins1 + pins2 + pins3, g.ScoreAtFrame(1));
            Assert.AreEqual(pins1 + pins2 + pins3 + pins3 + pins4, g.Score);

            Assert.AreEqual(3, g.CurrentFrame.Number);
            Assert.IsTrue(g.Running);
        }

        [TestMethod]
        public void SimpleFrameAfterStrike()
        {
            var pins1 = 10;
            var pins2 = 7;
            var pins3 = 3;
            var pins4 = 2;
            g.Add(new Throw(pins1));
            g.Add(new Throw(pins2));
            g.Add(new Throw(pins3));
            g.Add(new Throw(pins4));

            Assert.AreEqual(pins1 + pins2 + pins3, g.ScoreAtFrame(1));
            Assert.AreEqual(pins1 + pins2 + pins3 + pins2 + pins3 + pins4, g.ScoreAtFrame(2));

            Assert.AreEqual(pins1 + pins2 + pins3 + pins2 + pins3 + pins4 + pins4, g.Score);

            Assert.AreEqual(3, g.CurrentFrame.Number);
            Assert.IsTrue(g.Running);
        }

        [TestMethod]
        public void SimpleStrike()
        {
            var pins1 = 10;
            var pins2 = 3;
            var pins3 = 6;
            g.Add(new Throw(pins1));
            g.Add(new Throw(pins2));
            g.Add(new Throw(pins3));

            Assert.AreEqual(19, g.ScoreAtFrame(1));
            Assert.AreEqual(28, g.Score);
            Assert.AreEqual(3, g.CurrentFrame.Number);
            Assert.IsTrue(g.Running);
        }

        [TestMethod]
        public void PerfectGame()
        {
            for (int i = 0; i < 12; i++)
                g.Add(new Throw(10));

            Assert.AreEqual(300, g.Score);
            Assert.AreEqual(10, g.CurrentFrame.Number);
            Assert.IsFalse(g.Running);
        }

        [TestMethod]
        public void EndOfArray()
        {
            for (int i = 0; i < 9; i++)
            {
                g.Add(new Throw(0));
                g.Add(new Throw(0));
            }

            Assert.AreEqual(10, g.CurrentFrame.Number);

            g.Add(new Throw(2));
            g.Add(new Throw(8));
            g.Add(new Throw(10));

            Assert.AreEqual(20, g.Score);
            Assert.AreEqual(10, g.CurrentFrame.Number);
            Assert.IsFalse(g.Running);
        }

        [TestMethod]
        public void SampleGame()
        {
            g.Add(new Throw(1));
            g.Add(new Throw(4));
            g.Add(new Throw(4));
            g.Add(new Throw(5));
            g.Add(new Throw(6));
            g.Add(new Throw(4));
            g.Add(new Throw(5));
            g.Add(new Throw(5));
            g.Add(new Throw(10));
            g.Add(new Throw(0));
            g.Add(new Throw(1));
            g.Add(new Throw(7));
            g.Add(new Throw(3));
            g.Add(new Throw(6));
            g.Add(new Throw(4));
            g.Add(new Throw(10));
            g.Add(new Throw(2));
            g.Add(new Throw(8));
            g.Add(new Throw(6));

            Assert.AreEqual(133, g.Score);
            Assert.AreEqual(10, g.CurrentFrame.Number);
            Assert.IsFalse(g.Running);
        }

        [TestMethod]
        public void HeartBreak()
        {
            for (int i = 0; i < 11; i++)
                g.Add(new Throw(10));

            g.Add(new Throw(9));

            Assert.AreEqual(299, g.Score);
            Assert.AreEqual(10, g.CurrentFrame.Number);
            Assert.IsFalse(g.Running);
        }
    }
}
