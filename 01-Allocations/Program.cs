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
            SymbolList list = new SymbolList();
            list.LoadDefaultSymbols();
            var symbol = String.Empty;

            while (true)
            {
                Console.Write("Bitte Symbol eingeben: ");
                symbol = Console.ReadLine();

                if (String.IsNullOrEmpty(symbol))
                    break;

                Console.Write("Mit Linq");
                Test(() => list.FindMatchingSymbolLinq(symbol));
                Console.Write("Ohne Linq");
                Test(() => list.FindMatchingSymbolFixed(symbol));
            }
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
