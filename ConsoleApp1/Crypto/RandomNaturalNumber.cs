using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiRgr
{
    internal class RandomNaturalNumber
    {
        public static bool isPrime(long p)
        {
            if (p <= 1) return false;

            long b = (long)Math.Pow(p, 0.5);

            for (int i = 2; i <= b; ++i)
            {
                if (p % i == 0) return false;
            }

            return true;

        }

        public static long Create(long left, long right)
        {
            Random rnd = new Random();
            long x;
            int range = 100;
            do
            {
                x = rnd.NextInt64(left, right);
            } while (isPrime(x) == false);
            return x;
        }
    }
}
