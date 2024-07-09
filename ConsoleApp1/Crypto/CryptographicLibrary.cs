using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZiRgr
{
    internal class CryptographicLibrary
    {

        public static long relativelyPrime(long p)
        {
            Random rnd = new Random();
            long res= rnd.NextInt64(2, p);
            while (res%2==0 || euclideanAlgorithm(p, res) != 1)
                res = rnd.NextInt64(2, p);
            return res;
        }

        public static long quicklyRaising(long a, long x, long p)
        {
            var dec = new DecToBinList();
            var binListX = dec.DToB(x);
            long s = a;
            long y = 1;
            foreach (var bin in binListX)
            {
                if (bin == 1)
                {
                    y = y * s % p;

                }
                s = s * s % p;

            }
            return y;
        }

        public static long euclideanAlgorithm(long a, long b)
        {
            long r;
            while (b != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
       
            return a;
        }

        public static long[] generalizedEuclideanAlgorithm(long a, long b)
        {
            if (a < b)
                throw new Exception();


            var U = new long[3] { a, 1, 0 };
            var V = new long[3] { b, 0, 1 };
            var T = new long[3];
            long q;
            while (V[0] != 0)
            {
                q = U[0] / V[0];
                T[0] = U[0] % V[0];
                T[1] = U[1] - q * V[1];
                T[2] = U[2] - q * V[2];
                Array.Copy(V, U, 3);
                Array.Copy(T, V, 3);
            }
            return U;
        }

      

        //y=a^x mod p  x-find
        public static void BabyStepGiantStep(long a, long p, long y)
        {
            long m = (long)Math.Pow(p, 0.5) + 1;
            long k = m;
            Console.WriteLine("m,k=" + m);
            var baby = new List<long>();
            var giant = new List<long>();
            // long a0 = 1;
            //baby.Add(y);
            for (long l = 0; l < m; l++)
            {
                long babyk = quicklyRaising(a, l, p);
                baby.Add(babyk * y % p);
                //baby.Add(y * a0 % p);
                //a0 *= a;
            }
            //foreach (var b in baby)
            //  Console.Write(b+" " );
            Console.WriteLine();
            long am = (long)Math.Pow(a, m);
            //a0 = am;
            int i = -1, j = -1;
            //baby.Add(y);
            for (int l = 1; l <= k; l++)
            {
                long babyk = quicklyRaising(a, m * l, p);
                giant.Add(babyk);
                //giant.Add(a0 %p);
                j = baby.IndexOf(giant.Last());
                if (j != -1)
                {

                    i = l;
                    break;
                }
                //a0 *= am;
            }
            if (i == 0)
                return;

            // foreach (var g in giant)
            //   Console.Write(g + " ");
            Console.WriteLine();
            long x = i * m - j;
            Console.WriteLine("x=" + x);


        }




    }
}
