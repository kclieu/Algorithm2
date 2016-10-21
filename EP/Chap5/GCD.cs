using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Algos
{
    public static class GCD
    {
        private static BigInteger TWO = new BigInteger(2);

        private static bool IsOdd(BigInteger x)
        {
            return !x.IsEven;
        }

        private static bool IsEven(BigInteger x)
        {
            return x.IsEven;
        }

        public static BigInteger GetGCD(BigInteger x, BigInteger y)
        {
            if (x.Equals(y))
                return y;
            else if (y.Equals(BigInteger.Zero))
                return x;
            else if (IsEven(x) && IsEven(y))
            {
                x = x >> 1;
                y = y >> 1;
                return BigInteger.Multiply(TWO, GetGCD(x, y));
            }
            else if (IsOdd(x) && IsEven(y))
            {
                y = y >> 1;
                return GetGCD(x, y);
            }
            else if (IsOdd(y) && IsEven(x))
            {
                x = x >> 1;
                return GetGCD(y, x);
            }

            else
                return GetGCD(y, x);
        }
    }
}
