using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5V25
{
    public class ListManager<T> : IListManager<T>
    {
        private List<T> items;

        public ListManager()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            items.RemoveAt(index);
        }

        public T GetAt(int index)
        {
            if (index < 0 || index >= items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return items[index];
        }

        public void Clear()
        {
            items.Clear();
        }

        public int Count => items.Count;

        public List<T> Items => items;
    }
}
