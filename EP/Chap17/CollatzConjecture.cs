using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class CollatzConjecture
    {
        public static void Calculate1(int n)
        {
            for(int i = 1; i <= n; i++)
            {
                int num = i;
                while(num != 1)
                {
                    if(num % 2 == 0)
                    {
                        num = num/2;
                    }
                    else
                    {
                        num = 3*num +1 ;
                    }
                }

                Console.WriteLine("{0} satisfies Collatz Conjecture.", i);
            }
        }

        /// <summary>
        /// Faster? by saving calculations already calculated
        /// </summary>
        /// <param name="n"></param>
        public static void Calculate2(int n)
        {
            int[] CollatzArr = new int[n*60+1];
            //List<int> CollatzArr = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                
                int num = i;
                while (num != 1)
                {
                    if (CollatzArr[num] == 1)
                    {
                        break;
                    }

                    if (num % 2 == 0)
                    {
                        num = num / 2;
                    }
                    else
                    {
                        num = 3 * num + 1;
                    }
                }

                CollatzArr[i] = 1;
                Console.WriteLine("{0} satisfies Collatz Conjecture.", i);
            }
        }
    }
}
