using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5V25
{
    public interface IListManager<T>
    {
        void Add(T item);
        void RemoveAt(int index);
        T GetAt(int index);
        void Clear();
        int Count { get; }
        List<T> Items { get; }
    }
}
