using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgsCompCS
{
    class QuickSorter : BaseSorter
    {

        private Random random;

        public QuickSorter() : base()
        {
            methodTag = MethodTag.QUICK_SORT;
            random = new Random(DateTime.Now.Millisecond);
        }

        public override List<int> Sort(List<int> listToSort)
        {
            if( listToSort.Count <= 1)
            {
                return listToSort;
            }

            // Create a new deep copy of the list to avoid conflicts
            List<int> resultList = new List<int>(listToSort);

            quickSort(resultList, 0, listToSort.Count - 1);

            return resultList;
        }

        public void quickSort(List<int> listToSort, int leftIndex, int rightIndex)
        {
            // If the passed indicies do not overlap...
            if( leftIndex < rightIndex)
            {
                // Choose a random pivot index
                int pivotIndex = random.Next(leftIndex, rightIndex);

                // Get lists of bigger and smaller items and the final position of the pivot
                int newPivotIndex = partition(listToSort, leftIndex, rightIndex, pivotIndex);

                // Recursively sort elements smaller than the pivot
                quickSort(listToSort, leftIndex, newPivotIndex - 1);

                // Recusively sort elements at least as big as the pivot
                quickSort(listToSort, newPivotIndex + 1, rightIndex);

            }
        }

        private int partition(List<int> listToPartition, int leftIndex, int rightIndex, int pivotIndex)
        {
            // Determine the pivot value
            int pivotValue = listToPartition[pivotIndex];

            // Move the pivot value to the end of the sub-array to temporarily get the pivot value out of the way
            swap(ref listToPartition, pivotIndex, rightIndex);

            // Store the left index, which after this function runs will contain the new index of the pivot value
            int storedIndex = leftIndex;

            // For each value within the sup-array...
            for (int i = leftIndex; i < rightIndex; i++)
            {
                // ... that is less than the pivot value... swap that value and the stored index. Then increment the stored index
                if(listToPartition[i] <= pivotValue)
                {
                    // ... swap the value with the value at the currently stored index and increment the stored index.
                    swap(ref listToPartition, i, storedIndex);
                    storedIndex++;
                }
            }

            // Re-include the pivot value that was temporarily set aside at the proper index
            swap(ref listToPartition, storedIndex, rightIndex); 

            return storedIndex;
        }

        private void swap(ref List<int> listToSwapWithin, int firstSwapIndex, int secondSwapIndex)
        {
            int firstSwapValue = listToSwapWithin[firstSwapIndex];
            int secondSwapValue = listToSwapWithin[secondSwapIndex];

            listToSwapWithin[firstSwapIndex] = secondSwapValue;
            listToSwapWithin[secondSwapIndex] = firstSwapValue;
        }
    }
}
