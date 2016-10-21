using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class Program1
    {
        static void Main1(string[] args)
        {
            LinkedList linkList = new LinkedList();
            linkList.Add(2);
            linkList.Add(4);
            linkList.Add(5);
            linkList.Add(6);
            linkList.ListNodes();
            Console.WriteLine("Retreive 2:" + linkList.Retrieve(2).Data);

            Console.WriteLine("List");
            linkList.ListNodes();
            linkList.Delete(1);
            Console.WriteLine("Deleted 1");
            linkList.ListNodes();
            linkList.Delete(2);
            Console.WriteLine("Deleted 2");
            linkList.ListNodes();

            Console.WriteLine("Is LinkedList Circular ?: " + linkList.IsCircular());

            Console.WriteLine("0th element to last element " + linkList.FindKthToLastElement(0));
            Console.WriteLine("1st element to last element " + linkList.FindKthToLastElement(1));
            Console.WriteLine("2nd element to last element " + linkList.FindKthToLastElement(2));
            Console.WriteLine("3rd element to last element " + linkList.FindKthToLastElement(3));


            linkList.Add(7);
            linkList.Add(10);
            linkList.Add(12);
            linkList.ListNodes();
            linkList.DeleteNode(7);
            Console.WriteLine("DeletedNode 7");
            //linkList.ListNodes();


            LinkedList linkList2 = new LinkedList();
            linkList2.Add(5);
            linkList2.Add(11);

            linkList.MergeNodes(linkList2);
            Console.WriteLine("Merged");
            linkList.ListNodes();

            int kthLastNode = 4;
            Console.WriteLine("Deletet " + kthLastNode + " last node");
            linkList.DeleleteKthToLastElement(kthLastNode);
            linkList.ListNodes();




            /*

            Console.WriteLine("----------------------Queue-------------------");
            Queue q = new Queue();
            Console.WriteLine("Print Q");
            q.ListNodes();
            Console.WriteLine("---------------------EnQueue-------------------");
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.ListNodes();
            Console.WriteLine("---------------------DeQueue-------------------");
            q.Dequeue();
            q.ListNodes();

            Console.WriteLine("---------------------- Circular LinkedList-------------------");
            CircularLinkedList circList = new CircularLinkedList();
            circList.ListNodes();
            circList.Add(1);
            circList.Add(2);
            circList.Add(3);
            circList.Add(4);
            circList.Add(5);
            //circList.ListNodes();
            //Console.WriteLine("Is circular linkedlist Circular? : " + circList.IsCircular());


            Console.WriteLine("---------------------- Tree-------------------");
            Tree<int> tree =
            new Tree<int>(7,
                new Tree<int>(19,
                    new Tree<int>(1),
                    new Tree<int>(12),
                    new Tree<int>(31)),
                new Tree<int>(21),
                new Tree<int>(14,
                    new Tree<int>(23),
                    new Tree<int>(6))
            );

            tree.TraverseDFS();

            Console.WriteLine("----------------------Coin Change-------------------");
            int i, j;
            //int[] coins1 = { 1, 2, 3 };
            int[] coins1 = { 1, 5, 10, 25 };
            int m = coins1.Length / coins1[0];
            Console.Write("\nNumber of Change 1: " + CoinChange.Count(coins1, m, 15));

            //int[] coins2 = { 2, 5, 3, 6 };
            //m = sizeof(coins2) / coins2[0];
            //Console.Write("\nNumber of Change 2: " + CoinChange.Count(coins2, m, 10));



            Console.WriteLine("----------------------Anagram-------------------");
            string[] anag = new string[] { "Silent", "John", "Keith", "Listen", "Eikth", "Ken", "NJho" };
            SortAnagrams.Print(anag);

            Console.WriteLine("-------------Sorted Anagram------------------------");
            string[] anagSorted = SortAnagrams.SortAnagramArray(anag);
            SortAnagrams.Print(anagSorted);

            Console.WriteLine("-------------Reverse String------------------------");
            string reverseStr1 = "Orange";
            string reverseStr2 = "Banana";
            //Console.WriteLine("Reverse1 "  + reverseStr1 + " " + StringManipulations.ReverseString(reverseStr1));
            //Console.WriteLine("Reverse1 " + reverseStr2 + " " + StringManipulations.ReverseString(reverseStr2));
            Console.WriteLine("Reverse2 " + reverseStr1 + " " + StringManipulations.ReverseString2(reverseStr1));
            Console.WriteLine("Reverse2 " + reverseStr2 + " " + StringManipulations.ReverseString2(reverseStr2));

            string compactStr = "aaabbbdeeffaaa";
            Console.WriteLine("Compact string " + compactStr + " " + StringManipulations.CompactString(compactStr));


            Console.WriteLine("-------------Partition Books------------------------");
            Console.WriteLine("-------------PB1------------------------");
            int[] partition1 = {-1000, 100, 100, 100, 100, 100, 100, 100, 100, 100 };  
            //int[] partition1 = { -1000, 1, 1, 1, 1, 1, 1, 1, 1, 1 };  
            //int partN1 = partition1.Length-1 / partition1[1];
            int partN1 = partition1.Length -1 ;
            PartitionDP.Partition(partition1, partN1, 3);

            Console.WriteLine("-------------PB2------------------------");
            int[] partition2 = { -1000, 100, 200, 300, 400, 500, 600, 700, 800, 900 };
            //int[] partition2 = { -1000, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int partN2 = partition2.Length - 1;
            PartitionDP.Partition(partition2, partN2, 3);

            Console.WriteLine("-------------------------------------");
            MultiplicationTable mt = new MultiplicationTable(12);
            mt.DoMultiplication();

            Console.WriteLine("-----------Tic Tac Do-----------------------");
            TicTacDo ttd = new TicTacDo();
            ttd.Move('O', 0, 0);
            ttd.Move('O', 0, 1);
            ttd.Move('X', 0, 2);
            ttd.Move('X', 1, 1);
            ttd.Move('0', 2, 2);
            ttd.Move('0', 1, 2);
            ttd.Move('X', 2, 0);
            ttd.Print();
            Console.WriteLine("Has Winner? " + ttd.HasWinner());

            Console.WriteLine("-----------Maze-----------------------");
            Maze maze = new Maze();
            maze.Print();
            Console.WriteLine("Maze size " + maze.Size());
            Console.Read();

            */

            Console.WriteLine("----------------------IsPalidrom-------------------");

            string polydrome = "sstbastrsbr";

            Console.WriteLine(polydrome + " can be made into a polydrome " + StringManipulations.CanBePalidrome(polydrome));

            Console.Read();
        }
    }
}
