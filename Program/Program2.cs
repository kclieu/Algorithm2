using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class Program2
    {
        static void Main2(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Print();

            Console.WriteLine("Stack peek " + stack.Peek());
            Console.WriteLine("Stack pop " + stack.Pop());
            Console.WriteLine("Stack pop " + stack.Pop());
            //stack.Pop();
            //stack.Print();
            Console.WriteLine("Stack peek " + stack.Peek());
            stack.Print();


            //Console.WriteLine("Binary Tree ");
            //BinaryTree<int> binaryTree =
            //new BinaryTree<int>(14,
            //        new BinaryTree<int>(19,
            //              new BinaryTree<int>(23),
            //              new BinaryTree<int>(6,
            //                      new BinaryTree<int>(10),
            //                      new BinaryTree<int>(21))),
            //        new BinaryTree<int>(15,
            //              new BinaryTree<int>(3),
            //              null));

            //binaryTree.PrintInOrder();

            Console.WriteLine("\n\nHeap Sort");

            int[] SortArray = {34, 380, 944, 594, 783, 584, 550, 665, 721, 819, 285, 344, 503, 807, 491, 623, 845, 300, 11};
            HeapSort hs = new HeapSort();
            hs.Sort(SortArray);

            for (int i = 0; i < SortArray.Length; i++)
            {
                Console.Write(SortArray[i] + " ");
            }

            /*

            Console.WriteLine("\n\nInsertion Sort");
            int[] InsertionSortArray = { 34, 380, 944, 594, 783, 584, 550, 665, 721, 819, 285, 344, 503, 807, 491, 623, 845, 300, 11, 500 };
            InsertionSort.Sort(InsertionSortArray);
            for (int i = 0; i < InsertionSortArray.Length; i++)
            {
                Console.Write(InsertionSortArray[i] + " ");
            }*/



            Console.WriteLine("\n\nQuick Sort");
            int[] QuickSortArray = { 34, 380, 944, 594, 783, 584, 550, 665, 721, 819, 285, 344, 503, 807, 491, 623, 845, 300, 11,1000 };
            QuickSort1 qs = new QuickSort1();
            qs.Sort(QuickSortArray);
            for (int i = 0; i < QuickSortArray.Length; i++)
            {
                Console.Write(QuickSortArray[i] + " ");
            }

            Console.WriteLine("\n\nString Permuations");

            List<string> perm1 =StringPermutations.GetPermuations("a");
            Console.Write("\nPermution a = ");
            StringPermutations.Print(perm1);

            List<string> perm2 = StringPermutations.GetPermuations("ab");
            Console.Write("\nPermution ab = ");
            StringPermutations.Print(perm2);

            List<string> perm3 = StringPermutations.GetPermuations("abc");
            Console.Write("\nPermution abc = ");
            StringPermutations.Print(perm3);

            List<string> perm4 = StringPermutations.GetPermuations("abcd");
            Console.Write("\nPermution abcd = ");
            StringPermutations.Print(perm4);

            Console.Write("\nGetSubsets");
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            List<List<int>> subsets = GetSubsets.GetSubSets(list, 2);
            GetSubsets.Print(subsets);

            Console.Write("\nCountways");
            int cw1 = 1;
            int cw2 = 2;
            int cw3 = 3;
            int cw4 = 4;
            int w1 = CountWay.CountWays(cw1);
            int w2 = CountWay.CountWays(cw2);
            int w3 = CountWay.CountWays(cw3);
            int w4 = CountWay.CountWays(cw4);
            Console.Write("\nCountways 1: " + w1);
            Console.Write("\nCountways 2: " + w2);
            Console.Write("\nCountways 3: " + w3);
            Console.Write("\nCountways 4: " + w4);

            int[] DParr1 = new int[] { -1, -1, -1, -1, -1, -1, -1, -1 };
            int[] DParr2 = new int[] { -1, -1, -1, -1, -1, -1, -1, -1 };
            int[] DParr3 = new int[] { -1, -1, -1, -1, -1, -1, -1, -1 };
            int[] DParr4 = new int[] { -1, -1, -1, -1, -1, -1, -1, -1 };

            int z1 = CountWay.CountWaysDP(cw1, DParr1);
            int z2 = CountWay.CountWaysDP(cw2, DParr2);
            int z3 = CountWay.CountWaysDP(cw3, DParr3);
            int z4 = CountWay.CountWaysDP(cw4, DParr4);
            Console.Write("\nCountwaysDP 1: " + z1);
            Console.Write("\nCountwaysDP 2: " + z2);
            Console.Write("\nCountwaysDP 3: " + z3);
            Console.Write("\nCountwaysDP 4: " + z4);
            Console.WriteLine("\n");

            Console.WriteLine(StringManipulations.FindFirstNonRepeatCharacter2("total"));
            Console.WriteLine(StringManipulations.FindFirstNonRepeatCharacter2("teeter"));

            Console.WriteLine(StringManipulations.RemoveChars("Battle of the Vowels: Hawaii vs. Grozny", "aeiou"));

            string reverseWords = "Do or do not, there is no try";
            //Console.WriteLine("Reverse words " + reverseWords + ". " + StringManipulations.ReverseWords(reverseWords));

            Console.WriteLine("StringToInt: " + StringManipulations.StringToInt("-267"));
            Console.WriteLine("IntToString: " + StringManipulations.IntToString(-267));

            Console.WriteLine("\nSelection Sort:");
            int[] SelectionSortArray = { 34, 380, 944, 594, 783, 584, 550, 665, 721, 819, 285, 344, 34, 503, 807, 491, 623, 845, 300, 11, 500 };
            SelectionSort.Sort(SelectionSortArray);
            for (int i = 0; i < SelectionSortArray.Length; i++)
            {
                Console.Write(SelectionSortArray[i] + " ");
            }

            Console.WriteLine("\nInsertion Sort:");
            int[] InsertionSortArray = { 34, 380, 944, 594, 783, 584, 550, 665, 721, 819, 285, 344, 34, 503, 807, 491, 623, 845, 300, 11, 500 };
            InsertionSort.Sort(InsertionSortArray);
            for (int i = 0; i < InsertionSortArray.Length; i++)
            {
                Console.Write(InsertionSortArray[i] + " ");
            }

            Console.WriteLine("\nQuick Sort:");
            int[] QuickSortArray1 = { 34, 380, 944, 594, 783, 584, 550, 665, 721, 819, 285, 344, 34, 503, 807, 491, 623, 845, 300, 11, 500 };
            QuickSort.Sort(QuickSortArray1);
            for (int i = 0; i < QuickSortArray.Length; i++)
            {
                Console.Write(QuickSortArray1[i] + " ");
            }

            Console.WriteLine("\nMerge Sort:");
            int[] MergeSortArray = { 34, 380, 944, 594, 783, 584, 550, 665, 721, 819, 285, 344, 34, 503, 807, 491, 623, 845, 300, 11, 500 };
            MergeSort.Sort(MergeSortArray);
            for (int i = 0; i < MergeSortArray.Length; i++)
            {
                Console.Write(MergeSortArray[i] + " ");
            }

            Console.WriteLine("\nBubble Sort:");
            int[] BubbleSortArray = { 34, 380, 944, 594, 783, 584, 550, 665, 721, 819, 285, 344, 34, 503, 807, 491, 623, 845, 300, 11, 500 };
            BubbleSort.Sort(BubbleSortArray);
            for (int i = 0; i < BubbleSortArray.Length; i++)
            {
                Console.Write(BubbleSortArray[i] + " ");
            }

            
            Console.WriteLine("Hashcode " + "MyHash".GetHashCode());

            foreach (string powerset in PowerSet.GetPowerSet("XYZD"))
            {
                Console.WriteLine("'" + powerset + "'");
            }
            Console.Read();
            
        }
    }
}
