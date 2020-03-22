using System;
using System.Numerics;

namespace IntroductoryTasks
{
    public static class FactorialUtil
    {
        public static int GetFactorial(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Value can't be negative");

            if (value > 12)
                throw new ArgumentOutOfRangeException("Value can't be greater than 12. Use GetBigIntFactorial method");

            int res = 1;
            for (int i = 2; i <= value; i++)           
                res *= i;

            return res;
        }

        public static BigInteger GetBigIntFactorial(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Value can't be negative");

            BigInteger res = 1;
            for (int i = 2; i < value; i++)
                res *= i;

            return res;
        }
    }
}
