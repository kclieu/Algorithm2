using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class FindSecondLargest
    {
        public static int FindMax(int[] data)
        {
            return FindMax(data, 0, data.Length - 1);
        }

        //O(n)
        public static int FindMax(int[] data, int left, int right)
        {
            if (left == right)
                return data[left];

            int max1 = FindMax(data, 0, left);
            int max2 = FindMax(data, left + 1, right);

            if (max1 > max2)
                return max1;
            else
                return max2;

        }
    }
}
