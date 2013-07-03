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
    public class Frame : BaseViewModel
    {
        #region Members

        List<Throw> throws;
        List<Throw> bonus;
        Frame previous;
        Frame next;
        Int32 restpins;

        #endregion

        #region ctor

        public Frame()
        {
            restpins = 10;
            throws = new List<Throw>();
            bonus = new List<Throw>();
        }

        public Frame(Int32 number)
            : this()
        {
            Number = number;
        }

        #endregion

        #region Properties

        public Int32 Number
        {
            get;
            private set;
        }

        public Int32 RestPins
        {
            get { return restpins; }
            set { restpins = value; RaisePropertyChanged(); }
        }

        public Int32 Score
        {
            get { return throws.Sum(m => m.Pins) + bonus.Sum(m => m.Pins); }
        }

        public String Throw1
        {
            get { return throws.Count < 1 ? String.Empty : (throws[0].IsStrike ? "/" : throws[0].Pins.ToString()); }
        }

        public String Throw2
        {
            get { return throws.Count < 2 ? String.Empty : (LocalScore == 10 ? "-" : throws[1].Pins.ToString()); }
        }

        public Int32 TotalScore
        {
            get
            {
                var sum = Score;
                var nxt = previous;

                while (nxt != null)
                {
                    sum += nxt.Score;
                    nxt = nxt.previous;
                }

                return sum;
            }
        }

        public Int32 LocalScore
        {
            get { return throws.Sum(m => m.Pins); }
        }

        public Int32 Throws
        {
            get { return throws.Count; }
        }

        public Boolean CanBonus
        {
            get { return LocalScore == 10; }
        }

        public Boolean Finished
        {
            get { return throws.Count + bonus.Count == (CanBonus ? 3 : 2); }
        }

        public Boolean Done
        {
            get { return throws.Count == 2 || (throws.Count == 1 && throws[0].IsStrike); }
        }

        public Frame Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public Frame Next
        {
            get { return next; }
            set { next = value; }
        }

        #endregion

        #region Methods

        public void Add(Throw t)
        {
            if (!Finished)
            {
                if (!CanBonus)
                {
                    throws.Add(t);

                    if (throws.Count == 1)
                        RestPins -= t.Pins;
                    else
                        RestPins = 0;
                }
                else
                {
                    bonus.Add(t);
                }

                RaisePropertyChanged("Score");
                RaisePropertyChanged("LocalScore");
                RaisePropertyChanged("TotalScore");
                RaisePropertyChanged("Throw1");
                RaisePropertyChanged("Throw2");

                if (previous != null)
                    previous.Add(t);
            }
        }

        #endregion
    }
}
