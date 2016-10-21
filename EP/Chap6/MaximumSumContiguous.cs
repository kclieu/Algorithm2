using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class MaximumSumContiguous
    {
        /////////////////////////////////////////--------------------------------------------------
        //Naive run 0(n2)
        public static int GetMaxSum(int[] data)
        {
            int maxSum = -1000000;
            
            for(int i = 0; i < data.Length; i++)
            {
                int currentSum = 0;

                for (int j = i; j < data.Length; j++)
                {
                    currentSum += data[j];
                    if (currentSum > maxSum)
                        maxSum = currentSum;
                }
            }

            return maxSum;
        }

        ///////////////////////////////////////----------------------------------------------------

        //Use Divide and conquer: O(nLogn) //similar to merge sort
        public static int GetMaxSum2(int[] data)
        {
            return maxSubArraySum(data, 0, data.Length - 1);
        }

        private static int maxSubArraySum(int[] data, int low, int high)
        {
            //Base case: only 1 element
            if (low == high)
                return data[low];

            //find mid point
            int mid = (low + high) / 2;

            /* Return maximum of following three possible cases
            a) Maximum subarray sum in left half
            b) Maximum subarray sum in right half
            c) Maximum subarray sum such that the subarray crosses the midpoint */
            return max(maxSubArraySum(data, low, mid), maxSubArraySum(data, mid + 1, high), maxCrossingSum(data, low, mid, high));
        }

        private static int maxCrossingSum(int[] data, int low, int mid, int high)
        {
            //include elements on left of mid
            int sum = 0;
            int left_sum = Int32.MinValue;

            for (int i = mid; i >= low; i--)
            {
                sum = sum + data[i];

                if (sum > left_sum)
                    left_sum = sum;
            }

            //include elements on right of mid
            sum = 0;
            int right_sum = Int32.MinValue;

            for (int i = mid + 1; i <= high; i++ )
            {
                sum = sum + data[i];
                if (sum > right_sum)
                    right_sum = sum;

            }

            return left_sum + right_sum;
        }


        private static int max(int a, int b) { return (a > b) ? a : b; }
        private static int max(int a, int b, int c) { return max(max(a, b), c); }

        //-----------------------------------------------------------------------
        //Kardane's algo run in O(n)
        public static int GetMaxSum3(int[] data)
        {
            int max_so_far = 0;
            int max_end_here = 0;
           
            for (int i = 0; i < data.Length; i++)
            {
                max_end_here = max_end_here + data[i];

                //Look for all positive contiguous segments
                if (max_end_here < 0)
                    max_end_here = 0;
                if (max_so_far < max_end_here)
                    max_so_far = max_end_here;
            }

            return max_so_far;
        }
    }
}
