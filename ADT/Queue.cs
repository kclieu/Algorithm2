using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos1
{
    //http://algs4.cs.princeton.edu/13stacks/Queue.java.html
    /// <summary>
    /// /
    /// </summary>
    public class Queue<T>
    {
        /// <summary>
        /// 
        /// </summary>
        private class Node<T>
        {
            public T Data;
            public Node<T> Next;
        }

        /// <summary>
        /// 
        /// </summary>
        private Node<T> First;
        private Node<T> Last;
        private int size;

        /// <summary>
        /// 
        /// </summary>
        public Queue()
        {
            First = null;
            Last = null;
            size = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return First == null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  int Size()
        { 
            return size; 
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Queue underflow");
            return First.Data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue1(T item)
        {
            Node<T> node = new Node<T> { Data = item, Next = null };

            if(First == null)
            {
                Last = node;
                First = Last;
            }
            else
            {
                Last.Next = node;
                Last = Last.Next;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            Node<T> oldLast = Last;
            Last = new Node<T> { Data = item, Next = null };

            if (IsEmpty())
                First = Last;
            else
                oldLast.Next = Last;
            size++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty()) throw new Exception("Queue underflow");

            T data = First.Data;
            First = First.Next;
            size--;

            if (IsEmpty()) 
                Last = null;

            return data;
    
        }

        /// <summary>
        /// 
        /// </summary>
        public void ListNodes()
        {
            Node<T> current = First;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
