using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1033
    {
        static int[,] S;
        static int sum, n;
        static Square[,] L;
        static void Main1033(string[] args)
        {
            while (true)
            {
                sum = 0;
                n = int.Parse(Console.ReadLine());
                L = new Square[n, n];
                S = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        L[i, j] = new Square();
                        char v = (char)Console.Read();
                        if (v == '#')
                            S[i, j] = -1;
                    }
                    Console.ReadLine();
                }
                DFS(0, 0);
                DFS(n - 1, n - 1);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (L[i, j].state)
                            sum = sum + L[i, j].sum;
                Console.WriteLine(sum);
                //break;
            }
        }

        static void DFS(int i, int j)
        {
            if (!L[i, j].isvisic)
            {
                L[i, j].isvisic = true;
                if (i == 0 && j != 0)
                    L[i, j].T = 1;
                if (j == n - 1 && i != n - 1)
                    L[i, j].R = 1;
                if (i == n - 1 && j != n - 1)
                    L[i, j].B = 1;
                if (j == 0 && i != 0)
                    L[i, j].L = 1;
                if (i + 1 <= n - 1)
                    if (S[i + 1, j] == -1)
                        L[i, j].B = 1;
                    else
                        DFS(i + 1, j);
                if (j + 1 <= n - 1)
                    if (S[i, j + 1] == -1)
                        L[i, j].R = 1;
                    else
                        DFS(i, j + 1);
                if (i - 1 >= 0)
                    if (S[i - 1, j] == -1)
                        L[i, j].T = 1;
                    else
                        DFS(i - 1, j);
                if (j - 1 >= 0)
                    if (S[i, j - 1] == -1)
                        L[i, j].L = 1;
                    else
                        DFS(i, j - 1);
            }
        }
        public class Square
        {
            public bool isvisic { get; set; }
            public int L { get; set; }
            public int R { get; set; }
            public int T { get; set; }
            public int B { get; set; }
            public bool state { get { return (L + R + T + B) == 4 ? false : true; } }
            public int sum { get { return state ? (L + R + T + B) * 9 : 0; } }
            public void SetValue(int l, int r, int t, int b)
            {
                L = l;
                R = r;
                T = t;
                B = b;
            }

        }
    }
}
