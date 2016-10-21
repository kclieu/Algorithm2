using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class GetSubsets
    {
        public static List<List<int>> GetSubSets(List<int> set, int index)
        {
            List<List<int>> allsubsets;

            if (set.Count == index)
            {
                allsubsets = new List<List<int>>();
                allsubsets.Add(new List<int>());
            }
            else {
                allsubsets = GetSubSets(set, index + 1);
                int item = set[index];

                List<List<int>> moreSubsets = new List<List<int>>();

                foreach (List<int> subset in allsubsets)
                {
                    List<int> newsubset = new List<int>();
                    newsubset.AddRange(subset);
                    newsubset.Add(item);
                    moreSubsets.Add(newsubset);
                }
                allsubsets.AddRange(moreSubsets);
            }

            return allsubsets;
        }

        public static void  Print(List<List<int>> list)
        {
            foreach(List<int> ls in list)
            {
                Console.Write("\n");
                foreach (int i in ls)
                {
                    Console.Write(i + ", "); 
                }
            }
        }
    }
}
