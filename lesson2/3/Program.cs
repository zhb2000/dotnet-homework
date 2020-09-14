using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CSHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new GenericList<int>();
            foreach (int x in new int[] { 1, 2, 3, 4, 5, 6 })
            {
                list.Add(x);
            }
            int minVal = list.Head.Data;
            int maxVal = list.Head.Data;
            int sum = 0;
            list.ForEach(v =>
            {
                minVal = Math.Min(minVal, v);
                maxVal = Math.Max(maxVal, v);
                sum += v;
            });
            Console.WriteLine($"min: {minVal}, max: {maxVal}, sum: {sum}");
        }
    }

    class Node<T>
    {
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    class GenericList<T>
    {
        public GenericList()
        {
            head = tail = null;
        }
        public void Add(T t)
        {
            var node = new Node<T>(t);
            if (tail == null)
            {
                head = tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
        }
        public Node<T> Head { get => head; }
        public void ForEach(Action<T> action)
        {
            for (var p = head; p != null; p = p.Next)
            {
                action(p.Data);
            }
        }

        private Node<T> head;
        private Node<T> tail;
    }
}
