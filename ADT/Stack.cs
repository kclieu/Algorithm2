using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    /// <summary>
    /// 
    /// </summary>
    public class Node
    {
        public Node Next;
        public object Data;
    }

    /// <summary>
    /// 
    /// </summary>
    public class Stack
    {
        /// <summary>
        /// 
        /// </summary>
        Node Top;
        int size;

        /// <summary>
        /// 
        /// </summary>
        public Stack(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public void Push(object content)
        {
            Node n = new Node { Data = content };
            n.Next = Top;
            Top = n;
            size++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Pop()
        {
            if (Top != null)
            {
                size--;
               
                object item = Top.Data;
                Top = Top.Next; 
                return item;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Peek()
        {
            return Top.Data;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            Node current = Top;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
