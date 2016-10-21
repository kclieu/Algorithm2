using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class Primes
    {
        public static void GetPrimes(int n)
        {
            int[] primeArr = new int[n + 1]; 

            //for (int i = 3; i <= n; i++)
            //{
            //    primeArr[i] = 3;
            //}

            for(int i = 2; i <= primeArr.Length; )
            {
                if(primeArr[i] == 0)
                    primeArr = GetPrimesHelper(i, primeArr, n);
            }

            PrintPrime(primeArr);
        }

        private static int[] GetPrimesHelper(int startNum, int[] primeArr, int num)
        {
            int i = startNum;
            int multiple = 2;

            for (int j = startNum; j < primeArr.Length;j++ )
            {
                int product = 1;
                while (product < num)
                {
                    product = startNum * multiple;

                    if (product <= num)
                    {
                        primeArr[product] = 0;
                    }

                    multiple++;
                }
            }

            return primeArr;

        }

        private static void PrintPrime(int[] primes)
        {
            for (int i = 2; i <= primes.Length; i++)
            {
                if (primes[i] == 0)
                {
                    Console.Write(primes[i] + ", ");
                }
            }
        }
    }
}
