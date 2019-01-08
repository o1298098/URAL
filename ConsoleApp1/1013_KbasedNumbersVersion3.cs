using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1013_KbasedNumbersVersion3
    {
        static void Main1013(string[] args)
        {
            while (true)
            {
                long N = long.Parse(Console.ReadLine());
                long K = long.Parse(Console.ReadLine());
                BigInteger[,] matrix = new BigInteger[,] { { K - 1, K - 1 }, { 1, 0 } };
                BigInteger M = BigInteger.Parse(Console.ReadLine());
                BigInteger[,] an = quickpow(matrix, N, M);
                BigInteger r = BigInteger.Remainder(an[0, 0], M);
                Console.WriteLine(r);
                break;
            }
        }


        static BigInteger[,] quickpow(BigInteger[,] a, BigInteger n, BigInteger mod)
        {


            BigInteger[,] ans = new BigInteger[,] { { 1, 0 }, { 0, 1 } };
            BigInteger[,] b = a;
            while (n != 0)
            {
                if ((n & 1) != 0)
                    ans = multiplyMatrix(ans, b, mod);
                b = multiplyMatrix(b, b, mod);
                n >>= 1;
            }
            return ans;
        }

        private static BigInteger[,] multiplyMatrix(BigInteger[,] ans, BigInteger[,] b, BigInteger mod)
        {
            BigInteger[,] e = new BigInteger[,] { { 0, 0 }, { 0, 0 } };
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < e.GetLength(0); k++)
                    {
                        e[i, j] += quickmul(ans[i, k], b[k, j], mod);
                        e[i, j] %= mod;
                    }

                }
            }
            return e;
        }


        static BigInteger quickmul(BigInteger x, BigInteger y, BigInteger mod)
        {
            BigInteger sum = BigInteger.Zero;
            x = x % mod;
            y = y % mod;
            while (y != 0)
            {
                if ((y & 1) != 0)
                    sum = (sum + x) % mod;
                y >>= 1;
                x = (x + x) % mod;
            }
            return sum;
        }
    }
}
