using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgsCompCS
{
    class MergeSorter: BaseSorter
    {
        public MergeSorter() : base()
        {
            methodTag = MethodTag.MERGE_SORT;
        }

        public override List<int> Sort(List<int> listToSort)
        {
            // Create a new deep copy of the list to avoid conflicts
            List<int> resultList = new List<int>(listToSort);

            // Trivial case
            if (resultList.Count <= 1)
            {
                return resultList;
            }

            // Determine middle index of the data set
            int middleIndex = resultList.Count / 2;

            // Split data into two vectors
            List<int> leftSubList = resultList.GetRange(0, middleIndex);
            List<int> rightSubList = resultList.GetRange(middleIndex, resultList.Count - middleIndex);

            // Recursive merge sort of the two vectors
            leftSubList = Sort(leftSubList);
            rightSubList = Sort(rightSubList);

            // Merge sorted reults
            return merge(leftSubList, rightSubList);
        }

        private List<int> merge(List<int> leftSubList, List<int> rightSubList)
        {
            List<int> resultList = new List<int>();

            int leftSubListIndex = 0;
            int rightSubListIndex = 0;

            // Sort the two vectors until one of the vectors run out of data to sort
            while(leftSubListIndex < leftSubList.Count && rightSubListIndex < rightSubList.Count)
            {
                if(leftSubList[leftSubListIndex] < rightSubList[rightSubListIndex])
                {
                    resultList.Add(leftSubList[leftSubListIndex]);
                    leftSubListIndex++;
                }
                else
                {
                    resultList.Add(rightSubList[rightSubListIndex]);
                    rightSubListIndex++;
                }
            }

            // Toss any leftovers into the resultant (nothing to compare to) **One of the while loops will not run
            while(leftSubListIndex < leftSubList.Count)
            {
                resultList.Add(leftSubList[leftSubListIndex]);
                leftSubListIndex++;
            }
            while(rightSubListIndex < rightSubList.Count)
            {
                resultList.Add(rightSubList[rightSubListIndex]);
                rightSubListIndex++;
            }

            return resultList;
        }


    }

    

}
