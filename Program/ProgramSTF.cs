using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class ProgramSTF
    {
        static void MainSTF(string[] args)
        { 
            //string filePath = @"C:\Users\Ken\Coursera\DesignandAnalysis1\Week1\Inversion\MyIntegerArray.txt";
            //int[] intArr = Inversion.ParseFile(filePath);
            //Inversion.Sort(intArr);

            //string filePath = @"C:\Users\Ken\Coursera\DesignandAnalysis1\Week1\QuickSort\QuickSort.txt";
            string filePath = @"C:\Users\Ken\Coursera\DesignandAnalysis1\Week1\QuickSort\10.txt";
            Console.WriteLine("\n\nQuick Sort");
            //int[] QuickSortArray = { 34, 380, 944, 594, 783, 584, 550, 665, 721, 819, 285, 344, 503, 807, 491, 623, 845, 300, 11, 1000 };

            //int[] QuickSortArray = { 4, 6, 2, 10, 3, 23};

            int[] QuickSortArray = QuickSortStf.ParseFile(filePath);

            long calls = QuickSortStf.Sort(QuickSortArray);
            //QuickSortStf.Sort(QuickSortArray);
            for (int i = 0; i < QuickSortArray.Length; i++)
            {
                Console.Write(QuickSortArray[i] + " ");
            }

            Console.Write("\nNumber of Quick sort comparisons " + calls);

            //Console.WriteLine("\n\nMerge Sort");

            ////int[] MergeSortArray = { 3, 4, 2, 5 };
            int[] MergeSortArray = { 1, 6, 3, 2, 4, 5 };
            //string mergeFilePath = @"C:\Users\Ken\Coursera\DesignandAnalysis1\Week1\Inversion\IntegerArray.txt";
            //int[] MergeSortArray = Inversion.ParseFile(mergeFilePath);
            long numberOfInversions = Inversion.Sort(MergeSortArray);

            //for (int i = 0; i < MergeSortArray.Length; i++)
            //{
            //    Console.Write(MergeSortArray[i] + " ");
            //}

            Console.Write("\nNumber of Insersion " + numberOfInversions);

            //int[] medianArr = { 4, 7, 6, 5 };
            //int[] medianArr = { 6, 5, 8, 7, 4 };
            //int target = QuickSortStf.FindMedian(medianArr, 0, medianArr.Length - 1);

            Console.Write("\nFind Max");
            //int[] FindMaxArray = { -43, -4, 2, 5, 1, -10 };
            int[] FindMaxArray = { -1, 0, 2, 5, 10, 11, 9 };
            int findMaxInt = UniModal.FindMax(FindMaxArray);
            Console.Write("\nUnimodal max " + findMaxInt); ;

            Console.Read();
        }

    }
}
