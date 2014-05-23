using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgsCompCS
{
    class QuickSorter : BaseSorter
    {
        public QuickSorter() : base()
        {
            methodTag = MethodTag.QUICK_SORT;
        }

        public override List<int> Sort(List<int> listToSort)
        {
            return listToSort;
        }
    }
}
