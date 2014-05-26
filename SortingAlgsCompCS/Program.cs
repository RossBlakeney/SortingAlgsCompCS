using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgsCompCS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> randomizedList = new List<int>();
            List<int> sortedList = new List<int>();

            InsertionSorter insertionSorter = new InsertionSorter();
            MergeSorter mergeSorter = new MergeSorter();
            QuickSorter quickSorter = new QuickSorter();

            double cummulativeInsertionSortDuration = 0;
            double cummulativeMergeSortDuration = 0;
            double cummulativeHeapSortDuration = 0;
            double cummulativeQuickSortDuration = 0;

            double averageInsertionSortDuration = 0;
            double averageMergeSortDuration = 0;
            double averageHeapSortDuration = 0;
            double averageQuickSortDuration = 0;

            int numberOfTimesToRunTest = 0;
            int numberOfValuesToSort = 0;

            userInput(ref numberOfTimesToRunTest, ref numberOfValuesToSort);

            for(int i = 0; i < numberOfTimesToRunTest; i++)
            {
                randomizedList = createRandomizedList(numberOfValuesToSort);

                // Insertion sort - n^2
                //cummulativeInsertionSortDuration += insertionSorter.SortRuntimeTest(randomizedList, ref sortedList);

                // Merge sort - n lg n
                cummulativeMergeSortDuration += mergeSorter.SortRuntimeTest(randomizedList, ref sortedList);

                // Quick Sort - n lg n
                cummulativeQuickSortDuration += quickSorter.SortRuntimeTest(randomizedList, ref sortedList);

                // Heap Sort - n lg n
                //cummulativeHeapSortDuration += heapSort(randomArray, sortedArray);

                // Counting Sort - k + n
                // Radix Sort - d(n + k)
                // Bucket Sort - n
            }

            averageInsertionSortDuration = cummulativeInsertionSortDuration / (double)numberOfTimesToRunTest;
            averageMergeSortDuration = cummulativeMergeSortDuration / (double)numberOfTimesToRunTest;
            averageQuickSortDuration = cummulativeQuickSortDuration / (double)numberOfTimesToRunTest;

            Console.Write("Average Insertion Sort Duration: {0}\n", averageInsertionSortDuration);
            Console.Write("Average Merge Sort Duration: {0}\n", averageMergeSortDuration);
            Console.Write("Average Quick Sort Duration: {0}\n", averageQuickSortDuration);
        }

        private static void userInput(ref int numberOfTimesToRunTest, ref int numberOfValuesToSort)
        {
            Console.Write("Enter the number of times to run the test.\n> ");
            numberOfTimesToRunTest = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of values to sort.\n> ");
            numberOfValuesToSort = Convert.ToInt32(Console.ReadLine());
        }

        private static List<int> createRandomizedList(int listSize)
        {
            List<int> randomizedList = new List<int>();
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < listSize; i++ )
            {
                randomizedList.Add(random.Next(1, 10000));
            }

            return randomizedList;
        }

    }



}
