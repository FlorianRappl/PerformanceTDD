using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
    public class Game : BaseViewModel
    {
        #region Members

        Frame[] frames;
        Frame frame;
        ICommand throwCommand;
        Throw currentThrow;

        #endregion

        #region ctor

        public Game()
        {
            currentThrow = new Throw();
            frames = new Frame[10];
            frame = new Frame(1);
            frames[0] = frame;
            throwCommand = new RelayCommand(ThrowCurrent);

            for (var i = 1; i < frames.Length; i++)
            {
                frames[i] = new Frame(i + 1);
                frames[i - 1].Next = frames[i];
                frames[i].Previous = frames[i - 1];
            }
        }

        #endregion

        #region Properties

        public Frame CurrentFrame
        {
            get { return frame; }
            set { frame = value; RaisePropertyChanged(); }
        }

        public Throw CurrentThrow
        {
            get { return currentThrow; }
            set { currentThrow = value; RaisePropertyChanged(); }
        }

        public Boolean Running
        {
            get { return !frame.Finished; }
            set { RaisePropertyChanged(); }
        }

        public Int32 Score
        {
            get { return frames.Sum(m => m.Score); }
        }

        public Frame[] Frames
        {
            get { return frames; }
        }

        public ICommand ThrowCommand
        {
            get { return throwCommand; }
        }

        #endregion

        #region Methods

        public void Add(Throw t)
        {
            frame.Add(t);

            if (frame.Done)
            {
                if (frame.Next != null)
                    CurrentFrame = frame.Next;
                else if (frame.RestPins == 0)
                    frame.RestPins = 10;

                Running = true;
            }

            RaisePropertyChanged("Score");
        }

        public Int32 ScoreAtFrame(Int32 frame)
        {
            frame = Math.Min(Math.Max(1, frame), frames.Length);
            return frames[frame - 1].TotalScore;
        }

        #endregion

        #region Helpers

        void ThrowCurrent()
        {
            Add(currentThrow);
            CurrentThrow = new Throw();
        }

        #endregion
    }
}
