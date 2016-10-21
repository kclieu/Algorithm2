using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class UniModal
    {
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

        public static int FindMax(int[] data)
        {
            return FindMax(data, 0, data.Length - 1);
        }


        public static int FindMax(int[] data, int left, int right)
        {
            if ((right == left))
                return data[right];

            int partition = (right + left) / 2;

            if (data[partition + 1] > data[partition])
                return FindMax(data, partition + 1, right);
            else
                return FindMax(data, left, partition);

        }

        


    }
}
