using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.CircularLinkedList
{
    //https://navaneethkn.wordpress.com/2009/08/18/circular-linked-list/
    //In a circular doubly linked list, tail node’s next node will be head and head node’s previous node will be tail. 
    //Here is an image taken from wikipedia which visualizes circular linked list.

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Node<T>
    {
        public T Value { get; private set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        internal Node(T item)
        {
            this.Value = item;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class CircularLinkedList<T>
    {
        Node<T> head = null;
        Node<T> tail = null;
        
        int count = 0;

        readonly IEqualityComparer<T> comparer;

        public CircularLinkedList()
        {
            comparer = EqualityComparer<T>.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void AddFirstItem(T item)
        {
            head = new Node<T>(item);
            tail = head;
            head.Next = tail;
            head.Previous = tail;
        }
        
        public void AddLast(T item)
        {
            if (head == null)
                this.AddFirstItem(item);
            else
            {
                Node<T> newNode = new Node<T>(item);
                tail.Next = newNode;
                newNode.Next = head;
                newNode.Previous = tail;
                tail = newNode;
                head.Previous = tail;
            }

            count++;
        }

        public void AddFirst(T item)
        {
            if (head == null)
                this.AddFirstItem(item);
            else 
            {
                Node<T> newNode = new Node<T>(item);
                head.Previous = newNode;
                newNode.Previous = tail;
                newNode.Next = head;
                tail.Next = newNode;
                head = newNode;
            }

            count++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Node<T> Find(T item)
        {
            Node<T> node = FindNode(head, item);
            return node;
        }

        Node<T> FindNode(Node<T> node, T valueToCompare)
        {
            Node<T> result = null;
            if (comparer.Equals(node.Value, valueToCompare))
                result = node;
            else if (result == null && node.Next != head)
                result = FindNode(node.Next, valueToCompare);
            return result;
        }

        public bool Remove(T item)
        {
            Node<T> nodeToRemove = this.Find(item);
            if (nodeToRemove != null)
                return this.RemoveNode(nodeToRemove);

            return false;
        }

        bool RemoveNode(Node<T> nodeToRemove)
        {
            Node<T> previous = nodeToRemove.Previous;
            previous.Next = nodeToRemove.Next;
            nodeToRemove.Next.Previous = nodeToRemove.Previous;

            //if this is head, we need to update the head reference
            if (head == nodeToRemove)
                head = nodeToRemove.Next;
            else if (tail == nodeToRemove)
                tail = tail.Previous;

            --count;
            return true;
                    
        }

        public bool IsCircular()
        {
            Node<T> slower = head;
            Node<T> faster = head.Next;

            while (true)
            {
                if (faster == null || faster.Next == null)
                    return false;
                else if (faster == slower || faster.Next == slower)
                    return true;
                else
                {
                    faster = faster.Next;
                    slower = slower.Next;
                }
            }
        }

        public int Count { get { return count; } }

        public Node<T> Tail { get { return tail; } }

        /// <summary>
        /// Gets the head node. Returns NULL if no node found
        /// </summary>
        public Node<T> Head { get { return head; } }
    }

   

}
