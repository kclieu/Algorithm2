using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Program
{
    class Program
    {
        static void MainProgramEPI(string[] args)
        {
            //Primes.GetPrimes(3);

            int[] maxDiffArr = { 1, 4, 2, 5, 3, 9, 2, 11, 14, 10, 15 };
            int maxDiff1 = MaxDiff.ComputeMaxDiff(maxDiffArr);
            int maxDiff2 = MaxDiff.ComputeMaxDiff2(maxDiffArr);
            Console.WriteLine("Max Diff1 is " + maxDiff1);
            Console.WriteLine("Max Diff2 is " + maxDiff2);

            //int[] maxSumArr = { -2, -5, 6, -2, -3, 1, 5, -6 };  // 6, -2. -3, 1, 5 = 7
            //int[] maxSumArr = { -2, -3, 4, -1 }; 
            int[] maxSumArr = { -2, -3, -4, -1 }; 
            int maxSum1 = MaximumSumContiguous.GetMaxSum(maxSumArr);
            Console.WriteLine("Max sum contiguous array (naive) " + maxSum1);

            int maxSum2 = MaximumSumContiguous.GetMaxSum2(maxSumArr);
            Console.WriteLine("Max sum contiguous array (Divide and conquer):AKA Buy/sell stocks for max profit " + maxSum2);

            //Does not work if array is all negative
            int maxSum3 = MaximumSumContiguous.GetMaxSum3(maxSumArr);
            Console.WriteLine("Max sum contiguous array (Kadane) " + maxSum3);


            //Console.WriteLine("CollatzConjecture ");
            //CollatzConjecture.Calculate2(5000000);


            Console.WriteLine("Levenstein distance ");
            List<string[]> l = new List<string[]>
            {
	            new string[]{"ant", "aunt"},
	            new string[]{"Sam", "Samantha"},
	            new string[]{"clozapine", "olanzapine"},
	            new string[]{"flomax", "volmax"},
	            new string[]{"toradol", "tramadol"},
	            new string[]{"kitten", "sitting"}
            };

            //foreach (string[] a in l)
            //{
            //    int cost = Compute(a[0], a[1]);
            //    Console.WriteLine("{0} -> {1} = {2}",
            //        a[0],
            //        a[1],
            //        cost);
            //}

            Console.WriteLine(LevenshteinDistance.Compute("aunt", "ant"));  //1
            Console.WriteLine(LevenshteinDistance.Compute("Sam", "Samantha")); //5
            Console.WriteLine(LevenshteinDistance.Compute("flomax", "volmax"));  //3

            Console.WriteLine("\n\n\n");

            Console.WriteLine("*********************** Subset Sum Problem ***********************************");

            //int[] set = {3, 34, 4, 12, 5, 2};
            //int sum = 13;

            //int[] set = {3, 34, 12, 5, 11};
            //int sum = 21;

            //int[] set = { 3, 6, 11 };
            int[] set = { 11, 6, 3 };
            int sum = 9;

            int n = set.Length / set[0];
            //bool isSubsetSum = SubsetSum.isSubsetSum1(set, n, sum);
            //bool isSubsetSum = SubsetSum.isSubset1(set, sum);
            //bool isSubsetSum = SubsetSum.isSubsetSum2(set, n, sum);

            //bool isSubsetSum = SubsetSum.isSubsetSum2(set, sum);
            bool isSubsetSum = SubsetSum.isSubsetSum6(set, sum);
            Console.WriteLine(string.Format("Is subset with given sum {0}: {1}", sum, isSubsetSum));

            Console.WriteLine("*********************** Partition Problem ***********************************");

            int[] partitions = { 100, 200, 300, 400, 500, 600, 700, 800, 900 };
            //int n = 9;
            PartitionDP.Partition(partitions, 8, 3);


            Console.WriteLine("----------------------Coin Change-------------------");
            //int i, j;
            //int[] coins1 = { 1, 2, 3 };
            int[] coins1 = { 1, 5, 10, 25 };
            int m = coins1.Length / coins1[0];
            int changeValue =  15;
            Console.Write("\nNumber of Change 1: " + CoinChange.Count(coins1, m, changeValue));
            Console.WriteLine();
            Console.Write("\nNumber of Change 2: " + CoinChange.Count2(coins1, changeValue));

            //int[] coins2 = { 2, 5, 3, 6 };
            //m = sizeof(coins2) / coins2[0];
            //Console.Write("\nNumber of Change 2: " + CoinChange.Count(coins2, m, 10));
            Console.Read();
        }
    }
}
