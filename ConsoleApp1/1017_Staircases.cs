using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1017_Staircases
    {
        static void Main1017(string[] args)
        {
            while (true)
            {
                int N = int.Parse(Console.ReadLine());
                long[,] f = new long[N + 1, N + 1];
                for (int i = 3; i <= N; i++)
                {
                    for (int j = 2; j < i; j++)
                    {
                        for (int k = 2; k < j; k++)
                            f[i, j] += f[i - j, k];
                        f[i, j] += i - j < j ? 1 : 0;
                    }


                }
                long sum = 0;
                for (int i = 1; i <= N; i++)
                    sum += f[N, i];
                Console.WriteLine(sum);
                break;
            }
        }

    }
}
