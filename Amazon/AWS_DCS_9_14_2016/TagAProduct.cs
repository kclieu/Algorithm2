using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.Amazon
{

    //http://articles.leetcode.com/finding-minimum-window-in-s-which/
    //http://stackoverflow.com/questions/19206589/find-length-of-smallest-window-that-contains-all-the-characters-of-a-string-in-a
    public class TagAProduct
    {
        

        public static void MainTagAProduct(string[] args)
        {
            args = new string[2];
            args[0] = "in the spain";
            args[1] = "the weather forecast says that the rain in spain stays";
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */

            if (args == null)
                return;

            if (args.Length != 2)
                return;

            string productTag = args[0];
            string paperRoll = args[1];

            string[] tags = productTag.Split(new char[] { ' ' });
            //string[] rollArr = paperRoll.Split(new char[] { ' ' });
            List<string> rollList = paperRoll.Split(new char[] { ' ' }).ToList();

            Dictionary<string, int> wordDict = new Dictionary<string, int>();

            //for (int i = 0; i < rollArr.Length; i++)
            //{
            //    if (!wordDict.ContainsKey(rollArr[i]))
            //        wordDict.Add(rollArr[i], i);
            //}

            //int min = -1;
            //int max = int.MaxValue;

            //for (int i = 0; i < tags.Length; i++)
            //{
            //    string tag = tags[i];

            //    if (!wordDict.ContainsKey(tag))
            //    {
            //        Console.Write("No Solution");
            //        return;
            //    }

            //    int tagPosition = wordDict[tag];

            //    if (tagPosition < min)
            //        min = tagPosition;
            //    if (tagPosition > max)
            //        max = tagPosition;
            //}

            

            for (int i = 0; i < tags.Length; i++)
            {
                string target = tags[i];

                if (rollList.Contains(target))
                {
                    int index = rollList.IndexOf(target);

                    if (wordDict.ContainsKey(target))
                        wordDict[target] = index;
                    else
                        wordDict.Add(target, index);

                }
                else
                {
                    Console.Write("No Solution");
                    return;
                }
            }

            int minIndex = -1;
            int maxIndex = int.MaxValue;

            foreach (string key in wordDict.Keys)
            {
                int index = wordDict[key];

                if (index > minIndex)
                    minIndex = index;

                if (index < maxIndex)
                    maxIndex = index;
            }


            string returnVal = minIndex.ToString() + ", " + maxIndex.ToString();

            if (!string.IsNullOrEmpty(returnVal))
                Console.Write(returnVal);
            else
                Console.Write("No Solution");


            Console.Read();
        }


        //http://www.programcreek.com/2014/05/leetcode-minimum-window-substring-java/
        public string MinWindow(string s, string t)
        {
            if (t.Length > s.Length)
                return "";

            string result = "";

            Dictionary<string, int> target = new Dictionary<string, int>();
            string[] strArr = t.Split(new char[] { ' ' });

            for (int i = 0; i < strArr.Length; i++)
            {
                if (target.ContainsKey(strArr[i]))
                    target[strArr[i]] = target[strArr[i]] + 1;
                else
                    target.Add(strArr[i], 1);
            }

            //Character counter for s
            Dictionary<string, int> map = new Dictionary<string, int>();
            int left = 0;
            int minLen = s.Length + 1;

            int count = 0; //total of mapped words;
            string[] mappedArr = s.Split(new char[] { ' ' });

            for (int i = 0; i < mappedArr.Length; i++)
            {
                string str = mappedArr[i];

                if (target.ContainsKey(str))
                {
                    if (map.ContainsKey(str))
                    {
                        if (map[str] < target[str])
                        {
                            count++;
                        }
                        map[str] = map[str] + 1;
                    }
                    else
                    {
                        map.Add(str, 1);
                        count++;
                    }
                }

                if (count == t.Length)
                {
                    string sc = mappedArr[left];

                    while (!map.ContainsKey(sc) || map[sc] > target[sc])
                    {
                        if (map.ContainsKey(sc) && map[sc] > target[sc])
                            map[sc] = map[sc] - 1;
                        left++;
                        sc = mappedArr[left];
                    }

                    if (i - left + 1 < minLen)
                    {
                        result = mappedArr[i];
                        ////////////////////////////////
                    }
                }
            }

            return result;
            


            return "";
        }
    }
}
