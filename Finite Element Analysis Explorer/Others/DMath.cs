using System;
using System.Diagnostics;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// DMath class.
    /// </summary>
    internal static class DMath
    {
        /// <summary>
        /// Pi.
        /// </summary>
        public const decimal PI = 3.1415926535897932384626433833m;

        /// <summary>
        /// Return the absolute.
        /// </summary>
        /// <param name="x">x.</param>
        /// <returns>Result.</returns>
        internal static decimal Abs(decimal x)
        {
            if (x < 0)
            {
                x = -x;
            }

            return x;
        }

        /// <summary>
        /// Sqrt.
        /// </summary>
        /// <param name="x">x.</param>
        /// <param name="epsilon">epsilon.</param>
        /// <returns>Result.</returns>
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
                if (previous == 0.0M)
                {
                    return 0;
                }

                current = (previous + (x / previous)) / 2;
            }
            while (Math.Abs(previous - current) > epsilon);
            return current;
        }
    }
}
