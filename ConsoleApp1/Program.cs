using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static int n, m, count, ans;
        static int[,] p;

        static void Main(string[] args)
        {
            while (true)
            {
                string[] str = Console.ReadLine().Split(' ');
                n = int.Parse(str[0]);
                m = int.Parse(str[1]);
                p = new int[n + 1 * m + 1, 2];
                ans = 0;
                GetInput(0);
                GetInput(1);
                while (count > 0)
                {
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < n; j++)
                            for (int k = 0; k < j; k++)
                            {

                            }
                }
                Console.WriteLine(ans);
                //break;
            }
        }


        private static void GetInput(int time)
        {
            int ul, ur, dl, dr;
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < m + 1; j++)
                {
                    ul = i * (m + 1) + j;
                    ur = ul + 1;
                    dl = (i + 1) * (m + 1) + j;
                    dr = dl + 1;
                    char c = (char)Console.Read();

                    if (c == 'X' || c == '/')
                    {
                        p[ur, time]++;
                        p[dl, time]++;
                    }
                    if (c == 'X' || c == '\\')
                    {

                        p[ul, time]++;
                        p[dr, time]++;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}

