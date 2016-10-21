using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos{
    public static class MaxDiff
    {
        //public static int ComputeMaxDiff(int[] data)
        //{
        //    int diff1 = 0;
        //    int diff2 = 0;
        //    int count1 = 0;
        //    int count2 = 0;
        //    int i1 =0 , j1 =0, k1=0, l1=0;
        //    for(int i= 0; i < data.Length; i++)
        //    {
        //        for (int j = i+1; j < data.Length; j++)
        //        {

        //            int min = data[j] - data[i];
        //            if(count1 == 0)
        //            {
        //                diff1 = min;
        //                i1 = i;
        //                j1 = j;
        //                count1++;
        //            }

        //            if (min > diff1)
        //            {
        //                i1 = i;
        //                j1 = j;
        //                diff1 = min;
        //            }

        //            for(int k = j+1; k < data.Length; k++)
        //            {
        //                for (int l = k + 1; l < data.Length; l++)
        //                {
        //                    int max = data[l] - data[k];
        //                    if (count2 == 0)
        //                    {
        //                        diff2 = max;
        //                        k1 = k;
        //                        l1 = l;
        //                        count2++;
        //                    }

        //                    if (max > diff2)
        //                    {
        //                        k1 = k;
        //                        l1 = l;
        //                        diff2 = max;
        //                    }
        //                }

        //            }
        //        }
        //    }

        //    Console.WriteLine(String.Format("i={0}  j={1} k={2} l={3}", i1, j1, k1, l1));

        //    return diff2 + diff1;

           
        //}

        //public static int ComputeMaxDiff(int[] data)
        //{
        //    int diff1 = 0;
        //    int diff2 = 0;
        //    int count1 = 0;
        //    int count2 = 0;
        //    int i1 = 0, j1 = 0, k1 = 0, l1 = 0;
        //    for (int l = data.Length - 1; l >= 0; l--)
        //    {
        //        for (int k = l-1 ; k >= 0; k--)
        //        {

        //            int num1 = data[l] - data[k];
        //            if (count1 == 0)
        //            {
        //                diff1 = num1;
        //                l1 = l;
        //                k1 = k;
        //                count1++;
        //            }

        //            if (num1> diff1)
        //            {
        //                l1 = l;
        //                k1 = k;
        //                diff1 = num1;
        //            }

        //            for (int j = k - 1; j >= 0 ; j--)
        //            {
        //                for (int i = j-1; i >= 0; i--)
        //                {
        //                    int num2 = data[j] - data[i];
        //                    if (count2 == 0)
        //                    {
        //                        diff2 = num2;
        //                        j1 = j;
        //                        i1 = i;
        //                        count2++;
        //                    }

        //                    if (num2 > diff2)
        //                    {
        //                        j1 = j;
        //                        i1 = i;
        //                        diff2 = num2;
        //                    }
        //                }

        //            }
        //        }
        //    }

        //    Console.WriteLine(String.Format("i={0}  j={1} k={2} l={3}", i1, j1, k1, l1));

        //    return diff2 + diff1;


        //}

        //public static int ComputeMaxDiff(int[] data)
        //{
        //    int diff1 = 0;
        //    int diff2 = 0;
        //    int count1 = 0;
        //    int count2 = 0;
        //    int i1 = 0, j1 = 0, k1 = 0, l1 = 0;
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        for (int j = i+1; j > i && j < data.Length; j++)
        //        {

        //            int num1 = data[j] - data[i];
        //            if (count1 == 0)
        //            {
        //                diff1 = num1;
        //                i1 = i;
        //                j1 = j;
        //                count1++;
        //            }

        //            if (num1 > diff1)
        //            {
        //                i1 = i;
        //                j1 = j;
        //                diff1 = num1;
        //            }

        //            for (int k = j + 1; k > j && k < data.Length; k++)
        //            {
        //                for (int l = k+1; l > j && l < data.Length; l++)
        //                {
        //                    int num2 = data[l] - data[k];
        //                    if (count2 == 0)
        //                    {
        //                        diff2 = num2;
        //                        k1 = k;
        //                        l1 = l;
        //                        count2++;
        //                    }

        //                    if (num2 > diff2)
        //                    {
        //                        k1 = k;
        //                        l1 = l;
        //                        diff2 = num2;
        //                    }
        //                }

        //            }
        //        }
        //    }

        //    Console.WriteLine(String.Format("i={0}  j={1} k={2} l={3}", i1, j1, k1, l1));

        //    return diff2 + diff1;


        //}


        public static int ComputeMaxDiff(int[] data)
        {
            int diff1 = 0;
            int diff2 = 0;
            int count1 = 0;
            int count2 = 0;
            int i1 = 0, j1 = 0, k1 = 0, l1 = 0;
            for (int l = data.Length - 1; l >= 0; l--)
            {
                for (int k = l-1 ; k >= 0; k--)
                {

                    int num1 = data[l] - data[k];
                    if (count1 == 0)
                    {
                        diff1 = num1;
                        l1 = l;
                        k1 = k;
                        count1++;
                    }

                    if (num1> diff1)
                    {
                        l1 = l;
                        k1 = k;
                        diff1 = num1;
                    }

                    for (int j = k - 1; j >= 0 ; j--)
                    {
                        for (int i = j-1; i >= 0; i--)
                        {
                            int num2 = data[j] - data[i];
                            if (count2 == 0)
                            {
                                diff2 = num2;
                                j1 = j;
                                i1 = i;
                                count2++;
                            }

                            if (num2 > diff2)
                            {
                                j1 = j;
                                i1 = i;
                                diff2 = num2;
                            }
                        }

                    }
                }
            }

            Console.WriteLine(String.Format("i={0}  j={1} k={2} l={3}", i1, j1, k1, l1));

            return diff2 + diff1;


        }

        //public static int ComputeMaxDiff1(int[] data)
        //{
        //    int maxDiff = data[1]- data[0];
        //    for(int i = 0; i < data.Length; i++)
        //    {
        //        for (int j = i + 1; j < data.Length; j++)
        //        { }
        //    }

        //}


        public static int ComputeMaxDiff2(int[] data)
        {
            int profit = 0;

            for (int i = 1; i < data.Length; i++)
            {
                int delta = data[i] - data[i - 1];
                if (delta > 0)
                    profit = profit + delta;
            }

            return profit;

        }
    }
}
