using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class MyHashTable
    {
        //EPI 12.1 Design a hash function suitable for words in a dictionary
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="modulus"></param>
        /// <returns></returns>
        public static int StringHash(string str, int modulus)
        {
            int kMult = 997;
            int val = 0;

            foreach(char c in str.ToArray())
            {
                val = (val * kMult + c)% modulus;
            }

            return val;
        }

        //EPI 12.3
        //Note Java Map is equivalent to C# Dictionary 
        
        //People do not like reading text in which a word is used multiple times in a short paragraph.
        //You are to write a function which helps identify such a problem
        //Let s be an array of strings.  Write a function which finds a closest pair of equal entries.
        //For example, if s = ["All", "work", "and", "no", "play", "makes", "for", "no", "work", "no"
        //"fun", "and", "no", "results"], then the second and third occurrences of "no" is the closest pair.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        /// O(n2)
        public static int FindNearestRepetion1(string[] paragraph)
        {
            Dictionary<string, int> wordToLatestIndex = new Dictionary<string, int>();

            int closestDis = int.MaxValue;

            for (int i = 0; i < paragraph.Length; i++)
            {
                string targetWord = paragraph[i];
               
                for (int j = i + 1; j < paragraph.Length; j++)
                {
                    string word = paragraph[j];

                    if (word == targetWord)
                    {
                        int distance = j - i;
                        if (distance < closestDis)
                        {
                            closestDis = distance;

                            //Remember to always check in hastable if entry already exists
                            if (!wordToLatestIndex.ContainsKey(targetWord))
                                wordToLatestIndex.Add(targetWord, distance);
                            else
                                wordToLatestIndex[targetWord] = distance;
                        }
                    }
                }
            }

            return closestDis;
        }

        //O(n) is time complexity
        //O(d) is space complexity, where d is the number of distinct strings in the array
        public static int FindNearestRepetion2(string[] paragraph)
        { 
            Dictionary<string, int> wordToLatestIndex = new Dictionary<string, int>();
            int closestDis = int.MaxValue;

            for (int i = 0; i < paragraph.Length; i++)
            {
                if (wordToLatestIndex.ContainsKey(paragraph[i]))
                {
                    closestDis = Math.Min(closestDis, i - wordToLatestIndex[paragraph[i]]);
                }

                //Use this don't need to check if Hashtable already contains key, to add new key
                wordToLatestIndex[paragraph[i]] = i;
            }

            return closestDis;
        }


        //EPI 12.4 BinaryTreeCompression (CanonicalNode)
        //See BST for implementation

        //EPI 12.5
        //You are given a sequence of users where each user has a unique 32-bit integer key and a set of attributes
        //specified as strings.  When you read a user, you should pair that user with another previously read user with 
        //identical attributes who is currently unpaired, if such a user exists.  If the user cannot be paired, you should
        //keep him in the unpaired set.  How would you impolement this matching process efficiently

        //Sort the attributes (any arbitray ordering of attributes will wok).  We can represent the sorted sequence of 
        //attributes as a string by concatenating the individual elements and use a hash function for strings 

        //EPI 12.6
        //Solve 12.5 when users are grouped based on having similar attributes

        //EPI 12.7
        //Write a function that takes as input a dictionary of English words, and returns a partition of the dictionary 
        //into subsets of words that are anagrams of each

        /// <summary>
        /// 
        /// </summary>
        /// <param name="words"></param>
        public static void FindAnagrams(string[] words)
        {
            Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();

            foreach (string word in words)
            {

                string origWord = word;
                char[] charArr = word.ToCharArray();

                Array.Sort(charArr, 0, word.Length);

                string wordKey = new string(charArr);
                //wordKey = wordKey.Trim();

                List<string> wordList;

                if (anagrams.ContainsKey(wordKey))
                {
                    wordList = anagrams[wordKey];
                    wordList.Add(origWord);
                    anagrams[wordKey] = wordList;
                }
                else
                {
                    wordList = new List<string>();
                    wordList.Add(origWord);
                    anagrams.Add(wordKey, wordList);
                }
            }

            foreach (string s in anagrams.Keys)
            {
                List<string> wordList = anagrams[s];

                Console.Write(s + ": ");
                foreach (string word in wordList)
                {
                    Console.Write(word + ", ");
                }

                Console.WriteLine();
            }
        }


        //EPI 12.8 Write a program to test whether the letters forming a string s can be permuted to form a palidrome
        //O(n) time, O(n) space
        public static bool IsPalidrome1(string s)
        {
            char[] charArr = s.ToCharArray();
            Dictionary<char, int> charDict = new Dictionary<char, int>();

            foreach (char c in charArr)
            {
                if (charDict.ContainsKey(c))
                {
                    int charCount = charDict[c];
                    charDict[c] = ++charCount;   //Note must put ++ operator in front of charCount, or else wrong
                }
                else
                {
                    charDict.Add(c, 1);
                }
            }

            int oddCount = 0;

            foreach (char c in charDict.Keys)
            {
                int charCount = charDict[c];

                if (charCount % 2 != 0)
                    oddCount++;
            }

            return oddCount <= 1;
        
        }

        //O(nlogn) time, O(1) space - use this when string is very large
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsPalidrome2(string s)
        {
            char[] charArr = s.ToArray();
            Array.Sort(charArr);
            int oddCount = 0;
            int numCurrentChar = 1;

            for (int i = 1; i < charArr.Length && oddCount <=1 ; i++)
            {
                if (charArr[i] != charArr[i - 1])
                {
                    if (numCurrentChar % 2 != 0) oddCount++;  //(numCurrentChar % 2) is same as (numCurrentChar & 1)???

                    numCurrentChar = 1;
                }
                else
                {
                    numCurrentChar++;
                }
            }

            //last letter in the array that was not check in the above for loop
            //because of the condition i < charArr.Length
            if (numCurrentChar % 2 != 0) oddCount++;

            return oddCount <= 1;

        }

        //EPI 12.9 
        //A hash table can be viewed as a dictionary.  For this reason, hash tables commonly appear in string processing
        //Write a method which takes an anonymous letter L and text from a magazine M.  Your method is to 
        //return true iff L can be written using M ie. if a leter appears k times in L, it must appears at least
        //k time in M
        //Note for solution put letter strings into hashtable since letter is much smaller than magazine, save space
        public static bool AnonymousLetter(string letter, string magazine)
        {
            char[] letterArr = letter.ToArray();
            char[] magazineArr = magazine.ToArray();

            Dictionary<char, int> letterDict = new Dictionary<char, int>();

            foreach (char c in letterArr)
            {
                if (letterDict.ContainsKey(c))
                {
                    int charCount = letterDict[c];
                    letterDict[c] = ++charCount;
                }
                else
                {
                    letterDict.Add(c, 1);
                }
            }

            foreach (char c in magazineArr)
            { 
                if(letterDict.ContainsKey(c))
                {
                    int charCount = letterDict[c];
                    charCount = charCount - 1;

                    if (charCount == 0)
                        letterDict.Remove(c);
                    else
                        letterDict[c] = charCount;

                }
            }

            return letterDict.Keys.Count == 0;
        }

        //EPI 12.10 Let P be a set of n points in the plane. Design an efficient algorithm for computing a line that goes throught the most number of points in P
        //EPI 12.11 You are reading a sequence of strings separated by white space.  You are allowed to read the sequence twice.  Devise an algorithm that uses O(k)
        //memory to identify the words that occur at least ceil(n/k) times, where n is the length of the sequence.
        public static List<string> SearchFrequentItems(List<string> strings, int k)
        {
            string buf = "";
            Dictionary<string, int> hash = new Dictionary<string, int>();
            int n = 0; //counts the number of strings

            IEnumerator<string> sin = strings.GetEnumerator();

            while (sin.MoveNext())
            {
                buf = sin.Current;
                if (hash.ContainsKey(buf))
                {
                    //int stringCount = hash[buf] + 1;
                    //hash[buf] = stringCount;
                    hash[buf] = hash[buf] + 1;
                    n++;
                }
                else
                    hash.Add(buf, 1);

                //detecting k items in hash, at least one of them must have exactly one in it.  We will discard those k
                //items by one ach
                if (hash.Count == k)
                {
                    List<string> delKeys = new List<string>();
                    foreach (string key in hash.Keys)
                    {
                        if (hash[key] - 1 == 0)
                        {
                            delKeys.Add(key);
                        }

                        foreach (string s in delKeys)
                        {
                            hash.Remove(s);
                        }

                        foreach (string s in hash.Keys)
                        {
                            hash[s] = hash[s] - 1;
                        }
                    }
                }

                //Resets hash for the following counting
                foreach (string s in hash.Keys)
                {
                    hash[s] = 0;
                }

                //Counts the occurrence of each candidate word
                sin = strings.GetEnumerator();
                while(sin.MoveNext())
                {
                    buf = sin.Current;
                    int it = hash[buf];

                    if (it != null)
                        hash[buf] = it + 1;
                }
            }

            List<string> ret = new List<string>();
            foreach (string s in hash.Keys)
            {
                if (n * 1.0 / k <= (double)hash[s])
                    ret.Add(s);

            }

            return ret;
        }

        //EPI 12.12
        //Design a scheme for checking memebership in E that minimizes the number of disk accesses

        //EPI 12.13
        //Plagarism: A pair of strings is k-suspicious if they have
        //a substring of length greater than or equal to k in common
        //Design an efficient algorithm that takes as input a set of strings 
        //and positive integer k, and returns all pairs ofstrings that are k-suspicious.
        //Assume that most pairs will not be k-suspicous
        //Calculate hashcode for each substring of length k for each string and put it into hash tables. 
        //Collisions means 2 strings has same substring

        //EPI 12.14
        //Does not cover of words that have count > 1
        public static int ConverArray1(string[] A, string[] Q)
        {
            int startIndex = Int32.MaxValue;
            int endIndex = Int32.MinValue;
            int minLen = -1;
            Dictionary<string, int> dict = new Dictionary<string, int>();

            if(A.Length < Q.Length)
                return minLen;

            for (int i = 0; i < Q.Length; i++)
            {
                if (!dict.ContainsKey(Q[i]))
                    dict.Add(Q[i], -1);
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (dict.ContainsKey(A[i]))
                {
                    int currentIndex = dict[A[i]];

                    if (currentIndex < 0)       //The current position is empty i.e initialized to the value of -1 
                        dict[A[i]] = i;         //so put in a position of the index of array A (Note only put in an index if it is currently -1, because 
                                                //if it is not -1, then the current index will be bigger than what is already in there because we
                                                //are traversing the array from 0 to end so the array index is increasing
                }
            }

            foreach (string key in dict.Keys)
            {
                int index = dict[key];
                if (index < 0)              //Array A does not cover Array Q
                    return -1;
                //Go through the dictionary keys and find the smallest and biggest index
                if (index < startIndex)
                    startIndex = index;
                if (index > endIndex)
                    endIndex = index;
            }

            Console.WriteLine(string.Format("Start index is {0}, end index is {1}", startIndex, endIndex));
            return endIndex - startIndex;
        }

        public static int ConverArray2(string[] paragraph, List<string> keywords)
        {
            Dictionary<string, int> keyWordsToCount = new Dictionary<string, int>();
            
            for (int i = 0; i < paragraph.Length; i++)
            {
                if (keyWordsToCount.ContainsKey(paragraph[i]))
                    keyWordsToCount[paragraph[i]] = keyWordsToCount[paragraph[i]] + 1;
                else
                    keyWordsToCount.Add(paragraph[i], 1);
            }

            int left = 0;
            int right = paragraph.Length;

            int startIndex = Int32.MaxValue;
            int endIndex = Int32.MinValue;

            while (left < right && keywords.Count == keyWordsToCount.Count)
            {
                if (keywords.Contains(paragraph[left]))
                {
                    int keyWordCount = keyWordsToCount[paragraph[left]];
                    keyWordsToCount[paragraph[left]] = --keyWordCount;

                    if (keyWordCount == 0)
                        keyWordsToCount.Remove(paragraph[left]);

                    if (left > startIndex)
                        startIndex = left;

                }
            }

            return 0;
        }

        //http://en.wikipedia.org/wiki/Bloom_filter
        public static void MainHash(string[] args)
        {
            string hashString1 = "Kenlieu21isgreat!";
            string hashString2 = "!enlieu21isgreatK";

            Console.WriteLine(String.Format("The hash of {0} is {1}.", hashString1, MyHashTable.StringHash(hashString1, 1 << 16)));
            Console.WriteLine(String.Format("The hash of {0} is {1}.", hashString2, MyHashTable.StringHash(hashString2, 1 << 16)));

            string[] nearestRepetionString = { "All", "work", "and", "no", "play", "makes", "for", "no", "work", "no", "fun", "and", "no", "resutl" };
            Console.WriteLine("The closest repetition in O(n2) is " + MyHashTable.FindNearestRepetion1(nearestRepetionString)); ;
            Console.WriteLine("The closest repetition in O(n) is " + MyHashTable.FindNearestRepetion2(nearestRepetionString));

            string[] anagramArr = { "eleven plus two", "twelve plus one", "one", "two", "tom", "omt" };
            MyHashTable.FindAnagrams(anagramArr);


            string palidromeStr1 = "rotator";
            string palidromeStr2 = "level";
            string palidromeStr3 = "levnel";

            Console.WriteLine(String.Format("The string {0} can be permuted to form a palindrome {1}.", palidromeStr1, MyHashTable.IsPalidrome1(palidromeStr1)));
            Console.WriteLine(String.Format("The string {0} can be permuted to form a palindrome {1}.", palidromeStr2, MyHashTable.IsPalidrome1(palidromeStr2)));
            Console.WriteLine(String.Format("The string {0} can be permuted to form a palindrome {1}.", palidromeStr3, MyHashTable.IsPalidrome1(palidromeStr3)));
            Console.WriteLine(String.Format("The string {0} can be permuted to form a palindrome {1}.", palidromeStr1, MyHashTable.IsPalidrome2(palidromeStr1)));
            Console.WriteLine(String.Format("The string {0} can be permuted to form a palindrome {1}.", palidromeStr2, MyHashTable.IsPalidrome2(palidromeStr2)));
            Console.WriteLine(String.Format("The string {0} can be permuted to form a palindrome {1}.", palidromeStr3, MyHashTable.IsPalidrome2(palidromeStr3)));

            string anonLetter1 = "i am great";
            string anonLetter2 = "fox lady";
            string anonMagazine = "the quick brown fox jumped over the lazy dog";

            Console.WriteLine(string.Format("Can letter '{0}' be written with magazine '{1}': {2}", anonLetter1, anonMagazine, MyHashTable.AnonymousLetter(anonLetter1, anonMagazine)));

            Console.WriteLine(string.Format("Can letter '{0}' be written with magazine '{1}': {2}", anonLetter2, anonMagazine, MyHashTable.AnonymousLetter(anonLetter2, anonMagazine)));


            //List<string> frequencyList = new List<string> { "one", "two", "three", "four", "four", "four" , "five", "five", "five" };
            //List<string> frequencyListReturn = MyHashTable.SearchFrequentItems(frequencyList, 3);

            //foreach (string s in frequencyListReturn)
            //{
            //    Console.Write(s + " ");
            //}

            //string[] coverArray1 = { "My", "gosh", "you", "are", "the", "most", "best", "interesting", "person", "there", "is", "I", "am", "your", "greatest", "friend"};
            //string[] coverArray1 = { "My", "gosh", "you", "are", "the", "most", "best", "interesting", "person", "there", "is", "I", "your", "greatest", "friend", "am"};
            //string[] coverArray1 = { "My", "gosh", "you", "are", "the", "most", "best", "interesting", "person", "there", "is", "I", "your", "greatest", "friend", "am"};
            string[] coverArray1 = { "My", "gosh", "you", "are", "you", "the", "most", "best", "interesting", "person", "there", "is", "I", "your", "greatest", "friend", "am" };


            string[] coverArray2 = {"you", "are", "most", "am", "best"};

            List<string> keywords = new List<string>();
            keywords.Add("you");
            keywords.Add("are");
            keywords.Add("most");
            keywords.Add("am");
            keywords.Add("best");
            Console.WriteLine("Minimum length to cover array is " + MyHashTable.ConverArray1(coverArray1, coverArray2));
            Console.WriteLine("Minimum length to cover array is " + MyHashTable.ConverArray2(coverArray1, keywords));

            Console.Read();
        }
    }

    
}
