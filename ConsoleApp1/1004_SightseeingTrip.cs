using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SightseeingTrip1004
    {
        static int[,] dis;
        static int[,] path;
        static int[,] arc;
        static int[] dp;
        static int last, num;
        static List<int> o = new List<int>();
        static void Main1004(string[] args)
        {
            List<String> inputs = new List<string>();
            bool isrun = true;
            while (isrun)
            {
                string input = Console.ReadLine();
                inputs.Add(input);
                if (input == "-1")
                {
                    run(inputs);
                    //isrun=false;
                }
            }
        }

        static void run(List<string> inputs)
        {
            string[] fristline = inputs[0].Split(' ');
            inputs.Remove(inputs[0]);
            if (fristline[0] == "-1")
            {
                return;
            }
            int loadcount = int.Parse(fristline[1]);
            int pointcount = int.Parse(fristline[0]);
            dis = new int[pointcount + 1, pointcount + 1];
            path = new int[pointcount + 1, pointcount + 1];
            arc = new int[pointcount + 1, pointcount + 1];
            dp = new int[pointcount + 1];
            last = int.MaxValue;
            for (int i = 1; i <= pointcount; i++)
            {
                for (int j = 1; j <= pointcount; j++)
                {
                    dis[i, j] = int.MaxValue;
                    path[i, j] = i;
                    arc[i, j] = int.MaxValue;
                }
            }
            for (int i = 1; i <= loadcount; i++)
            {
                string[] loadinfo = inputs[0].Split(' ');
                inputs.Remove(inputs[0]);
                int sp = int.Parse(loadinfo[0]);
                int ep = int.Parse(loadinfo[1]);
                if (sp > pointcount || ep > pointcount)
                    continue;
                int lenght = int.Parse(loadinfo[2]);
                if (arc[sp, ep] > lenght)
                {
                    arc[sp, ep] = lenght;
                    arc[ep, sp] = lenght;
                    dis[sp, ep] = lenght;
                    dis[ep, sp] = lenght;

                }
            }

            for (int i = 1; i <= pointcount; i++)
            {
                for (int row = 1; row < i; row++)
                {
                    for (int col = row + 1; col < i; col++)
                    {
                        int t = (arc[row, i] == int.MaxValue || arc[i, col] == int.MaxValue || dis[row, col] == int.MaxValue) ? int.MaxValue : dis[row, col] + arc[row, i] + arc[i, col];
                        if (last > t)
                        {
                            last = t;
                            num = 0;
                            int p = col;
                            while (p != row)
                            {
                                dp[num++] = p;
                                p = path[row, p];
                            }
                            dp[num++] = row;
                            dp[num++] = i;
                        }

                    }
                }

                for (int row = 1; row <= pointcount; row++)
                {
                    for (int col = 1; col <= pointcount; col++)
                    {
                        int t = (dis[row, i] == int.MaxValue || dis[i, col] == int.MaxValue) ? int.MaxValue : dis[row, i] + dis[i, col];

                        if (t < dis[row, col])
                        {
                            dis[row, col] = t;
                            path[row, col] = path[i, col];
                        }
                    }

                }


            }


            if (last < int.MaxValue)
            {
                Console.Write(dp[0] + " ");
                for (int i = 1; i < num; i++)
                {
                    Console.Write(dp[i] + " ");
                }
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("No solution.");
            }
            run(inputs);

        }

    }
}
