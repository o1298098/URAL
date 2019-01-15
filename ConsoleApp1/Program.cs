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
        static int[,,] p;
        static int[,,] type = new int[4, 12, 3] { 
            { { 1, 0, 1 }, { 1, 0, 3 }, { 0, -1, 1 }, { 0, -1, 3 }, { 1, -1, 0 }, { 1, -1, 2 }, { 0, 1, 1 }, { 0, 1, 3 }, { -1, 0, 1 }, { -1, 0, 3 }, { -1, 1, 0 }, { -1, 1, 2 } }, 
            { { -1, -1, 1 }, { -1, -1, 3 }, { -1, 0, 0 }, { -1, 0, 2 }, { 0, -1, 0 }, { 0, -1, 2 }, { 1, 1, 1 }, { 1, 1, 3 }, { 1, 0, 0 }, { 1, 0, 2 }, { 0, 1, 0 }, { 0, 1, 2 } }, 
            { { 1, 0, 3 }, { 1, 0, 1 },{ 0, -1, 3 }, { 0, -1, 1 }, { 1, -1, 2 }, { 1, -1, 0 }, { 0, 1, 3 }, { 0, 1, 1 }, { -1, 0, 3 }, { -1, 0, 1 }, { -1, 1, 2 }, { -1, 1, 0 }}, 
            { { -1, -1, 3 }, { -1, -1, 1 }, { -1, 0, 2 }, { -1, 0, 0 }, { 0, -1, 2 }, { 0, -1, 0 }, { 1, 1, 3 }, { 1, 1,1 }, { 1, 0, 2 }, { 1, 0, 0 }, { 0, 1, 2 }, { 0, 1,0 } } };
        static int[] rd = {2,3,0,1 };
        static void Main(string[] args)
        {
            while (true)
            {
                string[] str = Console.ReadLine().Split(' ');
                n = int.Parse(str[0]);
                m = int.Parse(str[1]);
                p = new int[n, m, 4];
                ans = 0;
                GetInput(1);
                GetInput(2);
                while (count > 0)
                {
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < m; j++)
                            for (int k = 0; k < 4; k++)
                            {
                                if (p[i, j, k] == 1)
                                {
                                    count--;
                                    ans++;
                                    p[i, j, k] = 0;
                                    dfs(i, j, k);
                                }

                            }
                }
                Console.WriteLine(ans);
                //break;
            }
        }

        private static void dfs(int i, int j, int k)
        {
            if (count <= 0)
                return;
            bool x = false;
            bool y = false;
            for (int l = 0; l < 6; l++)
                if (i + type[k, l, 0] <= n - 1&&i + type[k, l, 0] >=0 && j + type[k, l, 1] <= m - 1&& j + type[k, l, 1]>=0)
                    if (p[i + type[k, l, 0], j + type[k, l, 1], type[k, l, 2]] == 1)
                    {
                        count--;
                        x = true;
                        p[i + type[k, l, 0], j + type[k, l, 1], type[k, l, 2]] = 0;
                        dfs(i + type[k, l, 0], j + type[k, l, 1], type[k, l, 2]);
                        break;
                    }
            for (int l = 6; l < 12; l++)
                if (i + type[k, l, 0] <= n - 1 && i + type[k, l, 0] >= 0 && j + type[k, l, 1] <= m - 1 && j + type[k, l, 1] >= 0)
                    if (p[i + type[k, l, 0], j + type[k, l, 1], type[k, l, 2]] == 1)
                    {
                        count--;
                        y = true;
                        p[i + type[k, l, 0], j + type[k, l, 1], type[k, l, 2]] = 0;
                        dfs(i + type[k, l, 0], j + type[k, l, 1], type[k, l, 2]);
                        break;
                    }
            if ((!x || !y) && (i == 0 || i == n - 1 || j == 0 || j == m - 1))
                if (p[i, j, rd[k]] == 1)
                {
                    count--;
                    p[i, j, rd[k]] = 0;
                    dfs(i, j, rd[k]);
                }
        }

        private static void GetInput(int time)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    char c = (char)Console.Read();
                    switch (c)
                    {
                        case '/':
                            if (time == 1)
                                p[i, j, 0] = 1;
                            else
                                p[i, j, 2] = 1;
                            count++;
                            break;
                        case '\\':
                            if (time == 1)
                                p[i, j, 1] = 1;
                            else
                                p[i, j, 3] = 1;
                            count++;
                            break;
                        case 'X':
                            if (time == 1)
                                p[i, j, 0] = p[i, j, 1] = 1;
                            else
                                p[i, j, 2] = p[i, j, 3] = 1;
                            count += 2;
                            break;
                    }
                }
                Console.ReadLine();
            }
        }
    }
}

