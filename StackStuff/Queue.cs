using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackStuff
{
    class Queue<T>
    {
        List<T> _list = new List<T>();

        public void Enqueue(T item)
        {
            _list.Add(item);
        }
        public T Dequeue()
        {
            if (_list.Count == 0)
                return default;

            var x = _list.First();
            _list.Remove(x);
            return x;
        }
        public int Length()
        {
            return _list.Count;
        }

        public List<T> GetList()
        {
            return _list;
        }

    }
}
