using System.Collections.Generic;

namespace Day13Test.BSTTestHelper
{
    public class StringHelper : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length == y.Length)
                return 0;
            else if (x.Length > y.Length)
                return 1;
            else
                return -1; ;
        }
    }
}
