using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.BFS
{
    //CCI 18.10
    public static class TransformWords
    {
        public static List<string> Transform(string startWord, string stopWord, HashSet<string> dictionary)
        {
            startWord = startWord.ToLower();
            stopWord = stopWord.ToLower();

            Queue<string> actionQueue = new Queue<string>();
            HashSet<string> visitedSet = new HashSet<string>();
            Dictionary<string, string> backtrackMap = new Dictionary<string, string>();

            actionQueue.Enqueue(startWord);
            visitedSet.Add(startWord);

            while (actionQueue.Count > 0)
            {
                string w = actionQueue.Dequeue();

                HashSet<string> wwww = GetOneEditWords(w);

                foreach (string word in GetOneEditWords(w))
                {
                    if (word.Equals(stopWord))
                    {
                        //Found our workd! now, back track.
                        List<string> list = new List<string>();
                        list.Add(word);

                        while (w != null)
                        {
                            list.Insert(0, w);

                            if (backtrackMap.ContainsKey(w))
                                w = backtrackMap[w];
                            else
                                w = null;
                        }

                        return list;
                    }

                    //word is a dictionary word
                    if (dictionary.Contains(word))
                    {
                        if (!visitedSet.Contains(word))
                        {
                            actionQueue.Enqueue(word);
                            visitedSet.Add(word); //marked visited
                            backtrackMap.Add(word, w);
                        }
                    }
                }
            }

            return null;
                 
        }

        public static HashSet<string> GetOneEditWords(string word)
        {
            HashSet<string> words = new HashSet<string>();

            for (int i = 0; i < word.Length; i++)
            {
                char[] wordArray = word.ToArray();
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (c != word.ElementAt(i))
                    {
                        wordArray[i] = c;
                        words.Add(new string(wordArray));
                    }
                }
            }

            return words;
        }

        public static void MainTransform(string[] args)
        {
            List<string> words = File.ReadLines(@"C:\Users\Ken\Documents\Visual Studio 2013\Algos\Data\WordDictionary.txt").ToList();
            HashSet<string> dictionary = new HashSet<string>();

            foreach (string word in words)
            {
                dictionary.Add(word);
            }


            //List<string> list = Transform("duck", "lick", dictionary);

            List<string> list = Transform("duck", "line", dictionary);

            foreach (string word in list)
            {
                Console.WriteLine(word);
            }

            Console.Read();
        }

    }
}
