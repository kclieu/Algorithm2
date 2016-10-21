using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class Inversion
    {
        public static long inversionNum;

        public static int[] ParseFile(string path)
        {
            StreamReader reader = File.OpenText(path);
            string line;
            List<int> lstInt = new List<int>();

            while((line = reader.ReadLine()) != null)
            {
                int i = int.Parse(line);
                lstInt.Add(i);
            }

            return lstInt.ToArray();
        }


        public static long Sort(int[] data)
        {
            if (data.Length < 2)
                return 0;

            int mid = data.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[data.Length - mid];

            Array.Copy(data, 0, left, 0, left.Length);
            Array.Copy(data, mid, right, 0, right.Length);
            Sort(left);
            Sort(right);

            Merge(data, left, right);
            return inversionNum;
        }

        public static void Merge(int[] dest, int[] left, int[] right)
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
                    inversionNum += (left.Length - leftIndex);
                    dest[destIndex++] = right[rightIndex++];
                    //inversionNum += (right.Length - rightIndex);
                    //inversionNum++;
                }
            }

            while (leftIndex < left.Length)
                dest[destIndex++] = left[leftIndex++];

            while (rightIndex < right.Length)
                dest[destIndex++] = right[rightIndex++];
        }
    }
}
