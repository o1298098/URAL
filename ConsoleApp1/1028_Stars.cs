using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1028_Stars
    {
        static int[] a = new int[32005];
        static int[] lv = new int[15000];
        static void Main1028(string[] args)
        {
            while (true)
            {
                int N = int.Parse(Console.ReadLine());
                lv = new int[N];
                for (int i = 0; i < N; i++)
                {
                    string[] strsplit = Console.ReadLine().Split(' ');
                    int s = 0;
                    int x = int.Parse(strsplit[0]);
                    int c = int.Parse(strsplit[0]);
                    x++;
                    c++;
                    while (c > 0)
                    {
                        s += a[c];
                        c -= bit(c);
                    }
                    lv[s]++;
                    update(x, 1);

                }
                for (int i = 0; i < N; i++)
                    Console.WriteLine(lv[i]);
                break;
            }
        }
        static public void update(int p, int v)
        {
            while (p <= 32005)
            {
                a[p] += v;
                p += bit(p);
            }
        }

        static public int bit(int a)
        {
            return a & -a;
        }
    }
}
