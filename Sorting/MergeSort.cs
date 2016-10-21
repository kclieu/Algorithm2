using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class MergeSort
    {
        public static void Sort(int[] data)
        {
            if (data.Length < 2)
                return;

            //Split the array intot 2 subarrays of approx. equal size
            int mid = data.Length/2;
            int[] left = new int[mid];
            int[] right = new int[data.Length - mid];

            Array.Copy(data, 0, left, 0, left.Length);
            Array.Copy(data, mid, right, 0, right.Length);

            Sort(left);
            Sort(right);

            Merge(data, left, right);
        }

        private static void Merge(int[] dest, int[] left, int[] right)
        {
            int destIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    dest[destIndex++] = left[leftIndex++];
                }
                else
                {
                    dest[destIndex++] = right[rightIndex++];
                }
            }

            //Copy rest of whichever array remains
            while (leftIndex < left.Length)
                dest[destIndex++] = left[leftIndex++];

            while (rightIndex < right.Length)
                dest[destIndex++] = right[rightIndex++];

            //return dest;
        }
    }
}
