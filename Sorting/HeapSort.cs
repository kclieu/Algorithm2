using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //There are two types of heaps. First one is Max heap and second one is Min heap. 
    //Heap (Max/Min) is a special type of binary tree.The roots of  the max heap is greater than its child roots. 
    //Other heap is Min heap it is also a special type of heap which has minimum root than his child. We can sort the array values using heap sorting algorithm. In this algorithm the heap build is used to rebuild the heap.


    //Worst case performance : O(n log n)
    //Best case performance : O(n log n)
    //Average case performance : O(n log n)
    public class HeapSort
    {
        private static int N;

        //Function to build a heap
        public void Sort(int[] arr)
        {
            //N = arr.Length - 1;
            Heapify(arr);
            for (int i = N; i >= 0; i--)
            {
                Swap(arr, 0, i);
                N = N - 1;
                MaxHeap(arr, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public void Heapify(int[] arr)
        {
            N = arr.Length - 1;  //Heap size

            //since the elements in subarray A[n/2+1...n] are all leaves, Heapfiy goes through the remaing nodes of the tree and run MaxHeap on each one
            for (int i = N / 2; i >= 0; i--)
            {
                MaxHeap(arr, i);
            }
        }

        /// <summary>
        /// Function to swap largest element in a heap
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        public void MaxHeap(int[] arr, int i)
        {
            int left = 2 * i;
            int right = 2 * i + 1;
            int max = i;

            if (left <= N && arr[left] > arr[i])
                max = left;

            if (right <= N && arr[right] > arr[max])
                max = right;

            if (max != i)
            {
                Swap(arr, i, max);

                //continue recursively
                MaxHeap(arr, max);
            }
        }

        /// <summary>
        /// Swap 2 numbers in an array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}



//////
//We represent heaps in level order, going from left to right. The array corresponding to the heap above is [25, 13, 17, 5, 8, 3].
//PARENT (i)
//        return floor(i/2)
//LEFT (i)
//        return 2i
//RIGHT (i)
//        return 2i + 1

//Heap property:   A[PARENT (i)] ≥ A[i], ;largest element of the heap is stored in the root