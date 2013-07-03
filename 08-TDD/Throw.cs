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
    public class Throw : BaseViewModel
    {
        Int32 pins;

        public Throw()
        {
            Pins = 0;
        }

        public Throw(Int32 pins)
        {
            Pins = pins;
        }

        public Int32 Pins
        {
            get { return pins; }
            set
            {
                if (value >= 0 && value <= 10)
                    pins = value;

                RaisePropertyChanged();
            }
        }

        public Boolean IsStrike
        {
            get { return pins == 10; }
        }
    }
}
