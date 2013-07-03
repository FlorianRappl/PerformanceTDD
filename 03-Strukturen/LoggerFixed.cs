using System;
using System.Collections.Generic;
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
    public static class LoggerFixed
    {
        internal static void WriteLine(String message) 
        {
            /*...*/ 
        }

        //Dies ist die richtige Lösung
        public struct LogHelper : IDisposable
        {
            Int32 id;

            public LogHelper(Int32 id)
            {
                this.id = id;
                LoggerClass.WriteLine(String.Format("Entering function {0}", id.ToString()));
            }

            public void Dispose()
            {
                LoggerClass.WriteLine(String.Format("Leaving function {0}", id.ToString()));
            }
        }

        public static LogHelper LogFunction(Int32 id)
        {
            return new LogHelper(id);
        }
    }
}
