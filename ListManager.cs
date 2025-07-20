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

        /// <summary>
        /// Adds an item to the list
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Removes the item at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            items.RemoveAt(index);
        }

        /// <summary>
        ///  Returns the item at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public T GetAt(int index)
        {
            if (index < 0 || index >= items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return items[index];
        }

        /// <summary>
        ///   // Removes all items from the list
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        // Property to get the current number of items
        public int Count => items.Count;

        // Property to expose the internal list (read-only externally)
        public List<T> Items => items;
    }
}
