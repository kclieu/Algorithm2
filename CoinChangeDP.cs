using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class CoinChange
    {
        // Returns the count of ways we can sum s[0...numberofCoins-1] coins to get sum changeValue
        public static int Count(int[] s, int numberofCoins, int changeValue)
        {
            if(changeValue == 0)
                return 1;
            if(changeValue < 0)
                return 0;
            if(numberofCoins <= 0 && changeValue >= 1)
                return 0;

            return Count(s, numberofCoins -1, changeValue) + Count(s, numberofCoins, changeValue - s[numberofCoins -1]);
        }
        
        
        //http://www.cs.cornell.edu/~wdtseng/icpc/notes/dp3.pdf
        public static int Count2(int[] s, int changeValue)
        {
            int[] T = new int[25];
            T[0] = 1;

            for (int i = 1; i <= changeValue; i++)
                T[i] = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j + s[i] <= changeValue; j++)
                {
                    T[j + s[i]] += T[j];
                }
            }

            PrintTable(T);

            return T[changeValue];
        }

        private static void PrintTable(int[] Table)
        {
            for (int i = 0; i < Table.Length; i++)
            {
                Console.WriteLine(i + " " + Table[i]);
            }
        }
    }
}
