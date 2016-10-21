using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class Program4
    {
        static void Main4(string[] args)
        {
            //List<int> weight = new List<int>{ 20, 30, 30};
            List<int> weight = new List<int> { 2, 3, 4 };
            List<int> value = new List<int> { 10, 20, 25};
            int KnapSackSize = 5;

            List<Pair<int, int>> items = new List<Pair<int, int>>();

            for (int i = 0; i < weight.Count; i++)
            {
                items.Add(new Pair<int,int>(weight[i], value[i]));
            }

            Console.WriteLine("All value = " + KnapSack.GetKnapSack(KnapSackSize, items));

            Console.Read();

        }
    }
}
