using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackStuff
{
    class Stack<T>
    {

        List<T> _list = new List<T>();

        public void Push(T item)
        {
            _list.Add(item);
        }

        public T Pop()
        {

            var p = IsEmpty() ? _list.Last() : default(T);
            _list.Remove(p);
            return p;
        }

        public bool IsEmpty()
        {
            return _list.Count > 0 ;
        }
    }
}
