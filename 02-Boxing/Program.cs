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
            var box = new Boxing();
            Console.Write("Mit Boxing (1)");
            Test(() => box.LogProblem1(1, 1));
            Console.Write("Ohne Boxing (1)");
            Test(() => box.LogFixed1(1, 1));
            Console.Write("Mit Boxing (2)");
            Test(() => box.LogProblem2(1, 1));
            Console.Write("Ohne Boxing (2)");
            Test(() => box.LogFixed2(1, 1));
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
    }
}
