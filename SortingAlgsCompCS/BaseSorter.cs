using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgsCompCS
{
    abstract class BaseSorter
    {
        protected enum MethodTag
        {
            INSERTION_SORT,
            MERGE_SORT,
            QUICK_SORT
        }

        protected MethodTag methodTag;

        abstract public List<int> Sort(List<int> listToSort);

        public virtual double SortRuntimeTest(List<int> listToSort, ref List<int> sortedList)
        {
            sortedList.Clear();

            DateTime startTime;
            DateTime endTime;

            startTime = DateTime.Now;
            sortedList = Sort(listToSort);
            endTime = DateTime.Now;

            printResults(methodTag, sortedList);

            return (endTime - startTime).TotalSeconds;
        }

        protected void printResults(MethodTag methodTag, List<int> ListToPrint)
        {
            switch(methodTag)
            {
                case MethodTag.INSERTION_SORT:
                    Console.Write("Insertion sort results:\n");
                    break;
                case MethodTag.MERGE_SORT:
                    Console.Write("Merge sort results:\n");
                    break;
                case MethodTag.QUICK_SORT:
                    Console.Write("Quick sort results:\n");
                    break;
                default:
                    Console.Write("[ERR] switch default hit. See BaseSorter, printResults()\n");
                    break;
            }

            if(ListToPrint.Count > 15)
            {
                Console.Write("  [ {0}, {1}, {2}, {3}, {4}, ... \n\t{5}, {6}, {7}, {8}, {9} ...\n\t\t{10}, {11}, {12}, {13}, {14} ]\n",
                    ListToPrint[0],
                    ListToPrint[1],
                    ListToPrint[2],
                    ListToPrint[3],
                    ListToPrint[4],
                    ListToPrint[ListToPrint.Count / 2 - 2],
                    ListToPrint[ListToPrint.Count / 2 - 1],
                    ListToPrint[ListToPrint.Count / 2],
                    ListToPrint[ListToPrint.Count / 2 + 1],
                    ListToPrint[ListToPrint.Count / 2 + 2],
                    ListToPrint[ListToPrint.Count - 5],
                    ListToPrint[ListToPrint.Count - 4],
                    ListToPrint[ListToPrint.Count - 3],
                    ListToPrint[ListToPrint.Count - 2],
                    ListToPrint[ListToPrint.Count - 1]
                    );
            }
            else
            {
                Console.Write("  [ ");
                for (int i = 0; i < ListToPrint.Count; i++)
                {
                    Console.Write("{0}", ListToPrint[i]);

                    if(i < ListToPrint.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("]\n");
            }
        }

    }
}
