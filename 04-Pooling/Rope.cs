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
    static class Rope
    {
        [ThreadStatic]
        static StringBuilder builder;

        public static StringBuilder Get()
        {
            return builder ?? (builder = new StringBuilder());
        }

        public static String Stringify()
        {
            return builder.Stringify();
        }

        public static String Stringify(this StringBuilder builder)
        {
            var s = builder.ToString();
            builder.Clear();
            return s;
        }
    }
}
