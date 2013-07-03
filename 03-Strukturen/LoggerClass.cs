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
    public static class LoggerClass
    {
        internal static void WriteLine(String message) 
        {
            /*...*/ 
        }

        //LogHelper ist sehr klein ... --> struct verwenden?
        private class LogHelper : IDisposable
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

        public static IDisposable LogFunction(Int32 id)
        {
            return new LogHelper(id);
        }
    }
}
