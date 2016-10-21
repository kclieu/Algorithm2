using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //similar to bubble sort
    //Advantage O(1) space
    //Sorting is done in-place, by iterating the array

    //Best O(n)
    //Worst O(n2)
    //Average O(n2)
    public static class InsertionSort
    {
        //public static void Sort(int[] data)
        //{
        //    for (int i = 0; i < data.Length - 1; i++)
        //    {
        //        for (int j = i + 1; j > 0; j--)
        //        {
        //            if (data[j - 1] > data[j])
        //            {
        //                //swap data
        //                int temp = data[j - 1];
        //                data[j - 1] = data[j];
        //                data[j] = temp;
        //            }
        //        }
        //    }
        //}

        public static void Sort(int[] data)
        {
            int i, j, tmp;

            for (i = 1; i < data.Length; i++)
            {
                j = i;
                while (j > 0 && data[j - 1] > data[j])
                {
                    tmp = data[j];
                    data[j] = data[j - 1];
                    data[j - 1] = tmp;
                    j--;
                }
            }
        }
    }
}
