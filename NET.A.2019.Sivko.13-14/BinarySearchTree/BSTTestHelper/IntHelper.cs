using System;
using System.Collections.Generic;

namespace Day13Test.BSTTestHelper
{
    public class IntHelper : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (Math.Log10(x) == Math.Log10(y))
                return 0;
            else if (Math.Log10(x) > Math.Log10(y))
                return 1;
            else
                return -1;
        }
    }
}
