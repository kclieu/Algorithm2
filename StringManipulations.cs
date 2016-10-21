using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class StringManipulations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseString(string s)
        {
            char[] arr = s.ToArray();
            int index = (int)arr.Length / 2;
            int lastIndex = arr.Length;

            for (int i = 0; i < index; i++)
            {
                char temp = arr[--lastIndex];
                arr[lastIndex] = arr[i];
                arr[i] = temp;
            }

            //string ret = arr.ToString();  This is wrong
            string ret = new string(arr);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseString2(string s)
        {
            char[] arr = s.ToArray();
            int endIndex = s.Length - 1;
            int startIndex = 0;

            while (endIndex > startIndex)
            {
                char ch = arr[startIndex];
                arr[startIndex] = arr[endIndex];
                arr[endIndex] = ch;
                endIndex--;
                startIndex++;
            }

            return new string(arr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool IsSubstring(string s1, string s2)
        {
            return IsSubstringHelper(s1, s2) || IsSubstringHelper(s2, s1);
        }

        private static bool IsSubstringHelper(string s1, string s2)
        {
            bool isSubstring = false;
            int s2Length = s2.Length;

            int i = 0;
            int j =  i + s2.Length;

            while(i <= s1.Length && j <= s1.Length)
            {
                string subString = Substring(s1, i, j);

                if(subString == s2)
                    return true;

                i++;
                j = i + s2.Length;
            }

            return isSubstring;
        }

        private static string Substring(string s, int index1, int index2)
        {
            char[] arr = s.ToArray();
            return new string(arr, index1, index2 - index1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CompactString(string s)
        {
            char[] arr = s.ToArray();
            string tempStr = string.Empty;
            int subStringLeng = 0;
            int i = 0;

            while( i < arr.Length)
            {
                char target = arr[i];
                subStringLeng++;
                tempStr += target.ToString();
                
                int j = i+1;
                while (j < arr.Length && arr[j] == target)
                {
                    subStringLeng++;
                    j++;
                }

                tempStr += subStringLeng;
                subStringLeng = 0;
                i = j;
            }

            return tempStr;
        }

        public static void SetZeroMatrix(int[][] matrix)
        {
            int[] row = new int[matrix.Length];
            int[] column = new int [matrix[0].Length];

            for (int i = 0; i < row.Length; i++)
            {
                for (int j = 0; j < column.Length; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        row[i] = 1;
                        column[j] = 1;
                    }
                }
            }

            for (int i = 0; i < row.Length; i++)
            {
                for (int j = 0; j < column.Length; j++)
                {
                    if (row[i] == 1 || column[j] == 1)
                        matrix[i][j] = 1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static char FindFirstNonRepeatCharacter1(string s)
        {
            Dictionary<char, bool> searchedTable = new Dictionary<char, bool>();

            char[] chars = s.ToArray();
            char target = ' ';
            for (int i = 0; i < chars.Length; i++)
            {
                bool found = false;
                target = chars[i];

                if (searchedTable.ContainsKey(target))
                    continue;
                searchedTable.Add(target, true);

                for (int j = i + 1; j < chars.Length; j++)
                {
                    if (chars[j] == target)
                    {
                        found = true;
                        //foundTable.Add(target, true);
                        break;
                    }
                }

                if (!found)
                    return target;
            }

            return target;
        }

        public static char FindFirstNonRepeatCharacter2(string s)
        {
            Dictionary<char, int> searchedTable = new Dictionary<char, int>();
            char[] chars = s.ToArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char target = chars[i];
                if (searchedTable.ContainsKey(target))
                {
                    int count = searchedTable[target];
                    searchedTable[target] = target++;
                }
                else
                {
                    searchedTable[target] = 1;
                }
            }

            for (int i = 0; i < chars.Length; i++)
            {
                char target = chars[i];
                int count = searchedTable[target];

                if (count == 1)
                    return target;
            }

            return ' ';

        }

        public static string RemoveChars(string target, string remove)
        {
            char[] targetStr = target.ToArray();
            char[] removeStr = remove.ToArray();
            string returnStr = string.Empty;

            for (int i = 0; i < targetStr.Length; i++)
            {
                bool isRemoved = false;
                for (int j = 0; j < removeStr.Length; j++)
                {
                    char ch = removeStr[j];

                    if (targetStr[i] == ch)
                    {
                        isRemoved = true;
                    }
                }

                if (!isRemoved)
                    returnStr += targetStr[i];
            }

            return returnStr;
        }

        //public static string ReverseWords(string words)
        //{
        //    string[] wordArr = words.Split(new char[] { ' ' });
        //    int index = wordArr.Length / 2;
        //    int length = wordArr.Length;

        //    for (int i = 0; i < index; i++)
        //    {
        //        string temp = wordArr[i];
        //        wordArr[i] = wordArr[--length];
        //        wordArr[length] = temp;
        //    }

        //    string retWords = string.Empty;
        //    for(int i = 0; i < wordArr.Length; i++)
        //    {
        //        retWords += wordArr[i] + " ";
        //    }
        //    retWords = retWords.TrimEnd();
        //    return retWords;
        //}

        //public static string ReverseWords(string words)
        //{
        //    int endIndex = words.Length-1;
        //    int startIndex = 0;
        //    for (int i = endIndex; i != 0; i--)
        //    {


        //        char ch = words[i];
        //        if (ch == ' ')
        //        { }


        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int StringToInt(string s)
        {
            char[] charArr = s.ToArray();
            int index = charArr.Length - 1;
            int sum = 0;
            int loopCount = 0;
            int firstChar = 0;
            bool isNeg = false;

            if (charArr[0] == '-')
            {
                isNeg = true;
                firstChar = 1;
            }

            for (int i = index; i >= firstChar; i--)
            {
                char ch = charArr[i];
                int val = ch - '0';

                for (int j = 1; j <= loopCount; j++)
                {
                    val *= 10;
                }

                sum += val;
                loopCount++;
            }

            if (isNeg)
                sum *= -1;

            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntToString(int num)
        {
            int MAX_DIGITS = 10;
            int i = 0;
            bool isNeg = false;

            char[] temp = new char[MAX_DIGITS + 1];

            if (num < 0)
            {
                num = -num;
                isNeg = true;
            }

            do
            {
                temp[i++] = (char)((num % 10) + '0');
                num /= 10;
            } while (num != 0);

            StringBuilder b = new StringBuilder();

            if (isNeg)
                b.Append('-');

            while (i > 0)
                b.Append(temp[--i]);

            return b.ToString();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string IntToString2(int n)
        {
            int num = n;
            char[] strArray = new char[10];
            int index = 0;

            bool isNeg = false;

            if (n < 0)
            {
                isNeg = true;
                num = num * (-1);
            }


            while (num > 0)
            {
                int rem = num % 10;  //take the remainder
                char ch = (char)(rem + '0');
                strArray[index++] = ch;
                num = num / 10; //divide
            }

            if (isNeg)
                strArray[index++] = '-';

            //Reverse and copy the char array

            char[] newArr = new char[index];
            int newArrIndex = 0;

            for (int i = index - 1; i >= 0; i--)
            {
                newArr[newArrIndex++] = strArray[i];
            }

            return new string(newArr);

        }


        /////////////////////////////////
        public static bool IsRotate(string s1, string s2)
        {
            int len = s1.Length;

            if (len == s2.Length)
            {
                string str = s1 + s1;
                return IsSubstring(str, s2);
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool CanBePalidrome(string s)
        {
            char[] arr = s.ToArray();
            Dictionary<char, int> table = new Dictionary<char, int>();

            foreach (char c in arr)
            {
                int num = 1;
                if (table.ContainsKey(c))
                {
                    num = table[c];
                    table[c] = ++num;
                }
                else
                {
                    table.Add(c, num);
                }
            }

            int oddCount = 0;

            foreach(char c in table.Keys)
            {
                int val = table[c];

                if ((val % 2) > 0)
                    oddCount++;
            }

            return oddCount < 2;
        }


        /// <summary>
        ///Get permutations of a string 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> GetPermuations(string str)
        {
            if (str == null)
                return null;

            List<string> permutations = new List<string>();
            if (str.Length == 0)
            {
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

        //CCI 17.14
        //Given a string and a dictionary of works, find out if the input string
        //can be segmented into space-separated sequence of dictionary words
        public static bool DictionaryContains(string word)
        {
            string[] dictionary = { "i", "reset", "the", "computer", "it", "still", "did", "not", "boot" };

            for (int i = 0; i < dictionary.Length; i++)
            {
                if (dictionary[i] == word)
                    return true;

            }
            return false;
        }

        public static bool WordBreak(string str)
        {
            int len = str.Length;

            if (len == 0)
                return true;

            for (int i = 1; i <= len; i++)
            {
                string s1 = str.Substring(0, i);
                string s2 = str.Substring(i, len - i);

                if(DictionaryContains(str.Substring(0, i)) 
                && WordBreak(str.Substring(i, len - i)))
                    return true;
            }
            return false;
        }

        //CCI 18.7
        //Given a list of words, write a program to find the longest word made of other
        //words in the list
        public static string PrintLongestWord(string[] arr)
        { 
            string candidate = string.Empty;
            Dictionary<string, bool> dict = new Dictionary<string, bool>();

            for (int i = 0; i < arr.Length; i++)
            {
                dict.Add(arr[i], true);
            }

            for (int i = 0; i < arr.Length; i++) 
            { 
                string word = arr[i];

                for (int j = 1; j < word.Length; j++)
                {
                    string left = word.Substring(0, j);
                    string right = word.Substring(j);

                    if (dict.ContainsKey(left) && dict.ContainsKey(right))
                    {
                        if (word.Length > candidate.Length)
                            candidate = word;
                    }
                }
            }

            return candidate;
        }

        //CCI 18.8
        //Give a string s and an array of smaller strings T, design a method to
        //search s for each small string in T


        //CCI 18.10
        //Given 2 words of equal length that are in a dictionary, write a method to transform
        //one word into another word by changing only one letter at a time.  The new word
        //you get in each step must be in the dictioany
        
        //Application of Breadth-First-Search. Each word in our 'graph' branches
        //to all words in the dictionary that are one edit away. The interesting
        //part is the implementation.  Specically, should we build a graph as we go?

        //We could but there's an easier way.  We can instead use a 'backtrack map'.
        //In this track map if B[v] = w, then you know that you edited v to get w.
        //When we reach our end word, we can use this back track map repeatedly to 
        //reverse our path

        public static List<string> Transform(string startWord, string stopWord, HashSet<string> dictionary)
        {
            startWord = startWord.ToUpper();
            stopWord = stopWord.ToUpper();
             

            Queue<string> actionQueue = new Queue<string>();
            HashSet<string> visitedSet = new HashSet<string>();
            Dictionary<string, string> backtrackMap = new Dictionary<string, string>();

            actionQueue.Enqueue(startWord);
            visitedSet.Add(startWord);

            while (actionQueue.Count > 0)
            {
                //string w = actionQueue.Peek();
                string w = actionQueue.Dequeue();

                //For each possible word v from w with one edit operation
                foreach(string v in GetOneEditWords(w))
                {
                    if (v.Equals(stopWord))
                    {
                        //Found our word! Now, back track.
                        List<string> list = new List<string>();
                        
                        //Append v to list
                        list.Add(v);

                        while (w != null)
                        {
                            list.Insert(0, w);
                            w = backtrackMap[w];
                        }
                        return list;
                    }

                    //if v is a dictionary word
                    if(dictionary.Contains(v))
                    {
                        if (!visitedSet.Contains(v))
                        {
                            actionQueue.Enqueue(v);
                            visitedSet.Add(v); //marked visited
                            backtrackMap.Add(v, w);
                        }
                    }
                }
            }

            return null;
        }

        static HashSet<string> GetOneEditWords(string word)
        {
            HashSet<string> words = new HashSet<string>();

            for (int i = 0; i < word.Length; i++)
            {
                char[] wordArray = word.ToCharArray();

                //change that letter to something else

                for (char c = 'A'; c <= 'Z'; c++)
                {
                    if (c != word[i])
                    {
                        wordArray[i] = c;
                        words.Add(new string(wordArray));
                    }
                }
            }

            return words;
        }

        //////////////////////////////////////////////////////////  Test Implementation
       /// <summary>
       /// 
       /// </summary>
       /// <param name="str"></param>
       /// <returns></returns>
        public static int StringToInt2(string str)
        {
            int sum = 0;
            int first = 0;
            int loopCounter = 0;
            int index = str.Length - 1;

            bool isNeg = false;

            char[] arr = str.ToArray();

            if (arr[0] == '-')
            {
                isNeg = true;
                first = 1;
            }

            for (int i = index; i >= first; i--)
            {
                char ch = arr[i];
                int val = ch - '0';
                int product = 1;

                for (int j = 0; j < loopCounter; j++)
                {
                    product = product * 10;
                }
                sum += val * product;
                loopCounter++;
            
            }

            if (isNeg)
                sum = (-1) * sum;
            return sum;
        }


        static void MainStringManips(string[] args)
        {
            Console.WriteLine("Can break this word ? " + StringManipulations.WordBreak("iresetthecomputeritstillnotboot"));
      
            string startWord = "BANANA";
             
            string stopWord = "CINANA";

            string transitionWord1 = "CANANA";

            Console.WriteLine("Transform " + startWord + " to " + stopWord);
            
            HashSet<string> dictionary = new HashSet<string>();
            dictionary.Add(startWord);
            dictionary.Add(stopWord);
            dictionary.Add(transitionWord1);


            List<string> transformList = Transform(startWord, stopWord, dictionary);

            foreach (string w in transformList)
            {
                Console.Write(w + " ");
            }

            
            string[] longestWordCandidates = { "I", "am", "the", "best", "intelligent", "thebest", "theintelligent" };

            Console.WriteLine("Find the longest word in the list composed of 2 other words " + StringManipulations.PrintLongestWord(longestWordCandidates));

            string permuationStr = "abc";
            List<string> permulationList = StringManipulations.GetPermuations(permuationStr);

            Console.WriteLine("Permuations of " + permuationStr + " is ");
            foreach (string permS in permulationList)
                Console.Write(permS + " ");
            Console.Read();

            

        }
    }

    //class SearchProgram
    //{
    //    static void MainSearch(string[] args)
    //    { }
    //}
}
