using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_oct_07_2024_comparison_lambdas
{
    public static class utility
    {
        public static int MyComp(int A, int B)
        {
            // provide DESC order sort
            return B.CompareTo(A);
        }
    }
}
