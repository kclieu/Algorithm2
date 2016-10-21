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
    
    public class InsertionSort1
    {
        public static void Sort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int temp = a[i];

                int j;
                for (j = i - 1; j >= 0 && temp < a[j]; j--)
                {
                    a[j + 1] = a[j];
                    //a[i] = a[j];
                }
                a[j + 1] = temp;
                //a[i] = temp;
            }

        }
    }
}
