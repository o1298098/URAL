using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class _1032_FindAMultiple
    {
        static int N, k, c;
        static int[] M, a;
        static void Main1032(string[] args)
        {
            while (true)
            {
                M = new int[10000];
                for (int q = 0; q < M.Length; q++)
                    M[q] = -1;
                M[0] = 0;
                k = 0;
                a = new int[10001];
                N = int.Parse(Console.ReadLine());
                for (int i = 1; i <= N; i++)
                {
                    a[i] = int.Parse(Console.ReadLine());
                }
                while (true)
                {
                    c++;
                    k = (k + a[c]) % N;
                    if (M[k] == -1)
                        M[k] = c;
                    else
                    {
                        Console.WriteLine(c - M[k]);
                        for (int i = M[k] + 1; i <= c; i++)
                            Console.WriteLine(a[i]);
                        break;
                    }
                }
                break;
            }
        }
    }
}
