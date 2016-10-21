using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class CountWay
    {
        public static int CountWays(int n)
        {
            if (n < 0)
                return 0;
            else if (n == 0)
            {
                return 1;
            }
            else {
                return CountWays(n - 1) + CountWays(n - 2) + CountWays(n - 3);
            }
        }

        public static int CountWaysDP(int n, int[] map)
        {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;
            else if (map[n] > -1)
                return map[n];
            else {
                map[n] = CountWaysDP(n - 1, map) + CountWaysDP(n - 2, map) + CountWaysDP(n - 3, map);
                return map[n];
            }
        
        }
    }
}
