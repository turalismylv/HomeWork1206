using System;
using System.Collections;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<string> myLinkedList = new CircularLinkedList<string>();
            myLinkedList.AddFirst("Beyler");
            myLinkedList.AddFirst("Mirqubad");
            myLinkedList.AddFirst("Salman");
            myLinkedList.AddFirst("Salman");
            myLinkedList.AddFirst("Salman");
            myLinkedList.AddFirst("Salman");

            //myLinkedList.AddLast("Mirqubad");
            //myLinkedList.AddLast("Salman");
            //myLinkedList.AddLast("Tural");
            //myLinkedList.AddLast("Emil");
            //myLinkedList.AddAfter(myLinkedList.Head, "Mirsaleh");
            //myLinkedList.AddBefore(myLinkedList.Head.Next, "Xasay");
            myLinkedList.Remove("Emil");
            Console.WriteLine("Count=" + myLinkedList.Count);

            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
    class CircularLinkedList<T> : IEnumerable
    {
        public Node<T> Head { get; set; }
        public int Count { get; set; }

        public Node<T> AddFirst(T value)
        {

            if (Head == null)
            {
                var newNode = new Node<T> { Value = value };
                Head = newNode;
                Count++;
                return newNode;
            }
            else
            {
                var oldHead = Head;
                var newNode = new Node<T> { Value = value, Next = oldHead};
                Head = newNode;
                oldHead.Previous = newNode.Next;
                oldHead.Next = newNode.Previous;
                Count++;
                return Head;

            }

        }
        public Node<T> AddLast(T value)
        {
            var lastNode = Head;
            while (!lastNode.Next.Equals(lastNode.Previous))
            {
                lastNode = lastNode.Next;

            }
            var newNode = new Node<T> { Value = value, Previous = lastNode };
            lastNode.Next = newNode;
            Count++;
            return newNode;

        }
        public Node<T> AddAfter(Node<T> node, T value)
        {
            var newNode = new Node<T> { Value = value, Previous = node, Next = node.Next };
            node.Next.Previous = newNode;
            node.Next = newNode;
            Count++;
            return newNode;

        }
        public Node<T> AddBefore(Node<T> node, T value)
        {
            var newNode = new Node<T> { Value = value, Previous = node.Previous, Next = node };
            node.Previous.Next = newNode;
            node.Previous = newNode;
            Count++;
            return newNode;

        }
        public bool Remove(T value)
        {
            var node = Head;
            while (node != null)
            {
                if (node.Value.Equals(value))

                {
                    if (node.Previous == null)
                    {
                        RemoveFirst();
                    }
                    else if (node.Next == null)
                    {
                        RemoveLast();
                    }
                    else
                    {
                        node.Next.Previous = node.Previous;
                        node.Previous.Next = node.Next;
                        Count--;
                        return true;
                    }

                }
                node = node.Next;
            }
            return false;
        }
        public void RemoveFirst()
        {
            var oldHead = Head;
            Head = Head.Next;
            Head.Previous = null;
            Count--;
        }
        public void RemoveLast()
        {
            var lastNode = Head;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }
            lastNode.Previous.Next = null;
            Count--;
        }

        public IEnumerator GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;

            }
        }
    }
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

    }
}