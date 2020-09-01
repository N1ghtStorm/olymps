using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SingleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new SingleLinkedList<string>("0");

            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.PrintAllNodes();

            list.InvertList();

            list.PrintAllNodes();

            var cats = new SingleLinkedList<Cat>(new Cat { Name = "Barsik" })
            {
                new Cat { Name = "Murka" },
                new Cat { Name = "Krisy" },
                new Cat { Name = "Spenser" }
            };

            var names = cats.Select(x => x.Name).ToList();
            names.ForEach(x => Console.WriteLine(x));
        }
    }

    public class Cat
    {
        public string Name { get; set; }
    }

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Current { get; set; }
    }

    public class SingleLinkedList<T> : IEnumerable<T> where T : class
    {
        public Node<T> Head { get; set; }

        public SingleLinkedList(T head)
        {
            Head = new Node<T>();
            Head.Current = head;
        }

        public void Add(T t)
        {
            var toAdd = new Node<T>
            {
                Current = t
            };

            var current = Head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = toAdd;
        }


        public void InvertList()
        {
            Node<T> previous = null;
            var current = Head;

            while (current.Next != null)
            {
                var temp_next = current.Next;
                current.Next = previous;
                previous = current;
                current = temp_next;
            }

            Head = previous;
        }

        public void PrintAllNodes()
        {
            Node<T> current = Head;

            while (current != null)
            {
                Console.WriteLine(current.Current);
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            using var singleLLEnumerator = new SingleLinkedListEnumerator<T>(this);
            return singleLLEnumerator;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class SingleLinkedListEnumerator<T> : IEnumerator<T> where T : class
    {
        public SingleLinkedList<T> SingleLinkedList { get; set; }
        public object Current => Current;

        T IEnumerator<T>.Current => SingleLinkedList.Head.Current;

        public SingleLinkedListEnumerator(SingleLinkedList<T> list)
        {
            SingleLinkedList = list;
        }

        public bool MoveNext()
        {
            if (SingleLinkedList.Head.Next != null)
            {
                SingleLinkedList.Head = SingleLinkedList.Head.Next;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}

