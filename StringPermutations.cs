using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class StringPermutations
    {
        public static List<string> GetPermuations(string str)
        {
            if (str == null)
                return null;

            List<string> permutations = new List<string>();
            if (str.Length == 0) {
                permutations.Add("");
                return permutations;
            }

            char first = str[0];
            string remainder = str.Substring(1);
            List<string> words = GetPermuations(remainder);

            foreach (string word in words)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    string s = InsertCharAt(word, first, j);
                    permutations.Add(s);
                }
            }

            return permutations;
        }

        public static string InsertCharAt(string word, char c, int i)
        {
            string start = word.Substring(0, i);
            string end = word.Substring(i);
            return start + c + end;
        }

        public static void Print(List<string> words)
        {
            foreach (string word in words)
            {
                Console.Write(word + ", ");
            }
        }
    }
}
