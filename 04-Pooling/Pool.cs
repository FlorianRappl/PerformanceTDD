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
    class Pool<T> where T : new()
    {
        Stack<T> _items;
        Object _sync;

        public Pool()
        {
            _items = new Stack<T>();
            _sync = new Object();
        }

        public T Get()
        {
            lock (_sync)
            {
                if (_items.Count == 0)
                    return new T();

                return _items.Pop();
            }
        }

        public void Free(T element)
        {
            lock (_sync)
            {
                _items.Push(element);
            }
        }
    }
}
