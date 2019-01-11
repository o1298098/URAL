using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URAL
{
    class _1034_QueensInPeacefulPositions
    {
        static int[] x;
        static int[] y;
        static int[] y2;
        static int[,] type;
        static int n;
        static void Main1034(string[] args)
        {
            while (true)
            {
                n = int.Parse(Console.ReadLine());
                x = new int[n];
                y = new int[n];
                y2 = new int[n];
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    string[] s = Console.ReadLine().Split(' ');
                    x[i] = int.Parse(s[0]);
                    y[i] = int.Parse(s[1]);
                }
                for (int i = 0; i < n; i++)
                    for (int j = i + 1; j < n; j++)
                    {
                        if (j + 1 > n - 1)
                            break;
                        int r = j - i;
                        y2 = (int[])y.Clone();
                        for (int k = j + 1; k < n; k++)
                        {
                            y2 = (int[])y.Clone();
                            int r2 = k - j;
                            int r3 = k - i;
                            type = new int[2, 3] { { r, r2, -r3 }, { r3, -r, -r2 } };
                            for (int l = 0; l < type.GetLength(0); l++)
                            {
                                y2[i] = y[i + type[l, 0]];
                                y2[j] = y[j + type[l, 1]];
                                y2[k] = y[k + type[l, 2]];
                                if (check())
                                    count++;
                            }
                        }

                    }
                Console.WriteLine(count);
                //break;
            }
        }

        static bool check()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int sx = Math.Abs(x[i] - x[j]);
                    int sy = Math.Abs(y2[i] - y2[j]);
                    if (sx == sy)
                        return false;
                }
            }
            return true;
        }
    }
}
