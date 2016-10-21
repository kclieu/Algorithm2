using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class SelectionSort
    {
        public static void Sort(int[] data)
        {
            SelectionSortRecursive(data, 0);
        }

        private static void SelectionSortRecursive(int[] data, int start)
        {
            if (start < data.Length - 1)
            {
                Swap(data, start, FindMinimumIndex(data, start));
                SelectionSortRecursive(data, start + 1);
            }
        }


        private static int FindMinimumIndex(int[] data, int start)
        {
            int minPos = start;

            for (int i = start + 1; i < data.Length; i++)
            {
                if (data[i] < data[minPos])
                    minPos = i;
            }
            return minPos;
        }

        private static void Swap(int[] data, int index1, int index2)
        {
            if (index1 != index2)
            {
                int tmp = data[index1];
                data[index1] = data[index2];
                data[index2] = tmp;
            }
        }
    }
}
