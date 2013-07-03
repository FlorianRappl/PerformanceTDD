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
            CheckRandom();
            RunSimulation();
        }

        static void RunSimulation()
        {
            Simulation sim = new Simulation();
            sim.Run();
            Console.WriteLine("Energy per spin = " + sim.EnergyPerSpin);
            Console.WriteLine("Magnetization per spin = " + sim.MagnetizationPerSpin);
        }

        [Conditional("DEBUG")]
        static void CheckRandom()
        {
            Double sum = 0.0;
            Int32 n = 10000000;
            Rand ran = new Rand();

            for (int i = 0; i < n; i++)
                sum += ran.Next();

            Double avg = sum / n;
            Debug.Assert(Math.Abs(avg - 0.5) <= 0.01, "The random number generator does not work.");
        }
    }
}
