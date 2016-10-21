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

    public class QuickSort1
    {
        private int[] array;
        private int length;

        public void Sort(int[] Arr)
        {
            if (Arr == null || Arr.Length == 0)
                return;
            this.array = Arr;
            length = array.Length;
            QuickSortArray(0, length - 1);
        }


        private void QuickSortArray(int lowerIndex, int higherIndex)
        {
            int i = lowerIndex;
            int j = higherIndex;

            int pivot = array[lowerIndex + (higherIndex - lowerIndex) / 2];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                while(array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(i, j);
                    i++;
                    j--;
                }
            }

            //Call QuickSort recursively

            if (lowerIndex < j)
                QuickSortArray(lowerIndex, j);
            if (i < higherIndex)
                QuickSortArray(i, higherIndex);
        }


        private void Swap(int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
