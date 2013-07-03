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
    public static class LoggerStruct
    {
        internal static void WriteLine(String message) 
        {
            /*...*/ 
        }

        //Ist dies nun besser als class LogHelper?!
        private struct LogHelper : IDisposable
        {
            Int32 id;

            public LogHelper(Int32 id)
            {
                this.id = id;
                LoggerStruct.WriteLine(String.Format("Entering function {0}", id.ToString()));
            }

            public void Dispose()
            {
                LoggerStruct.WriteLine(String.Format("Leaving function {0}", id.ToString()));
            }
        }

        public static IDisposable LogFunction(Int32 id)
        {
            return new LogHelper(id);
        }
    }
}
