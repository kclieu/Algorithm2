using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class LongestNondecreasingSubsequence
    {
        //public static int[] FindLongestNonDecreasingSubsequent(int[] arr)
        //{
        //    if (arr.Length == 0)
        //        return arr;

        //    int[] longest = new int[arr.Length];
        //    int[] previousIndex = new int[arr.Length];

        //    for (int i = 0; i < arr.Length; i++ )
        //    {
        //        longest[i] = 1;
        //        previousIndex[i] = -1;
        //    }

        //    int maxLengthIndex = 0;
        //    for (int i = 1; i < arr.Length; i++)
        //    {
        //        for (int j = 0; j < i; j++)
        //        {
        //            if (arr[i] >= arr[j] && longest[j] + 1 > longest[i])
        //            {
        //                longest[i] = longest[j] + 1;
        //                //previousIndex[i] = 
        //            }
        //        }
        //    }
        //}
    }
}
