using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kleine Klasse");
            Test(() => DummyCallOne(new SmallClass()));
            Console.Write("Kleine Struktur");
            Test(() => DummyCallOne(new SmallStruct()));
            Console.Write("Große Klasse");
            Test(() => DummyCallOne(new BigClass()));
            Console.Write("Große Struktur");
            Test(() => DummyCallOne(new BigStruct()));
        }

        static void Test(Action a)
        {
            var n = 1000000;
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < n; i++)
                a();

            sw.Stop();
            Console.WriteLine(" ... {0} ms", sw.ElapsedMilliseconds.ToString());
        }

        #region Dummy Pipeline für SmallClass

        static void DummyCallOne(SmallClass c)
        {
            DummyCallTwo(c);
        }

        static void DummyCallTwo(SmallClass c)
        {
            DummyCallThree(c);
        }

        static void DummyCallThree(SmallClass c)
        {
            DummyCallFour(c);
        }

        static void DummyCallFour(SmallClass c)
        {
            DummyCallFive(c);
        }

        static void DummyCallFive(SmallClass c)
        {
            Debug.WriteLine(c.ToString());
        }

        #endregion

        #region Dummy Pipeline für SmallStruct

        static void DummyCallOne(SmallStruct c)
        {
            DummyCallTwo(c);
        }

        static void DummyCallTwo(SmallStruct c)
        {
            DummyCallThree(c);
        }

        static void DummyCallThree(SmallStruct c)
        {
            DummyCallFour(c);
        }

        static void DummyCallFour(SmallStruct c)
        {
            DummyCallFive(c);
        }

        static void DummyCallFive(SmallStruct c)
        {
            Debug.WriteLine(c.ToString());
        }

        #endregion

        #region Dummy Pipeline für BigClass

        static void DummyCallOne(BigClass c)
        {
            DummyCallTwo(c);
        }

        static void DummyCallTwo(BigClass c)
        {
            DummyCallThree(c);
        }

        static void DummyCallThree(BigClass c)
        {
            DummyCallFour(c);
        }

        static void DummyCallFour(BigClass c)
        {
            DummyCallFive(c);
        }

        static void DummyCallFive(BigClass c)
        {
            Debug.WriteLine(c.ToString());
        }

        #endregion

        #region Dummy Pipeline für BigStruct

        static void DummyCallOne(BigStruct c)
        {
            DummyCallTwo(c);
        }

        static void DummyCallTwo(BigStruct c)
        {
            DummyCallThree(c);
        }

        static void DummyCallThree(BigStruct c)
        {
            DummyCallFour(c);
        }

        static void DummyCallFour(BigStruct c)
        {
            DummyCallFive(c);
        }

        static void DummyCallFive(BigStruct c)
        {
            Debug.WriteLine(c.ToString());
        }

        #endregion
    }
}
