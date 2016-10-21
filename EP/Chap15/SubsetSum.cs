using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://www.geeksforgeeks.org/dynamic-programming-subset-sum-problem/

    //Given a set of non-negative integers, and a value sum, determine if there is a subset of the given set with sum equal to given sum.
    //Examples: set[] = {3, 34, 4, 12, 5, 2}, sum = 9
    //Output:  True  //There is a subset (4, 5) with sum 9

    //The isSubsetSum problem can be divided into two subproblems
    //a) Include the last element, recur for n = n-1, sum = sum – set[n-1]  
    //b) Exclude the last element, recur for n = n-1.
    //If any of the above the above subproblems return true, then return true.
    public static class SubsetSum
    {
        //Naive
        public static bool isSubsetSum1(int[] set, int n, int sum)
        //public static bool isSubset1(int[] set,  int sum)
        {
            //int n = set.Length;

            if (sum == 0)
                return true;
            if (n == 0 && sum != 0)
                return false;

            // If last element is greater than sum, then ignore it
            //if(set[n-1] > sum)
            //return isSubset1(set, n-1, sum);

            /* else, check if sum can be obtained by any of the following
            (a) including the last element
            (b) excluding the last element   */
            //return isSubset1(set, n , sum) || isSubset1(set, n-1, sum - set[n - 1]);
            return isSubsetSum1(set, n - 1, sum) || isSubsetSum1(set, n, sum - set[n - 1]);
            //return isSubset1(set, sum) || isSubset1(set, sum - set[n - 1]);

        }

        public static bool isSubsetSum2(int[] set, int n, int sum)
        {
            // The value of subset[i][j] will be true if there is a subset of set[0..j-1]
            //  with sum equal to i
            bool[,] subset = new bool[sum + 1, n + 1];

            // If sum is 0, then answer is true
            for (int i = 0; i <= n; i++)
                subset[0, i] = true;

            // If sum is not 0 and set is empty, then answer is false
            for (int i = 1; i <= sum; i++)
                subset[i, 0] = false;

            // Fill the subset table in botton up manner
            for (int i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    subset[i, j] = subset[i, j - 1];
                    if (i >= set[j - 1])
                        subset[i, j] = subset[i, j] || subset[i - set[j - 1], j - 1];
                }
            }

            /* // uncomment this code to print table
             for (int i = 0; i <= sum; i++)
             {
               for (int j = 0; j <= n; j++)
                  printf ("%4d", subset[i][j]);
               printf("\n");
             } */

            return subset[sum, n];
        }

        //https://codeaccepted.wordpress.com/2014/02/27/dynamic-programming-subset-sum-problem/
        public static bool isSubsetSum3(int[] set, int sum)
        {
            int n = set.Length;
            //int[] nums = new int[n + 1]; 
            int[,] isPossible = new int[n + 1, sum + 1];

            //for (int i = 0; i <= n; i++)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    //initializing to 0
                    isPossible[i, j] = 0;
                }
            }

            //if sum = 0, then answer is true
            for (int i = 1; i <= n; i++)
                isPossible[i, 0] = 1;

            //for (int i = 1; i <= n; i++)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    if (isPossible[i + 1, j] == 1)
                        isPossible[i, j] = 1;
                    if (j - set[i] >= 0 && isPossible[i - 1, j - set[i]] == 1)
                        isPossible[i + 1, j] = 1;
                }
            }


            return isPossible[n, sum] == 1;
        }

        //https://gist.github.com/riyadparvez/6045979
        public static bool isSubsetSum4(int[] set, int sum)
        {
            int n = set.Length;
            //int[] nums = new int[n + 1]; 
            int[,] isPossible = new int[n + 1, sum + 1];

            //if set is empty and sum is not 0
            for (int i = 0; i <= sum; i++)
            {
                isPossible[0, i] = 0;
            }

            //if sum = 0, then answer is true
            for (int i = 1; i <= n; i++)
                isPossible[i, 0] = 1;

            for (int j = 1; j <= sum; j++)
            {
                for (int i = 1; i <= set.Length; i++)
                {
                    if (isPossible[i - 1, j] == 1)
                        isPossible[i, j] = 1;
                    if (j - set[i] >= 0 && isPossible[i - 1, j - set[i - 1]] == 1)
                        isPossible[i, j] = 1;
                }
            }


            return isPossible[n, sum] == 1;
        }



        //http://crab.rutgers.edu/~guyk/ex/part.pdf
        /// <summary>
        /// 
        /// </summary>
        /// <param name="set"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        //public static bool isSubsetSum5(int[] set, int sum)
        //{
        //    bool[,] isPossible = new bool[set.Length, sum + 1];

        //    isPossible[0, 0] = true;

        //    for (int j = 0; j <= sum; j++)
        //    {
        //        isPossible[0, j] = false;
        //    }

        //    for (int i = 1; i <= set.Length; i++)
        //    {
        //        for (int j = 1; j <= sum; j++)
        //        { 
        //            if(
        //        }
        //    }



        //        return true;
        //}

        //http://comproguide.blogspot.com/2013/10/subset-sum-problem.html
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static bool isSubsetSum6(int[] array, int sum)
        {
            int len = array.Length;
            bool[,] table = new bool[sum + 1, len + 1];

            int i;

            //If sum is zero; empty subset always has a sum 0; hence true
            for (i = 0; i <= len; i++)
                table[0, i] = true;

            //If set is empty; no way to find the subset with non zero sum; hence false
            for (i = 1; i <= sum; i++)
                table[i, 0] = false;

            //calculate the table entries in terms of previous values
            for (i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= len; j++)
                {
                    table[i, j] = table[i, j - 1];
                    /**/
                    if (!table[i, j] && i >= array[j - 1])
                        table[i, j] = table[i - array[j - 1], j - 1];
                }
            }

            PrintTable(table, array,  sum);
            return table[sum, len];
        }


        private static void PrintTable(bool[,] table, int[] inputData, int sum)
        {
            Console.Write("\t0\t");
            for (int j = 0; j < inputData.Length; j++)
            {
                Console.Write(string.Format("{0}\t", inputData[j]));
            }

            Console.WriteLine();

            for (int i = 0; i <= sum; i++)
            {
                Console.Write(string.Format("{0}\t", i));
                

                for (int j = 0; j <= inputData.Length; j++)
                {
                    Console.Write(String.Format("{0}\t", table[i, j]));
                }

                    Console.WriteLine();
            }
        }
    }
}
