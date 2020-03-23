using System;
using System.Numerics;

namespace IntroductoryTasks.Utils
{
    public static class FactorialUtil
    {
        public static int GetFactorial(int value)
        {
            if (value < 0 || value > 12)
                throw new ArgumentOutOfRangeException("value", "Value can be from range [0 .. 12]. Use FactorialUtil.GetBigIntFactorial for large numbers.");

            int res = 1;
            for (int i = 2; i <= value; i++)           
                res *= i;

            return res;
        }

        public static BigInteger GetBigIntFactorial(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value", "Value can't be negative.");

            BigInteger res = 1;
            for (int i = 2; i <= value; i++)
                res *= i;

            return res;
        }
    }
}
