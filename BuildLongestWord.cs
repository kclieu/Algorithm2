using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //CCI 18.7
    public static class BuildLongestWord
    {

        public static string PrintLongestWord(string[] arr)
        {
            Dictionary<string, bool> map = new Dictionary<string, bool>();

            foreach (string str in arr)
            {
                map.Add(str, true);
            }

            arr = arr.OrderBy(a => a.Length).ToArray();

            foreach (string s in arr)
            {
                if (CanBuildWord(s, true, map))
                {
                    Console.WriteLine(s);
                    //return s;
                }
            }

            return "";
        }
        public static bool CanBuildWord(string str, bool isOriginalWord, Dictionary<string, bool> map)
        {
            str = str.ToLower();
            if (map.ContainsKey(str) && !isOriginalWord)
            {
                return map[str];
            }

            for (int i = 1; i < str.Length; i++)
            {
                string left = str.Substring(0, i);
                string right = str.Substring(i);

                if (map.ContainsKey(left) && map[left] == true
                    && CanBuildWord(right, false, map))
                    return true;
            }

            if(!map.ContainsKey(str))
                map.Add(str, false);

            return false;
        }

        public static void MainBuildLongestWord(string[] args)
        {

            //string[] words = File.ReadLines(@"C:\Users\Ken\Documents\Visual Studio 2013\Algos\Data\WordDictionary.txt").ToArray();

            string[] words = { "ant", "anteaterup", "eater", "anthropology", "at", "teat", "eat", "up"};



            PrintLongestWord(words);

            Console.Read();
        }
    }
}
