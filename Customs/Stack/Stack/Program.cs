using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Stack<string> lift = new Stack<string>();
            lift.Push("Tural");
            lift.Push("Emil");
            lift.Push("Salman");
            lift.Push("Ceyhun");
            lift.Push("Xasay");

            lift.Pop();

            Console.WriteLine("Peek "+ lift.Peek());

            foreach (var item in lift)
            {
                Console.WriteLine(item);
            }
            

            
        }
    }

    class Stack<T> : IEnumerable    
    {

        public int Count { get; set; }
        public int Capacity { get; set; }
        private T[] _arr;

        public Stack()
        {   
            Capacity = 4;
            _arr = new T[Capacity];

        }

        public Stack(int capacity)
        {
            Capacity = capacity;
            _arr = new T[capacity];
        }

        public void Push(T item)
        {
            

            if (Count == Capacity)
            {
                Capacity = Capacity * 2;
                Array.Resize(ref _arr, Capacity);
                
            }
            
            _arr[Count] = item;
            Count++;
           



        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new EntryPointNotFoundException();
            }
            return _arr[Count-1];


        }
        public T Pop()
        {
            
            if (Count == 0)
            {
                throw new EntryPointNotFoundException();
            }
            for (int i = 0; i > Count; i++)
            {
                _arr[i] = _arr[i +1];
            }
            Count--;
            return _arr[Count];


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
