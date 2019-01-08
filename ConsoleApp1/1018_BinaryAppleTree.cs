using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1018_BinaryAppleTree
    {
        static int N;
        static int Q;
        static int[,] map;
        static int[,] dp;
        static bool[] w;
        static List<Node> tree;
        static void Main1018(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                string[] split = input.Split(' ');
                N = int.Parse(split[0]);
                Q = int.Parse(split[1]);
                map = new int[N + 1, N + 1];
                dp = new int[N + 1, Q + 1];
                w = new bool[N + 1];
                tree = new List<Node>();
                w[1] = true;
                for (int i = 0; i <= N; i++)
                {
                    tree.Add(new Node());
                    for (int j = 0; j <= N; j++)
                        map[i, j] = -1;
                }
                for (int i = 0; i < N - 1; i++)
                {
                    string read = Console.ReadLine();
                    string[] rsplit = read.Split(' ');
                    int point1 = int.Parse(rsplit[0]);
                    int point2 = int.Parse(rsplit[1]);
                    map[point1, point2] = map[point2, point1] = int.Parse(rsplit[2]);

                }
                createTree(1);
                dfs(1);
                Console.WriteLine(dp[1, Q]);
                break;
            }
        }
        static void createTree(int s)
        {

            bool e = false;
            for (int i = 1; i <= N; i++)
            {
                if (map[s, i] != -1 && !w[i])
                {
                    if (tree[s].Lpoint == 0)
                    {
                        tree[s].Lpoint = i;
                        w[i] = true;
                        e = true;
                    }
                    else
                    {
                        tree[s].Rpoint = i;
                        w[i] = true;
                        e = true;
                        break;
                    }
                }
            }
            if (!e)
            {
                w[s] = true;
                return;
            }
            createTree(tree[s].Lpoint);
            createTree(tree[s].Rpoint);
        }

        static void dfs(int s)
        {
            int lp = tree[s].Lpoint; int rp = tree[s].Rpoint;
            if (lp == 0)
                return;
            dp[s, 1] = Math.Max(map[s, lp], map[s, rp]);
            dfs(lp);
            dfs(rp);
            for (int i = 2; i <= Q; i++)
            {
                dp[s, i] = Math.Max(dp[lp, i - 1] + map[s, lp], dp[rp, i - 1] + map[s, rp]);
                for (int j = 0; j < i - 1; j++)
                    dp[s, i] = Math.Max(dp[s, i], dp[lp, j] + map[s, lp] + dp[rp, i - j - 2] + map[s, rp]);
            }
        }

        public class Node
        {
            public int Lpoint { get; set; }
            public int Rpoint { get; set; }
        }
    }
}
