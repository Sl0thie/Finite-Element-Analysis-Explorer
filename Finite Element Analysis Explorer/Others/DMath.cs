using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Finite_Element_Analysis_Explorer
{
    internal static class DMath
    {

        public const decimal PI = 3.1415926535897932384626433833m;

        internal static decimal Abs(decimal x)
        {
            if (x < 0) { x = -x; }
            return x;
        }

        public static decimal Sqrt(decimal x, decimal epsilon = 0.0M)
        {
            if (x < 0)
            {
                Debug.WriteLine("Cannot calculate square root from a negative number");
                return 0;
            }

            decimal current = (decimal)Math.Sqrt((double)x), previous;
            do
            {
                previous = current;
                if (previous == 0.0M) return 0;
                current = (previous + x / previous) / 2;
            }
            while (Math.Abs(previous - current) > epsilon);
            return current;
        }

    }
}
