using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //Best O(nlog(n))
    //Average O(nlog(n))
    //Worst O(n2)
    public static class QuickSort
    {
        public static void Sort(int[] data)
        {
            QuickSortArray(data, 0, data.Length-1);
        }

        private static void QuickSortArray(int[] data, int left, int right)
        {
            int index = Partition(data, left, right);

            if (left < index -1)  //Sort left half
                QuickSortArray(data, left, index-1);

            if (index < right)  //Sort right half
                QuickSortArray(data, index, right);
        }

        private static int Partition(int[] data, int left, int right)
        {
            int pivot = data[(left + right) / 2];  //Pick pivot point;

            while (left <= right)
            {
                //Find element on left that should be on right
                while (data[left] < pivot)
                {
                    left++;
                }

                while (data[right] > pivot)
                {
                    right--;
                }


                //Swap elements, and move left and right indices
                if (left <= right)
                {
                    int temp = data[left];
                    data[left] = data[right];
                    data[right] = temp;

                    left++;
                    right--;
                }
            }

            return left;
        }
    }
}
