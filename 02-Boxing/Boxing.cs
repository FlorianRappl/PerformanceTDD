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
    class Boxing
    {
        #region Members

        String name;
        Color color;

        #endregion

        #region Probleme

        public void LogProblem1(Int32 id, Int32 size)
        {
            var s = String.Format("{0}:{1}", id, size);
            Logger.WriteLine(s);
        }

        public void LogProblem2(Int32 id, Int32 size)
        {
            var s = id.ToString() + ':' + size.ToString();
            Logger.WriteLine(s);
        }

        //public override Int32 GetHashCode()
        public Int32 GetHashCodeProblem()
        {
            return name.GetHashCode() ^ color.GetHashCode();
        }

        #endregion

        #region Lösungen

        public void LogFixed1(Int32 id, Int32 size)
        {
            var s = String.Format("{0}:{1}", id.ToString(), size.ToString());
            Logger.WriteLine(s);
        }

        public void LogFixed2(Int32 id, Int32 size)
        {
            var s = id.ToString() + ":" + size.ToString();
            Logger.WriteLine(s);
        }
        
        //public override Int32 GetHashCode()
        public Int32 GetHashCodeFixed()
        {
            return name.GetHashCode() ^ ((Int32)color).GetHashCode();
        }

        #endregion
    }
}
