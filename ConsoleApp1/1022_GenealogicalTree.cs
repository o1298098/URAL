using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1022_GenealogicalTree
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = int.Parse(Console.ReadLine());
                int[,] m = new int[n + 1, n + 1];
                int[] b = new int[n + 1];
                for (int i = 1; i < n + 1; i++)
                {
                    string[] str = Console.ReadLine().Split(' ');
                    for (int j = 0; j < str.Count(); j++)
                    {
                        int k = int.Parse(str[j]);
                        if (k == 0)
                            break;
                        b[k]++;
                        m[i, k] = 1;
                    }

                }
                for (int i = 1; i < n + 1; i++)
                {
                    int j = 1;
                    while (b[j] != 0)
                        j++;
                    Console.Write(j + " ");
                    b[j] = int.MaxValue;
                    for (int k = 1; k < n + 1; k++)
                    {
                        if (m[j, k] == 1)
                            b[k]--;
                    }
                }
                //break;
            }
        }
    }
}

