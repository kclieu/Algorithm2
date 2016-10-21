using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class MyMath
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Fibonacci1(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci1(n - 1) + Fibonacci1(n - 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Fibonacci2(int n)
        {
            int[] fib = new int[n + 1];
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (fib[n] != 0) return fib[n];

            fib[n] = Fibonacci2(n - 1) + Fibonacci2(n - 2);
            return fib[n];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Factorial(int n)
        {
            if (n == 0)
                return 1;

            int fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact = fact * i;
            }

            return fact;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static void PrintOddUpToN(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 > 0)
                    Console.Write(String.Format("{0}, ", i));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindLargestNumber(int[] arr)
        {
            int max = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            return max;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Find2LargestNumbers(int[] arr)
        {
            int firstMax = 0;
            int secondMax = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > firstMax || arr[i] > secondMax)
                {
                    if (arr[i] > firstMax)
                    {
                        secondMax = firstMax;
                        firstMax = arr[i];
                    }
                    else
                    {
                        secondMax = arr[i];
                    }
                }
            }

            int[] retArr = new int[] { firstMax, secondMax };

            return retArr;
        }


        //Given two rectangles ra and rb , check if they overlap. In other words, 
        //if they have common area or not. This is most asked interview questions 
        //in biggies like FB, Google, Amazon and MS.
        //http://www.crazyforcode.com/check-rectangles-overlap/
        //class Rectangle
        //{
        //    int topX;
        //    int topY;
        //    int bottomX;
        //    int bottomY;
        //}

        //public bool IsOverlap(Rectangle A, Rectangle B)
        //{
        //    return true;
        //}


        //CCI 5.2 Give a real number between 0 and 1 eg. 0.72 that is passed in as a double,
        //print the binary representation.  If the number cannot be represented accurately
        //in binary with at list 32 characters, print Error
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string PrintBinaryNumber(double num)
        {
            string error = "Error";
            if (num >= 1 || num < 0)
                return error;

            StringBuilder binary = new StringBuilder();
            binary.Append("0.");

            while (num > 0)
            {
                if (binary.Length >= 32)
                    //return error;
                    return binary.ToString().Substring(0, 31);

                double r = num * 2;

                if (r >= 1)
                {
                    binary.Append(1);
                    num = r - 1;
                }
                else
                {
                    binary.Append(0);
                    num = r;
                }
            }

            return binary.ToString();
        }

        //CCI 17.1 Write a function to swap a number in place
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap1(int a, int b)
        {
            a = a - b;
            b = a + b;
            a = b - a;
        }

        private static void Swap2(int a, int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }

        //CCI 17.3 Compute the number of trailing 0's in a factorial
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ComputeTrailingZerosInFactorial(int n)
        {
            int fact = 1;
            int twoN = 0;
            int fiveN = 0;
            int numTrailingZeros = 0;

            for (int i = 1; i <= n; i++)
            { 
                fact = fact*i;

                if (i % 5 == 0)
                {
                    int num = i;
                    while (num >= 5)
                    {
                        num = num / 5;
                        fiveN++;
                    }
                }
                if (i % 2 == 0)
                {
                    int num = i;

                    twoN++;
                }
            }

            while (twoN > 0 && fiveN > 0)
            {
                twoN--;
                fiveN--;
                numTrailingZeros++;
            }

            //overflow for n = 19;
            //Console.WriteLine("Factorial of " + n + " is " + fact);

            return numTrailingZeros;
        }
        
        public static int CountFactZeros(int num)
        {
            int count = 0;
            if (num < 0)
                return -1;

            for (int i = 5; num / i > 0; i *= 5)
            {
                count += num / i;
            }
            return count;
        }

        //CCI 17.8 You are given an array of integers (both positive and negative).  Find the contiguous 
        //sequence with the largest sum.  Return the num;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindMaxSumOfContiguousSubSequence(int[] arr)
        {
            int sum = 0;
            int max = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i];
                if (sum > max)
                    max = sum;
                if (sum < 0)
                    sum = 0;
            }
            return max;
        }

        //CCI 17.11
        //Implemnt a method rand7() and rand5(). That is given a method
        //that generates a random number between 0 and 4 (inclusive),
        //write a method that generates a random between 0 and 6 (inclusive)
        public static int Rand7()
        {
            while (true)
            {
                //evens between 0 and 9l
                int r1 = 2 * Rand5();
                //used later to generate a 0 or 1
                int r2 = Rand5();

                //r2 has extrea even num-discard the extra
                if (r2 != 4)
                {
                    //generate a 0 or 1
                    int rand1 = r2 % 2;
                    //will be in the range 0 or 9
                    int num = r1 + rand1;
                    if (num < 7)
                        return num;
                }
            }
        }

        public static int Rand5()
        {
            return new Random().Next(0, 4);
        }


        //CCI 17.12
        //Given array of n integers and given a number X, find all the unique
        //pairs of elemenst (a,b), whose summation is equal to X.
        //This uses O(n2) space 
        public static void FindTwoNumbersInArraySumIsEqualToX1(int[] A, int x)
        {
            Hashtable h = new Hashtable();

            for (int i = 0; i < A.Length - 1; i++)
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[i] + A[j] == x)
                    {
                        Console.WriteLine(string.Format("{0} + {1} = {2}", A[i], A[j], x));
                    }
                }

        }

        //This uses O(n) space and O(n) time 
        public static void FindTwoNumbersInArraySumIsEqualToX2(int[] A, int x)
        {
            Hashtable h = new Hashtable();

            for (int i = 0; i < A.Length; i++)
                h.Add(A[i], 0);

            for (int i = 0; i < A.Length; i++)
            {
                if (h.ContainsKey(x - A[i]))
                {
                    int n = x - A[i];
                    Console.WriteLine(string.Format("{0} + {1} = {2}", n, A[i], x));
                }
            }
        }

        //Use O(1) space and O(n) time
        public static void FindTwoNumbersInArraySumIsEqualToX3(int[] A, int x)
        {
            Array.Sort(A);
            int first = 0;
            int last = A.Length;

            while (first < last)
            {
                int sum = A[first] + A[last];

                if (x == sum)
                {
                    Console.WriteLine(string.Format("{0} + {1} = {2}", A[first], A[last], x));
                    first++;
                    last--;
                }
                else
                {
                    if (sum < x)
                        first++;
                    else
                        last--;

                }
            }
        }


        //CCI 18.2 Write a method to shuffle a deck of carsd It must be 
        //a perfect shuffle, each of the 52! permutations of the deck has to
        //be equally likely.  Assume that you are give a random number
        //generator which is perfect
        public static void Shuffle(int[] cards)
        { 
            for(int i = 0; i < cards.Length; i++)
            {
                int target = new Random().Next(0, i);
                int temp = cards[target];
                cards[target] = cards[i];
                cards[i] = temp;
            }
        }

        //CCI 18.3 Write a method to randomly generate a set of m integers
        //from an array of size n.  Each element must have equal probability
        //of being chosen
        public static int[] GenerateInt(int[] original, int m)
        {
            int[] subset = new int[m];

            for (int i = 0; i < m; i++)
                subset[i] = original[i];

            for (int i = m; i < original.Length; i++)
            {
                //Random # between 0 and i, inclusive
                int k = new Random().Next(0, i);

                if (k < m)
                    subset[k] = original[i];
            }
            return subset;
        }

        //CCI 18.4 Write a method to count the number of 2's between 0 and n
        public static int Get2sInRange(int n)
        {
            int count = 0;
            for (int i = 0; i <= n; i++)
            {
                count += Get2SingleNumber(i);
            }

            return count;
        }


        private static int Get2SingleNumber(int n)
        {
            int num2 = 0;
            while (n > 0)
            {
                if (n % 10 == 2)
                {
                    num2++;
                }

                n = n / 10;
            }
            return num2;
        }


        /// <summary>
        /// Selection algo to find the Kth largest elment int an array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>

        public static int FindKthLargestElement(int[] arr, int k)
        {
            return FindSelectionKthLargestElement(arr, 0, arr.Length-1, k);
        }

        public static int FindSelectionKthLargestElement(int[] arr, int left, int right,  int rank)
        {
            int leftEnd = Partition(arr, left, right);

            int leftSize = leftEnd - left + 1;

            //if there are exactly i elements on the left, return biggest element on the left
            if (leftSize == rank + 1)
                return Max(arr, left, leftEnd);
            else if (rank < leftSize)
                return FindSelectionKthLargestElement(arr, left, leftEnd, rank);
            else
                return FindSelectionKthLargestElement(arr, leftEnd + 1, right, rank - leftSize);
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[(left + right) / 2];

            while (left <= right)
            {
                while (arr[left] <= pivot) left++;
                while (arr[right] > pivot) right--;

                if (left <= right)
                {
                    swap(arr, left, right);
                }
            }

            return left;
        }

        private static int Max(int[] data, int left, int right)
        {
            int max = Int32.MinValue;
            for(int i = left; i < right; i++ )
            {
                if (data[i] > max)
                    max = data[i];
            }
            return max;
        }

        private static void swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        //http://stackoverflow.com/questions/337664/counting-inversions-in-an-array
        //http://algs4.cs.princeton.edu/22mergesort/Inversions.java.html
        /// <summary>
        /// Count the number of inversions in an array. O(nlogn)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        static long Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0, j = 0, count = 0;

            while (i < left.Length || j < right.Length)
            {
                if (i == left.Length)
                {
                    arr[i + j] = right[j];
                    j++;
                }
                else if (j == right.Length)
                {
                    arr[i + j] = left[i];
                    i++;
                }
                else if (left[i] <= right[j])
                {
                    arr[i + j] = left[i];
                    i++;
                }
                else {
                    arr[i + j] = right[j];
                    count += left.Length - i;
                    j++;
                }
            }
            return count;
        }

        public static long CountInversions(int[] arr)
        {
            if(arr.Length < 2)
                return 0;

            int m = (arr.Length + 1)/2;
            int[]  left = new int[m]; //= Array.Copy(arr, 0, m);
            int[] right = new int[m];
            Array.Copy(arr, 0, left, 0, m);
            Array.Copy(arr, m + 1, right, 0, m);
            return CountInversions(left) + CountInversions(right) + Merge(arr, left, right);
        }

        /// <summary>
        /// Passing in functions in C#
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FunctionAdd(int[] arr)
        {
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static int FunctionMult(int[] arr)
        {
            int prod = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                prod *= arr[i];
            }

            return prod;
        }

        public static void FunctionPrint()
        {
            Console.WriteLine("Calling function print");
        }

        //Func accepts an int[] argument and return int
        public static int FuncExcutioner(Func<int[], int> Method, int[] data)
        {
            int result = Method(data);
            return result;
        }

        //Func accepts no argument and returns a string
        public static void FuncPrinter(Func<string> method)
        {
            method();
        }
    }

    class ProgramMyMath
    {
        static void MainMath(string[] args)
        {
            int[] arr = { 1, 0, -2, 5, 3, 11, 24, 44, 32 };
            Console.WriteLine(MyMath.FindLargestNumber(arr));


            int[] arr1 = { 14, 23, 23, 4, 2, 10, 16 };
            int[] arrRet = MyMath.Find2LargestNumbers(arr1);
            Console.WriteLine(string.Format("First and send largest numbers are {0} {1}", arrRet[0], arrRet[1]));

            int fact = 6;
            Console.WriteLine("Factorial of " + fact + " is " + MyMath.Factorial(fact));


            int[] twoNumSumKArr = { 1, 2, 3, 4, 5, 6, 9, 11, 10, 13 };
            Console.WriteLine("Two numbers sum to k in O(n2)");
            MyMath.FindTwoNumbersInArraySumIsEqualToX1(twoNumSumKArr, 10);

            Console.WriteLine("Two numbers sum to k in O(n)");
            MyMath.FindTwoNumbersInArraySumIsEqualToX2(twoNumSumKArr, 10);
           

            Console.WriteLine("Print binary");
            //double binaryNumber = 0.5;
            double binaryNumber = 0.25;
            Console.WriteLine(String.Format("Binary for {0} is {1}", binaryNumber, MyMath.PrintBinaryNumber(binaryNumber)));


            int factorialNum = 19;
            Console.WriteLine(string.Format("Number of trailing 0's in factorial of {0} is {1}", factorialNum, MyMath.ComputeTrailingZerosInFactorial(factorialNum)));
            Console.WriteLine(string.Format("Number of trailing 0's in factorial of {0} is {1}", factorialNum, MyMath.CountFactZeros(factorialNum)));

            int[] contiguousSumArr = { 2, 3, -8, -1, 2, 4, -2, 3 };
            int[] contiguousSumArr2 = { 5, -9, 6, -2, -1};
            Console.WriteLine("The largest contiguous sum in the array is " + MyMath.FindMaxSumOfContiguousSubSequence(contiguousSumArr));

            //Console.WriteLine("Random number between 0 and 6 is " + MyMath.Rand7());

            int[] selection = { 1, 10, 8, 4, 5, 7,6 ,2, 9, 3};
            int k = 6;
            //Console.WriteLine("The " + k + " largest element is  " + MyMath.FindKthLargestElement(selection, k));

            int[] MergeSortArray = { 1, 6, 3, 2, 4, 5 , -1  };
            long numberOfInversions = Inversion.Sort(MergeSortArray);
            Console.Write("\nNumber of Insersion " + numberOfInversions);

            int[] methodArr = {1,2,3,4,5};
            int resAdd = MyMath.FuncExcutioner(MyMath.FunctionAdd, methodArr);
            int resMult = MyMath.FuncExcutioner(MyMath.FunctionMult, methodArr);
            Console.WriteLine("\nPassing in add method " + resAdd);
            Console.WriteLine("\nPassing in mult method " + resMult);
            Console.WriteLine("\nPassing in print method with no arguments");
            MyMath.FunctionPrint();
            Console.ReadKey();
        }
    }
}
