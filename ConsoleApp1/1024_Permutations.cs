using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1024_Permutations
    {
        static void Main1024(string[] args)
        {
            while (true)
            {
                int k = int.Parse(Console.ReadLine());
                string[] str = Console.ReadLine().Split(' ');
                int n = str.Count();
                long[] nums = new long[n + 1];
                long[] arraylcm = new long[n];
                for (int i = 1; i <= n; i++)
                {
                    long s = long.Parse(str[i - 1]);
                    nums[i] = s;
                }
                for (int i = 1; i <= n; i++)
                {
                    long b = nums[i];
                    long c = 1;
                    while (b != i)
                    {
                        b = nums[b];
                        c++;
                    }
                    arraylcm[i - 1] = c;
                }
                long x = arraylcm[0];
                long ans = 1;
                for (int i = 1; i < n; i++)
                {
                    ans = x * arraylcm[i] / GCD(x, arraylcm[i]);
                    x = ans;
                }
                Console.WriteLine(ans);
                //break;
            }
        }

        static long GCD(long a, long b)
        {
            long m1 = Math.Max(a, b);
            long m2 = Math.Min(a, b);
            long m3 = 0;
            while (true)
            {
                m3 = m1 % m2;
                if (m3 == 0)
                    break;
                else
                {
                    m1 = m2;
                    m2 = m3;
                }
            }
            return m2;
        }
    }
}
