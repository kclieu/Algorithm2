using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class PartitionDP
    {
        /**/
        public static void Partition(int[] s, int n, int k)
        {
            //n = k - 1;

            int[,] m = new int[n + 1, k + 1];
            int[,] d = new int[n + 1, k + 1];
            int[] p = new int[n + 1];

            //int[,] m = new int[n + 1, k];
            //int[,] d = new int[n + 1, k];
            //int[] p = new int[n + 1];
            int cost = 0;
            int i, j, x;

            p[0] = 0;

            for (i = 1; i <= n; i++) p[i] = p[i - 1] + s[i];
            for (i = 1; i <= n; i++) m[i,1] = p[i];
            for (j = 1; j <= k; j++) m[1,j] = s[1];

            for (i = 2; i <= n; i++)
            {
                for (j = 2; j <= k; j++)
                {
                    m[i,j] = int.MaxValue;

                    for (x = 1; x <= (i - 1); x++)
                    {
                        cost = Math.Max(m[x, j - 1], p[i] - p[x]);
                        if (m[i, j] > cost)
                        {
                            m[i, j] = cost;
                            d[i, j] = x;
                        }
                    }
                }
            }

            ReconstructPartition(s, d, n, k);
        }


        private static void ReconstructPartition(int[] s, int[,] d, int n, int k)
        {
            if (k == 1) PrintBooks(s, 1, n);
            else
            {
                ReconstructPartition(s, d, d[n, k], k - 1);
                PrintBooks(s, d[n, k] + 1, n);
            }
        }


        private static void PrintBooks(int[] s, int start, int end)
        {
            for(int i=start; i <= end; i++)
            {
                Console.Write(s[i]);
            }
            Console.Write("\n");
        }


        //const int MAX_N = 100;
        //int FindMax(int a[], int n, j)
    }
}
