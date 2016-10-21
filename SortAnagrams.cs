using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class SortAnagrams
    {
        public static string[] SortAnagramArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                string word = arr[i];
                int currPos = i+1;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    string target = arr[j];

                    if (IsAnagram(word, target))
                    {
                        string victim = arr[currPos];
                        arr[currPos] = target;
                        arr[j] = victim;
                    }
                }
            }

            return arr;
        }

        public static bool IsAnagram(string word1, string word2)
        {
            if (word1.Length != word2.Length)
                return false;

            char[] arr1 = word1.ToCharArray();
            char[] arr2 = word2.ToCharArray();

            string str1 = SortStringArr(arr1);
            string str2 = SortStringArr(arr2);

            return str1.Equals(str2);
        }

        public static string SortStringArr(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < i && j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        char temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr.ToString().ToLower();
        }

        public static void Print(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
        }
    }
}
