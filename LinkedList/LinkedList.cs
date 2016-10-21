using System;
using System.Collections;
using System.Collections.Generic;

namespace Algos
{
    public class LinkedList
    {
        public class Node
        {
            public int Data;
            public Node Next;
        }

        public int size;
        public int Count
        {
            get { return size; }
        }

        public Node Head;
        private Node Current;

        /// <summary>
        /// 
        /// </summary>
        public LinkedList()
        {
            size = 0;
            Head = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public void Add(int content)
        {
            size++;
            Node node = new Node { Data = content };

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Current.Next = node;
            }
            Current = node;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ListNodes()
        {
            Node tempNode = Head;

            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Data);
                tempNode = tempNode.Next;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Node Retrieve(int position)
        {
            int currPos = 0;
            Node tempNode = Head;
            Node retNode = null;

            while (tempNode != null)
            {
                if (currPos == position - 1)
                {
                    retNode = tempNode;
                    break;
                }
                currPos++;
                tempNode = tempNode.Next;
            }

            return retNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool DeleteNode(object val)
        {
            Node tempNode = Head;
            Node lastNode = null;

            while (tempNode != null)
            {
                if ((int)tempNode.Data == (int)val)
                {
                    size--;
                    lastNode.Next = tempNode.Next;
                    //tempNode = tempNode.Next;
                    return true;
                }
                else
                {
                    lastNode = tempNode;
                    tempNode = tempNode.Next;
                }
            }

            return false;            
        }

        //CCI 2.3
        //Implement an algorithm to delete a node in the middle of a singly linked list, given
        //only access to that node. pg77

        //In this problem, assume you are not given access to the head of the linked list. You only have
        //access to that node. The solution is simply to copy the data from the next node over to
        //the current node, and then to delete the next node.
        public bool DeleteNode(Node n)
        {
            if (n == null || n.Next == null)
                return false; //faiure

            Node next = n.Next;
            n.Data = next.Data;
            n.Next = next.Next;

            return true;
        }
        //Note that this problem cannot be solved if the node to be deleted is the last node in
        //the linked list. That's ok—your interviewer wants you to point that out, and to discuss
        //how to handle this case. You could, for example, consider marking the node as dummy.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool Delete(int position)
        {
            if (position == 1)
            {
                if (position == size)
                {
                    size--;
                    Current = null;
                    Head = Head;
                    return true;

                }
                else if (position > size)
                {

                    return false;
                }
                else
                {
                    size--;
                    Head = Head.Next;
                    return true;
                }
            }

            if (position > 1 && position <= size)
            {
                Node tempNode = Head;
                Node lastNode = null;
                int count = 0;

                while (tempNode != null)
                {
                    if (count == position - 1)
                    {
                        size--;
                        lastNode.Next = tempNode.Next;
                        return true;
                    }
                    count++;
                    lastNode = tempNode;
                    tempNode = tempNode.Next;
                }
            }
            return false;
        }


        //CCI p184 O(n)
        //Write code to remove duplicates from an unsorted linked list.
        public void DeleteDuplicates1(Node n)
        {
            Hashtable table = new Hashtable();
            Node previous = null;
            while(n != null)
            {
                if(table.ContainsKey(n.Data))
                    previous.Next = n.Next;
                else
                {
                    table.Add(n.Data, true);
                    previous = n;
                }
                n = n.Next;
            }
        }

        //Write code to remove duplicates from an unsorted linked list.
        //How would you solve this problem if a temporary buffer is not allowed?
        //If we don't have a buffer, we can iterate with two pointers: current which iterates
        //through the linked list, and runner which checks all subsequent nodes for duplicates.
        //Code runs in O(1) space but O(n2) time
        public void DeleteDuplicates2()
        {
            Node head = Head;

            if (head == null)
                return;

            Node current = head;
            while (current != null)
            {
                //Removes all future nodes that have the same value
                Node runner = current;
                while (runner.Next != null)
                {
                    if (runner.Next.Data == current.Data)
                        runner.Next = runner.Next.Next;
                    else
                        runner = runner.Next;
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool DeleleteKthToLastElement(int k)
        {
            //Cannot use length of List for this operation
            Node current = Head;
            Node skipAhead = Head;

            for (int i = 1; i <= k; i++)
            {
                skipAhead = skipAhead.Next;
            }

            while (skipAhead.Next != null)
            {
                skipAhead = skipAhead.Next;
                current = current.Next;
            }

            current.Next = current.Next.Next;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCircular()
        {
            Node slower = Head;
            Node faster = Head.Next;

            while (true)
            {
                //if faster encounters NULL element
                if (faster == null || faster.Next == null)
                {
                    return false;
                }
                else if (faster == slower || faster.Next == slower)
                {
                    return true;
                }
                else
                {
                    //Advance the pointers
                    slower = slower.Next;
                    faster = faster.Next;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public object FindKthToLastElement(int k)
        {
            int position = size - k;
            int counter = 1;

            Node currentNode = Head;

            if (position <= 0)
                return null;

            while (counter != position)
            {
                counter++;
                currentNode = currentNode.Next;
            }

            if (currentNode != null)
            {
                return currentNode.Data;
            }

            return null;
        }


        //2.2 CCI Implement an algorithm to find the kth to last element of a singly linked list.pg77
        //where size is not known
        //O(n) time and O(1) space
        public Node FindKthToLast(Node head, int k)
        {
            if (k <= 0)
                return null;

            Node p1 = head;
            Node p2 = head;

            //Move p2 forward k nodes into the list
            for (int i = 0; i < k - 1; i++)
            {
                if (p2 == null) return null;  //Error check
                p2 = p2.Next;
            }

            if (p2 == null) return null;

            //Now move p1 and p2 at the same speed.  When p2 hits the end, p1 will be at the right element
            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public void MergeNodes(LinkedList list)
        {
            Node ptr1 = Head;
            Node ptr2 = Head.Next ;

            while (ptr1 != null & list.Head != null)
            {
                //while ((int)ptr1.Next.Data < (int)list.head.Data)
                //    ptr1 = ptr1.Next;

                if ((int)ptr1.Data < (int)list.Head.Data)
                {
                    //ptr1 = head.Next;
                    Head.Next = list.Head;
                    ptr1 = list.Head;

                    list.Head = list.Head.Next ;
                    Head.Next.Next = ptr2;
                    //ptr1 = Head;
                    //ptr1 = Head;
                    ptr2 = Head.Next;
                }
                else {
                    ptr1 = ptr1.Next;
                
                }
            }
        }

        //CCI 2.4
        //Write code to partition a linked list around a value x, such that all nodes less than x
        //come before all nodes greater than or equal to x.
        /* Pass in the head of the linked list and the value to partition
        around */
        public Node Partition(Node node, int x)
        {
            Node beforeStart = null;
            Node afterStart = null;

            //Partition list
            while (node != null)
            {
                Node next = node.Next;

                if (node.Data < x)
                {
                    //Insert node into start of before list
                    node.Next = beforeStart;
                    beforeStart = node;
                }
                else 
                { 
                    //Insert node into fornt of after list
                    node.Next = afterStart;
                    afterStart = node;
                }

                node = next;
            }

            //Merge before list and after list
            if (beforeStart == null)
                return afterStart;

            //Find end of before list and merge the lists
            Node head = beforeStart;
            while (beforeStart.Next != null)
            {
                beforeStart = beforeStart.Next;
            }

            beforeStart.Next = afterStart;

            return head;
        }

        //CCI 2.6 Given a circular linked list, implement an algorithm which returns the node at the
        //beginning of the loop.

        //CCI 2.7 Implement a function to check if a linked list is a palindrome
        public bool IsPalidrome(Node head)
        {
            Node fast = head;
            Node slow = head;

            /* Push elements from first half of linked list onto stack. When
            fast runner (which is moving at 2x speed) reaches the end of
            the linked list, then we know we're at the middle */
            
            Stack<int> stack = new Stack<int>();

            while (fast != null && fast.Next != null)
            {
                stack.Push(slow.Data);
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            /* Has odd number of elements, so skip the middle element */
            if (fast != null)
            {
                slow = slow.Next;
            }

            while (slow != null)
            {
                int top = stack.Pop();
                /* If values are different, then it's not a palindrome */
                if (top != slow.Data)
                {
                    return false;
                }

                slow = slow.Next;
            }

            return true;
        }
    }

    public class ProgramLinkedList
    {
        static void ProgramLinkedListMain(string[] args)
        {
            LinkedList linkList = new LinkedList();
            linkList.Add(10);
            linkList.Add(12);
            linkList.Add(5);
            linkList.Add(2);
            linkList.Add(1);

            //linkList.Add(2);
            linkList.ListNodes();
            Console.WriteLine("Retreive 2:" + linkList.Retrieve(2).Data);


            Algos.LinkedList.Node head = linkList.Head;
            Console.WriteLine("Is Palidrome " + linkList.IsPalidrome(head));

            Algos.LinkedList.Node  head1 = linkList.Partition(head, 3);
            Algos.LinkedList.Node curr = head1;
            while (curr != null)
            {
                Console.Write(curr.Data + "  ");
                curr = curr.Next;
            }
            Console.WriteLine("The End");

            //linkList.ListNodes();
            Console.Read();
        }
    }
}
