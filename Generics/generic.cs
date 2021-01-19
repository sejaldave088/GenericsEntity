using System;
using System.Collections.Generic;

namespace Generics
{
    class generic<TKey> : IComparer<int>
    {


        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, int> descending = new SortedList<int, int>(new generic<int>());
            descending.Add(1, 1);
            descending.Add(4, 4);
            descending.Add(3, 3);
            descending.Add(2, 2);

            for (int i = 0; i < descending.Count; i++)
            {
                Console.WriteLine("key:{0} & value {1} ", descending.Keys[i], descending.Values[i]);
            }
        }
    }
}