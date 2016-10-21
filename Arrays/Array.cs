using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class MyArray
    {
        public static int FindMissingNumber(int[] consecNumbersArr)
        {
            int arrSum = 0;
            for (int i = 0; i < consecNumbersArr.Length; i++)
            {
                arrSum +=  consecNumbersArr[i];
            }

            double arrLength = consecNumbersArr.Length;
            double count =  Math.Ceiling((double)arrLength / 2);
                
            double sum =     count *(consecNumbersArr[0] + consecNumbersArr[(int)arrLength - 1]);
            return (int)sum - arrSum;

        }

        public static int FindNumberAppearingTwice(int[] consecNumbersArr)
        {
            int arrSum = 0;
            for (int i = 0; i < consecNumbersArr.Length; i++)
            {
                arrSum += consecNumbersArr[i];
            }

            double arrLength = consecNumbersArr.Length-1;  //********************
            double count = Math.Ceiling((double)arrLength / 2);

            double sum = count * (consecNumbersArr[0] + consecNumbersArr[(int)consecNumbersArr.Length - 1]);
            return arrSum - (int)sum;

        }

        public static void RotateArrayToRight(int[] arr, int n)
        {
            int lastIndex = arr.Length - 1;
            for (int i = 0; i < arr.Length; i++)
            {
                int newPos = i + n;

                if (newPos > arr.Length)
                {
                    newPos = newPos%arr.Length;
                    int temp = arr[newPos];
                    arr[newPos] = temp;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="maxIndex1"></param>
        /// <param name="maxIndex2"></param>
        public static void LongestIncreasingSubArray(int[] arr, out int maxIndex1, out int maxIndex2)
        {
            int max = 0;
            maxIndex1 = 0;
            maxIndex2 = 0;

            int index1 = 0;
            int index2 = 0;
            int currentSum = 0;

            while (index1 < arr.Length & index2 < arr.Length)
            {
                int currentNum = arr[index2];
                if (currentNum < 0)
                {
                    if (currentSum > max)
                    {
                        max = currentSum;
                        maxIndex1 = index1;
                        maxIndex2 = index2;
                    }

                    currentSum = 0;
                    index2++;
                    index1 = index2;
                }
                else
                {
                    currentSum += currentNum;
                }
            }
        }
    }
}
