using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {

            IList<int> ll = new IList<int>();
            ll.Add(10);
            ll.Add(11);
            ll.Add(12);

            ll.Remove(1);


            Console.WriteLine(ll.Contains(11));

            foreach (var item in ll)
            {
                Console.WriteLine(item);
            }
            

           
        }
    }
    class IList<T> : IEnumerable
    {
        public int Count { get; set; }
        public int Capacity { get; set; }
        private T[] _arr;

        public IList()
        {
            Capacity = 4;
            _arr = new T[Capacity];
        }
        public IList(int capacity)
        {
            Capacity = capacity;
            _arr = new T[capacity];
        }
        public void Add(T item)
        {

            _arr[Count] = item;
            Count++;

        }
        public void Remove(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _arr[i] = _arr[i + 1];

            }
            _arr[Count - 1] = default(T);
            Count--;
        }
        
        public bool Contains(T value)
        {
            for (int i = 0; i < Count; i++)
            {

                if (_arr[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
               
                yield return _arr[i];
            }
           
        }
    }
}
