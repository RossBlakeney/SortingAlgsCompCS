using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgsCompCS
{
    class InsertionSorter: BaseSorter
    {
        public InsertionSorter() : base()
        {
            methodTag = MethodTag.INSERTION_SORT;
        }

        public override List<int> Sort(List<int> listToSort)
        {
            // Create a new deep copy of the list to avoid conflicts
            List<int> resultList = new List<int>(listToSort);

            int keyValue = 0;
            int insertionIndex = 0;
            for (int keyIndex = 1; keyIndex < resultList.Count; keyIndex++)
            {
                // Store key value
                keyValue = resultList[keyIndex];

                // Set initial insertion index
                insertionIndex = keyIndex - 1;

                // Shift all preceeding values greater than the key to the right by one to make room for insertion
                while (insertionIndex > -1 && resultList[insertionIndex] > keyValue)
                {
                    resultList[insertionIndex + 1] = resultList[insertionIndex];
                    insertionIndex--;
                }

                // Insert key value
                resultList[insertionIndex + 1] = keyValue;
            }
            return resultList;
        }
    }



}
