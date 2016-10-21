using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class QuickSortStf
    {
        private static long count;

        public static int[] ParseFile(string path)
        {
            StreamReader reader = File.OpenText(path);
            string line;
            List<int> lstInt = new List<int>();

            while ((line = reader.ReadLine()) != null)
            {
                int i = int.Parse(line);
                lstInt.Add(i);
            }

            return lstInt.ToArray();
        }

        public static long Sort(int[] data)
        {
            return QuickSortArray(data, 0, data.Length - 1);
        }

        private static long QuickSortArray(int[] data, int left, int right)
        {
            int pivot = Partition(data, left, right);

            if (left < pivot - 1)  //Sort left half
            {
                QuickSortArray(data, left, pivot - 1);
                count += pivot -1 - left ;
            }
            if (pivot <= right)  //Sort right half
            {
                QuickSortArray(data, pivot , right);
                count += right - (pivot ) ;
            }

            return count;
        }

        //private static int Partition(int[] data, int left, int right)
        //{
        //    //int pivot = data[(left + right) / 2];  //Pick pivot point;
        //    //int piv = FindMedian(data, left, right);

        //    //Swap(data, left, piv);
        //    Swap(data, left, right);
        //    int pivot = data[left];

        //    while (left <= right)
        //    {
        //        //Find element on left that should be on right
        //        while (data[left] < pivot)
        //        {
        //            left++;
        //        }

        //        while (data[right] > pivot)
        //        {
        //            right--;
        //        }


        //        //Swap elements, and move left and right indices
        //        if (left <= right)
        //        {
        //            int temp = data[left];
        //            data[left] = data[right];
        //            data[right] = temp;

        //            left++;
        //            right--;
        //        }
        //    }

        //    return left;
        //}

        private static int Partition(int[] data, int left, int right)
        {
            int pivot = data[left];
            int i = left + 1;

            for (int j = left + 1; j <= right; j++)
            {
                if (data[j] < pivot)
                {
                    Swap(data, i, j);
                    i = i + 1;
                }
            }

            Swap(data, left, i-1  );

            return i;
        }

        public static int FindMedian(int[] data, int index1, int index2)
        {
            int arrLength = index2 - index1;

            int first = data[index1];
            int last = data[index2];

            int mid = (index1 + index2) / 2;
            
            int middle = data[mid];

            int target = first;


            if ((first >= last && first <= middle) || (first >= middle && first <= last))
                target = index1;
            else if ((last >= first && last <= middle) || (last >= middle && last <= first))
                target = index2;
            else
                target = mid;



            return target;
        }

        private static void Swap(int[] data, int index1, int index2)
        {
            int temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
        }
    }
}
