using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Algos.UCSD_Courses.Data_Structures.A2
{
    public class Swap
    {
        int index1;
        int index2;

        public Swap(int index1, int index2)
        {
            this.index1 = index1;
            this.index2 = index2;
        }

        public int Index1
        {
            get { return index1; }
            set { index1 = value; }
        }

        public int Index2
        {
            get { return index2; }
            set { index2 = value; }
        }
    }

    public class BuildHeap
    {
        private int[] data;
        private List<Swap> swaps;

        private void GenerateSwapsNaive(List<Swap> swaps)
        {
            swaps = new List<Swap>();

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; i < data.Length; j++)
                {
                    if (data[i] > data[j])
                    {
                        swaps.Add(new Swap(i, j));
                        int tmp = data[i];
                        data[i] = data[j];
                        data[j] = tmp;
                    }

                }
            }
        }

        private void WriteRepsonse()
        {
            Console.WriteLine(swaps.Count);
            foreach (Swap swap in swaps)
            {
                Console.WriteLine(swap.Index1 + " " + swap.Index2);
            }
        }

        public void Solve(List<Swap> swaps)
        {
            GenerateSwapsNaive(swaps);
            WriteRepsonse();
        }

        public static void Main(string[] args)
        {
            BuildHeap heap = new BuildHeap();

            int n = args[0];
            int[] data = new int[n];

            string line;
            int i = 0;

            for (int i = 0; i < n; i++)
            {
                data[i] = int.Parse(Console.ReadLine());
            }

            heap.Solve(data.ToList<Swap>());
        }
    }
}
