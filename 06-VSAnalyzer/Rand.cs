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
    //Simple MWC implementation
    sealed class Rand
    {
        UInt32 m_z;
        UInt32 m_w;

        public Rand()
            : this(DateTime.Now.Ticks)
        {
        }

        public Rand(Int64 seed)
        {
            m_z = (UInt32)(seed % 4294967296);
            m_w = (UInt32)seed >> 16;
        }

        Int64 GetUint()
        {
            m_z = 36969 * (m_z & 65535) + (m_z >> 16);
            m_w = 18000 * (m_w & 65535) + (m_w >> 16);
            return (m_z << 16) + m_w;
        }

        public Double Next()
        {
            var u = GetUint();
            return (u + 1.0) * 2.328306435454494e-10;
        }

        public Int32 Discrete(Int32 inclusiveMin, Int32 exclusiveMax)
        {
            var d = (int)Math.Floor((exclusiveMax - inclusiveMin) * Next() + inclusiveMin);
            return Math.Min(d, exclusiveMax - 1);
        }
    }
}
