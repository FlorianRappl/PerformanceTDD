using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    public class PoolViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        const String Letters = "abcdefghijklmnopqrstuvwyz";

        ObservableCollection<Package> strings;
        MyCommand command;
        Task evaluation;

        public PoolViewModel()
        {
            command = new MyCommand(Perform);
            strings = new ObservableCollection<Package>();

            for (int i = 0; i < 15; i++)
                strings.Add(Package.Random);
        }

        public ObservableCollection<Package> Strings
        {
            get { return strings; }
        }

        public ICommand Command
        {
            get { return command; }
        }

        public Boolean UseRope
        {
            get;
            set;
        }

        public Int32 Count
        {
            get { return strings.Count; }
            set
            {
                while (value > strings.Count)
                    strings.Add(Package.Random);

                while (value < strings.Count)
                    strings.RemoveAt(strings.Count - 1);

                RaisePropertyChanged();
            }
        }

        void RaisePropertyChanged([CallerMemberName] String name = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        void Perform()
        {
            command.IsExecuting = true;
            evaluation = PerformAsync();
        }

        async Task PerformAsync()
        {
            var strs = strings.Select(m => m.Content).ToArray();
            var result = await Task.Run(() =>
            {
                var s = String.Empty;
                var sw = Stopwatch.StartNew();

                if (UseRope)
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        var rope = Rope.Get();

                        foreach (var str in strs)
                            rope.Append(str);

                        s = rope.Stringify();
                    }
                }
                else
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        s = String.Empty;

                        foreach (var str in strs)
                            s += str;
                    }
                }

                return sw.ElapsedMilliseconds.ToString() + "ms";
            });

            command.IsExecuting = false;
            MessageBox.Show(result);
        }

        public class Package
        {
            static Random ran = new Random();

            public Package ()
	        {
                Content = String.Empty;
	        }

            public Package(String content)
            {
                Content = content;
            }

            public static Package Empty
            {
                get { return new Package(); }
            }

            public static Package Random
            {
                get { return new Package(Randomized()); }
            }

            public String Content
            {
                get;
                set;
            }

            static String Randomized()
            {
                var l = ran.Next(1, 10);
                var chrs = new char[l];

                for (int i = 0; i < l; i++)
                    chrs[i] = Letters[ran.Next(0, Letters.Length)];

                return new String(chrs);
            }
        }

        class MyCommand : ICommand
        {
            Boolean executing;
            Action a;

            public event EventHandler CanExecuteChanged;

            public MyCommand(Action a)
            {
                this.a = a;
            }

            public Boolean IsExecuting
            {
                get { return executing; }
                set
                {
                    executing = value;

                    if (CanExecuteChanged != null)
                        CanExecuteChanged(this, EventArgs.Empty);
                }
            }

            public Boolean CanExecute(Object parameter)
            {
                return !executing;
            }

            public void Execute(Object parameter)
            {
                a();
            }
        }
    }
}
