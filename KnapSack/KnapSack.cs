using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://www.programminglogic.com/knapsack-problem-dynamic-programming-algorithm/

    public static class KnapSack
    {
        //public static int GetKnapSack(int w, List<Pair<int, int>> items)
        //{
        //    int[] V = new int[w + 1];

        //    foreach (Pair<int, int> item in items)
        //    {
        //        for (int j = w; j >= item.GetFirst(); j--)
        //        {
        //            V[j] = Math.Max(V[j], V[j - item.GetFirst()] + item.GetSecond());
        //        }
        //    }

        //    return V[w];
        //}

        public static int GetKnapSack(int w, List<Pair<int, int>> items)
        {
            int[] V = new int[w + 1];



            foreach (Pair<int, int> item in items)
            {
                for (int j = w; j >= item.GetFirst(); j--)
                {
                    int a = item.GetFirst();
                    int n = item.GetSecond();
                    int k = w;
                    int l = j;
                    
                    int o = V[j];
                    int p = j - item.GetFirst();
                    int q = V[j - item.GetFirst()];
                    int r = Math.Max(V[j], V[j - item.GetFirst()]);
                    int s = Math.Max(V[j], V[j - item.GetFirst()] + item.GetSecond());
                    V[j] = Math.Max(V[j], V[j - item.GetFirst()] + item.GetSecond());
                    int t = V[w];
                }
            }
            int t1 = V[w];
            return V[w];
        }


        //public static int GetKnapSackDP(int w, List<Pair<int, int>> items)
        //{
        //    int index = items.Count - 1;
        //    int take, dontTake;
        //    take = dontTake = 0;

        //    int[,] matrix = new int[index, w];
        //    int[,] picks = new int[index, w];

        //    if (matrix[index, w] != 0)
        //        return matrix[index, w];

        //    if (index == 0)
        //    {
        //        if (items[0].GetFirst() <= w)
        //        {
        //            picks[index, w] = 1;
        //            matrix[index, w] = items[0].GetSecond();

        //            return items[0].GetSecond();
        //        }
        //        else
        //        {
        //            picks[index, w] = -1;
        //            matrix[index, w] = 0;

        //            return 0;
        //        }
        //    }

        //    if (items[index].GetFirst() <= w)
        //        take = items[index].GetSecond() + GetKnapSackDP( w - items[index].GetFirst(), items);


        //}
    }
}
