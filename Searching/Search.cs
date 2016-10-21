using System;
using System.Collections.Generic;

namespace Algos
{
    public class Search
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] a, int x)
        {
            int low = 0;
            int high = a.Length - 1;
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;

                if (a[mid] < x)
                    low = mid + 1;
                else if (a[mid] > x)
                    high = mid - 1;
                else
                    return mid;
            }

            return -1;  //Error
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        /// 
        public static int BinarySearchRecursive(int[] a, int x)
        {
            return BinarySearchRecursive(a, x, 0, a.Length - 1);
        }

        public static int BinarySearchRecursive(int[] a, int x, int low, int high)
        {
            if (low > high) return -1; //Error

            int mid = (low + high) / 2;

            if (a[mid] < x)
                return BinarySearchRecursive(a, x, mid + 1, high);
            else if (a[mid] > x)
                return BinarySearchRecursive(a, x, 0, mid - 1);
            else
                return mid;
        }


        //CCI 11.1
        //You are given two sorted arrays, A and B, where A has a large enough buffer 
        //at the end to hold B. Write a method to merge B into A in sorted order.
        public static int[] MergeSortedArrays(int[] a1, int[] a2)
        {
            int[] merged = new int[a1.Length + a2.Length];

            int i = 0;
            int j = 0;
            int mergedIndex = 0;
            while (i < a1.Length && j < a2.Length)
            {
                if (a1[i] < a2[j])
                {
                    merged[mergedIndex++] = a1[i++];
                }
                else if (a1[i] > a2[j])
                {
                    merged[mergedIndex++] = a2[j++];
                }
                else if (a1[i] == a2[j])
                {
                    merged[mergedIndex++] = a1[i++];
                    merged[mergedIndex++] = a2[j++];

                }
            }

            while (i < a1.Length)
            {
                merged[mergedIndex++] = a1[i++];
            }

            while (j < a2.Length)
            {
                merged[mergedIndex++] = a2[j++];
            }

            return merged;
        }

        //CCI 11.2
        //Write a method to sort an array of strings so that all the anagrams are 
        //next to each other

        //O(n)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static void SortAnagram(string[] arr)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string,List<string>>();

            foreach (string s in arr)
            {
                string key = SortChars(s);
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<string>());
                }

                dict[key].Add(s);
            }

            int index = 0;
            
            //Convert hash table to array
            foreach (string key in dict.Keys)
            { 
                List<string> list = dict[key];

                foreach (string t in list)
                {
                    arr[index] = t;
                    index++;
                }
            }
        }

        public static string SortChars(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort(content);
            return new string(content);
        }

        //CCI 11.4
        //Imagine you have a 20 GB file with one string per line. Explain bow you would sort the file.
        //When an interviewer gives a size limit of 20 gigabytes, it should tell you something. 
        //In this case, it suggests that they don't want you to bring all the data into memory.
        //So what do we do? We only bring part of the data into memory. We'll divide the file into 
        //chunks which are x megabytes each, where x is the amount of memory we have available. 
        //Each chunk is sorted separately and then saved back to the file system. Once all the chunks
        //are sorted, we then merge the chunks, one by one. At the end, we have a fully sorted file.
        //This algorithm is known as external sort.

        //CCI 11.5 
        //Given a sorted array of strings which is interspersed with empty strings, write a
        //method to find the location of a given string.

        //If it weren't for the empty strings, we could simply use binary search.  We could
        //compare the string to be found str with the midpoint of the array and go from there.
        //With empty string interspersed, we can implement a simple modification of the binary
        //search.  All we need to do is ifx the comparison against mid in case mid is an
        //empty string.  We simply move mid to the closest non-empty string.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int SearchString(string[] strings, string str)
        {
            if (strings == null || str == null || str == "")
                return -1;

            return SearchStringR(strings, str, 0, strings.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="str"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static int SearchStringR(string[] strings, string str, int first, int last)
        {
            if (first > last) return -1;

            //move mid to the middle
            int mid = (last + first) / 2;

            //if mid is empty, find closes non-empty string
            if (strings[mid] == "")
            {
                int left = mid - 1;
                int right = mid + 1;

                while (true)
                {
                    if (left < first && right > last)
                    {
                        return -1;
                    }
                    else if (right <= last && strings[right] != "")
                    {
                        mid = right;
                        break;
                    }
                    else if (left >= first && strings[left] != "")
                    {
                        mid = left;
                        break;
                    }

                    right++;
                    left--;
                }
            }

            //Check for string, and recurse if necessary
            if (str.Equals(strings[mid]))  //Found it!
                return mid;
            else if (strings[mid].CompareTo(str) < 0)
            {
                //Search right
                return SearchStringR(strings, str, mid + 1, last);
            }
            {
                //Search left
                return SearchStringR(strings, str, first, mid - 1);
            }
        }

        //CCI 11.6
        //EPI 11.10
        //Given an MX N matrix in which each row and each column is sorted in ascending
        //order, write a method to find an element.
        public static bool FindElement(int[][] matrix, int element)
        {
            int row = 0;
            int col = matrix[0].Length - 1;

            while (row < matrix.Length && col >= 0)
            {
                if (matrix[row][col] == element)
                {
                    return true;
                }
                else if (matrix[row][col] > element)
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            return false;
        }

        //Find longest increasing subsequence
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
        public static int IncreasingSubsequence(int[] seq)
        {
            int[] L = new int[seq.Length];
            L[0] = 1;

            for (int i = 1; i < L.Length; i++)
            {
                int maxN = 0;

                for (int j = 0; j < i; j++)
                {
                    if (seq[j] < seq[i] && L[j] > maxN)
                    {
                        maxN = L[j]; 
                    }
                }

                L[i] = maxN + 1;
            }

            int maxI = 0;

            for (int i = 0; i < L.Length; i++)
            {
                if (L[i] > maxI)
                {
                    maxI = L[i];
                }
            }

            return maxI;
        }

        //CCI 11.7
        //A circus is designing a tower routine consisting of people standing atop one another's
        //shoulders. For practical and aesthetic reasons, each person must be both shorter
        //and lighter than the person below him or her. Given the heights and weights of
        //each person in the circus, write a method to compute the largest possible number
        //of people in such a tower.

        //Longest Increasing Subsequence of Pairs
        //http://stackoverflow.com/questions/8716934/longest-increasing-subsequence-lis-with-two-numbers
        //http://stackoverflow.com/questions/2631726/how-to-determine-the-longest-increasing-subsequence-using-dynamic-programming
        //https://www.youtube.com/watch?v=4fQJGoeW5VE&list=PL5jc9xFGsL8HUjOj71_EZAryBp5ZpLsaR
        //O(n2)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
        public static int LongestIncreasingSubsequenceLength(int[] seq)
        {
            int len = seq.Length;
            int[] lookup = new int[seq.Length];

            for (int i = 1; i < len; i++)
            {
                int longestSoFar = 0;

                for (int j = 0; j < i; j++)
                {
                    if (seq[i] > seq[j] && lookup[j] > longestSoFar)
                        longestSoFar = lookup[j];
                }
                lookup[i] = longestSoFar + 1;
            }

            int longestLength = 0;
            for (int i = 0; i < len; i++)
            {
                if (lookup[i] > longestLength)
                    longestLength = lookup[i];
            }

            return longestLength;
        }

        //CCI 11.8
        //Imagine you are reading in a stream of integers. Periodically, you wish to be able to look up the 
        //rank of a number x (the number of values less than or equal to x). Implement the data structures 
        //and algorithms to support these operations. That is, implement  method  Track(int x), which is 
        //called when each number is generated, and the method getRankOf'Number(int x), which returns the 
        //number of values less than or equal to x (not including x itself).

        //Use BST Tree
        public static class Question
        {
            private static RankNode root = null;

            public static void Track(int number)
            {
                if (root == null)
                    root = new RankNode(number);
                else
                    root.Insert(number);
            }

            public static int GetRankofNumber(int number)
            {
                return root.GetRank(number);
            }

            public class RankNode
            {
                public int left_size = 0;
                public RankNode left, right;
                public int data = 0;
                
                public RankNode(int d)
                {
                    data = d;
                }

                public void Insert(int d)
                {
                    if (d <= data)
                    {
                        if (left != null) left.Insert(d);
                        else
                        {

                            left = new RankNode(d);
                            left_size++;
                        }
                    }
                    else
                    {
                        if (right != null) right.Insert(d);
                        else right = new RankNode(d);
                    }
                }

                public int GetRank(int d)
                {
                    if (d == data)
                        return left_size;
                    else if (d < data)
                    {
                        if (left == null)
                            return -1;
                        else
                            return GetRank(d);
                    }
                    else { 
                        int right_rank = (right == null) ? -1 : right.GetRank(d);
                        if (right_rank == -1) return -1;
                        else
                            return left_size + 1 + right_rank;
                    }
                }
            }
        }

        //EPI 11.4
        //An abs-sorted array is an array of numbers in which |A[i]| <= |A[j]| whenever i<j.  
        //Design an algorithm that takes an abs-sorted array A and a number k, and returns a pair of 
        //indices of elements in A that sum up to k
       
        /// <summary>
        /// This takes o(n2)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Pair FindPairAbsSorted1(int[] arr, int k)
        {
            Pair p = new Pair(-1, -1);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int num1 = arr[i];

                    //if (num1 < 0)
                    //    num1 *= (-1);

                    int num2 = arr[j];
                    //if (num2 < 0)
                    //    num2 *= (-1);
                       

                    if (num1 + num2 == k)
                    {
                        p = new Pair(i, j);
                        return p;
                    }
                }
            }

            return p;
        }

        /// <summary>
        /// O(n) time, O(n) space
        /// </summary>
        /// <returns></returns>
        public static Pair FindPairAbsSorted2(int[] arr, int k)
        {
            Pair p = new Pair(-1, -1);
            Dictionary<int, int> dict = new Dictionary<int,int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(k - arr[i]))
                {
                    int val = dict[k- arr[i]];
                    p = new Pair(i, val);
                    return p;
                }
                else {
                    dict.Add(arr[i], i);
                }
            }

            return p;
        }

        public static Pair FindPairAbsSorted3(int[] arr, int k)
        {
            Pair p = new Pair(-1, -1);

            int i = 0;
            int j = arr.Length - 1;

            while (i < j && arr[i] < 0)
            {
                i++;
            }

            while (i < j && arr[j] < 0)
                j--;

            while (arr[i] < arr[j])
            {
                if (arr[i] + arr[j] == k)
                    return new Pair(i, j);

                else if (arr[i] + arr[j] < k)
                {
                    do
                    {
                        i++;
                    } while (i < j && arr[j] < 0);
                }
                else
                {
                    do
                    {
                        j--;
                    } while (i < j && arr[j] < 0);
                }
            }

            return p;
        }

        //EPI 11.5 Search a cyclically sorted array for smallest element
        /// <summary>
        /// Assume all elements are distinct O(logn)
        /// An array A of length n is cyclically sorted if the element in
        /// the array is at inex i, and the sequence (A[i], A[i+1],....,A[n-1], A[0]...A[i-1]
        /// is sorted in increasing order
        /// 
        /// eg.
        /// 378   478  550  631  103  203  220   234  279  368
        /// A[0]  A[1] A[2] A[3] A[4] A[5] A[6]  A[7] A[8] A[9]
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int BinarySearchCyclicalArray(int[] a)
        {
            int low = 0;
            int high = a.Length - 1;
            
            while (low < high)
            {
                int mid = low + ((high - low) / 2);

                if (a[mid] > a[high] )
                    low = mid + 1;
                else // a[mid] < a[high]
                    high = mid;
            }

            //loop ends when low == high
            return low;  
        }
        //public static int BinarySearchCyclicalArray(int[] a)
        //{
        //    int low = 0;
        //    int high = a.Length - 1;
        //    int mid;
        //    mid = low + (high - low) / 2;

        //    while (low < high)
        //    {
        //        if (a[mid] > a[high] || a[high] < a[low])
        //            low = mid;
        //        else if (a[mid] < a[high])
        //            high = mid - 1;
        //        else
        //            return mid;
        //    }

        //    return -1;  //Error
        //}

        //EPI 11.6 Search a sorted array of unknown length (was asked in Google phone interview)
        //http://www.quora.com/Given-an-array-of-unknown-size-n-how-do-you-find-the-exact-value-of-n-in-O-log-n-time

        //EPI 11.8 Search for the kth smallest element in 2 sorted arrays A, B in O(logn) time
        //1) merge the 2 arrays and compare and get the next largest element 0(n)
 
        //O(nlogn) below

        //http://leetcode.com/2011/01/find-k-th-smallest-element-in-union-of.html
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthSmallest1(int[] A, int[] B, int k)
        {
            return FindKthSmallest(A, A.Length, B, B.Length, k, 0, A.Length - 1);
        }

        //http://nriverwang.blogspot.com/2013/04/k-th-smallest-element-of-two-sorted.html
        ///
        private static int FindKthSmallest(int[] A, int lengA, int[] B, int lengB, int k, int p, int q)
        {
            if (p > q)
                return FindKthSmallest(B, lengB, A, lengA, k, 0, lengB - 1);  //Search in B

            int i = p + (q - p) / 2;
            int j = k - 1 - i - 1;

            if ((j < 0 || j < lengB && A[i] >= B[j])
                && (j + 1 >= lengB || (j + 1 >= 0 && A[i] <= B[j + 1])))
            {
                return A[i];
            }
            else if (j < 0 || (j + 1 < lengB && A[i] > B[j + 1]))
            {
                return FindKthSmallest(A, lengA, B, lengB, k, p, i - 1);
            }
            else
                return FindKthSmallest(A, lengA, B, lengB, k, i + 1, q);
        }

        /// <summary>
        /// O(n) My own implementation
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int FindKthSmallest2(int[] A, int[] B, int x)
        {
            int lenA = A.Length;
            int lenB = B.Length;
            int[] C = new int[lenA + lenB];

            if (x < 0 || x > lenA + lenB)
                return -1;

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < lenA && j < lenB)
            {
                if (A[i] <= B[j])
                {
                    C[k] = A[i];
                    i++;
                    k++;
                }
                else
                {
                    C[k] = B[j];
                    j++;
                    k++;
                }
            }

            while (i < lenA)
            {
                C[k] = A[i];
                i++;
                k++;
            }

            while (j < lenB)
            {
                C[k] = B[j];
                j++;
                k++;
            }

            return C[x-1];
        }


        //Find the median of 2 sorted arrays
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="lengA"></param>
        /// <param name="B"></param>
        /// <param name="lengB"></param>
        /// <returns></returns>
        public static double FindMedianTwoArrays(int[] A, int lengA, int[] B, int lengB)
        {
            if ((lengA + lengB) % 2 == 1)
            {
                return FindKthSmallest(A, lengA, B, lengB, (lengA + lengB) / 2 + 1, 0, lengA - 1);
            }
            else
            {
                return (FindKthSmallest(A, lengA, B, lengB, (lengA + lengB) / 2, 0, lengA - 1) +
                    FindKthSmallest(A, lengA, B, lengB, (lengA + lengB) / 2 + 1, 0, lengA - 1)) / 2;
            }
        }

        //11.13 EPI
        //Find kth largest element in unsorted array in O(n) time
        //This is example of using a selection algorithm using a pivot (same a quicksort)
        //http://www.ardendertat.com/2011/10/27/programming-interview-questions-10-kth-largest-element-in-array/
        //http://www.careercup.com/question?id=182717
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthLargest1(int[] list, int k)
        {
            int left = 0;

            int right = list.Length -1;

            while(true)
            {
                int pivIndex = (left + right)/2;

                int newPiv = Partition1(list, left, right, pivIndex);

                if(newPiv == k)
                    return list[newPiv];
                else if(newPiv < k)
                    left = newPiv +1;
                else
                    right = newPiv -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="pivot"></param>
        /// <returns></returns>
        private static int Partition1(int[] list, int left, int right, int pivot)
        {
            int pivotVal = list[pivot];
            Swap(list, pivot, right); //Move pivot to end

            int storePos = left;

            for (int i = left; i < right; i++)
            {
                if (list[i] < pivotVal)
                {
                    Swap(list, i, left);
                    storePos++;
                }
            }

            Swap(list, storePos, right); //Move pivot to final place
            return storePos;
        }

        public static int FindKthLargest2(int[] list, int k)
        {
            return FindKthLargest2(list, 0, list.Length - 1, k);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthLargest2(int[] list, int left, int right,  int k)
        {
            int mid = left + (right - left)/2;

            int pivot = Partition2(list, mid);

            if (pivot  == k )
                return list[pivot];

            if (pivot < k)
                return FindKthLargest2(list, left + 1 , right, k - pivot );            
            else
                return FindKthLargest2(list, 0, pivot, k);
        }

        private static int Partition2(int[] list, int piv)
        {
            int pivot = list[piv];
            int i = 0;
            int j = list.Length - 1;

            while (i < j)
            {
                while(list[i] > pivot) i++;

                while (list[j] < pivot) j--;

                if (i < j)
                {
                    Swap(list, i, j);
                    i++;
                    j--;
                }
            }

            return i-1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Swap(int[] list, int a, int b)
        {
            int temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
        
        //11.16 EPI
        //Find missing element 
        //public static Pair<int, int> FindMissingandDuplicateElement(int[] A)
        //{
        //    int sum = 0;
        //    for(int i = 0; i < A.Length; i++)
        //    {
        //        sum = sum + A[i];
        //    }

        //    int n = A.Length;

        //    int correctSum = n * (n - 1) / 2;

        //    int diff = sum - correctSum;
        //    int missingNum;
        //    int numAppearTwice;

        //    missingNum = difff - numAppearTwice;

        //    int numMissing = correctSum - (sum - numAppearingTwice);

        //    return new Pair<int, int>(numAppearingTwice, numMissing);
        //}

        //EPI 11.19 You are reading a sequence of words from a very long stream.  You know a priori 
        //that more than half the words are repeitions of a single word w (the "majority element")
        //but the positions where w occurs are unknown.   Design an algorithm that makes a single pass 
        //over the stream and use only a constant amount of memory to identify w
        public static string SearchMajority(string s)
        {
            string[] arr = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string candidate = string.Empty;
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                string word = arr[i];

                if (count == 0)
                {
                    candidate = word;
                    count = 1;
                }
                else if (word == candidate)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            return candidate;
        }
    }

    public class Pair
    {
        public int A;
        public int B;

        public Pair(int a, int b)
        {
            A = a;
            B = b;
        }
    }


    class SearchProgram
    {
        static void MainSearch(string[] args)
        {
            int[] searchArr = { 1, 3, 4, 5, 6, 11, 17, 22, 44 };

            Console.WriteLine("Binary Search iterative " + Search.BinarySearch(searchArr, 6));
            Console.WriteLine("Binary Search recursive " + Search.BinarySearchRecursive(searchArr, 6));
            Console.WriteLine("Binary Search iterative " + Search.BinarySearch(searchArr, 8));
            Console.WriteLine("Binary Search recursive " + Search.BinarySearchRecursive(searchArr, 8));

            int[] mergedArr1 = { 1, 3, 5, 7, 9 };
            int [] mergedArr2 = { 2, 4, 6, 8, 10, 12, 14, 16};
            int[] mergedArr = Search.MergeSortedArrays(mergedArr1, mergedArr2);

            for (int i = 0; i < mergedArr.Length; i++)
            {
                Console.Write(mergedArr[i] + " ");
            }

           

            Console.WriteLine("\n\nFind smallest element position in sorted cyclical array");
            int[] accycArr = { 378, 478, 550, 631, 103, 203, 220, 234, 279, 368 };
            int accRes1 = Search.BinarySearchCyclicalArray(accycArr);
            Console.Write(accRes1);


            Console.WriteLine("\n\nFind kth smallest in union of 2 sorted arrays in O(logn) time.");
            int kSmallest = 7;
            int[] kSmallestArr1 =  { 1, 4, 7, 8, 10 };
            int[] kSmallestArr2 = { 2, 3, 9, 11, 13 };

            Console.WriteLine(string.Format("{0} th smallest: {1}", kSmallest,  Search.FindKthSmallest1(kSmallestArr1, kSmallestArr2, kSmallest)));


            Console.WriteLine("\n\nFind kth largest in unsorted arrays in O(n) time.");
            int[] kLargestArr1 = { 24, 2, 9, 5, 7, 4, 10, 33 };
            int[] kLargestArr2 = { 24, 2, 9, 5, 7, 4, 10, 33 };
            int kLargest = 2;
            Console.WriteLine(string.Format("{0} th largest: {1}", kLargest, Search.FindKthLargest1(kLargestArr1, kLargest)));
            Console.WriteLine(string.Format("{0} th largest: {1}", kLargest, Search.FindKthLargest2(kLargestArr2, kLargest)));

            Console.WriteLine("\n\nFind duplicate and missing number in array.");
            int[] dupMissArray = { 0, 1, 2 , 4, 4 };
            //int[] dupMissArray = { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 11, 12 };

            //Pair<int, int> dupMissPair = Search.FindMissingandDuplicateElement(dupMissArray);
            //Console.WriteLine(string.Format("Missing element is {0}. Duplicate element is {1}", dupMissPair.GetFirst(), dupMissPair.GetSecond()));

            Console.WriteLine("\n\nFind longest increasing subsequence.");
            int[] lisArr = { 3, 2, 6, 4, 5, 1 ,5, 6};
            Console.WriteLine("\n\nFind longest increasing subsequence is " + Search.LongestIncreasingSubsequenceLength(lisArr));

            string searchMajorityStr = "my dog has the biggest bone in the dog world";
            Console.WriteLine(string.Format("The most frequent word in '{0}' is {1}", searchMajorityStr, Search.SearchMajority(searchMajorityStr)));

            Console.WriteLine("\n\nFind pair in absolute sorted array");

            int[] absArr = { -49, 75, 103, -147, 164, -197, -238, 314, 348, -422 };
            int k = 167;
            Pair pair = Search.FindPairAbsSorted3(absArr, k);

            if (pair != null)
            {
                Console.WriteLine("Absolute sorted array result : A = " + pair.A + " B = " + pair.B + " ");
            }




            Console.Read();        
        }
    }
}
