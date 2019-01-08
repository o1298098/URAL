using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1031_RailwayTickets
    {
        static int L1;
        static int L2;
        static int L3;
        static int C1;
        static int C2;
        static int C3;
        static void Main1031(string[] args)
        {
            while (true)
            {

                string[] strsplit = Console.ReadLine().Split(' ');
                L1 = int.Parse(strsplit[0]);
                L2 = int.Parse(strsplit[1]);
                L3 = int.Parse(strsplit[2]);
                C1 = int.Parse(strsplit[3]);
                C2 = int.Parse(strsplit[4]);
                C3 = int.Parse(strsplit[5]);
                int N = int.Parse(Console.ReadLine());
                strsplit = Console.ReadLine().Split(' ');
                int si = Math.Min(int.Parse(strsplit[0]), int.Parse(strsplit[1]));
                int ei = Math.Max(int.Parse(strsplit[0]), int.Parse(strsplit[1]));
                int[] dis = new int[N + 1];
                int[] dp = new int[N + 1];

                for (int i = 2; i <= N; i++)
                {

                    dis[i] = int.Parse(Console.ReadLine());
                }
                int s1 = si;
                int s2 = si;
                int s3 = si;
                for (int i = si + 1; i <= ei; i++)
                {
                    dp[i] = int.MaxValue;
                    while (dis[i] - dis[s1] > L1)
                        s1++;
                    while (dis[i] - dis[s2] > L2)
                        s2++;
                    while (dis[i] - dis[s3] > L3)
                        s3++;
                    if (s1 < i)
                    {
                        dp[i] = Math.Min(dp[i], (dp[s1] == int.MaxValue ? 0 : dp[s1]) + C1);
                        dp[i] = Math.Min(dp[i], (dp[s2] == int.MaxValue ? 0 : dp[s2]) + C2);
                        dp[i] = Math.Min(dp[i], (dp[s3] == int.MaxValue ? 0 : dp[s3]) + C3);
                    }
                    else if (s2 < i)
                    {
                        dp[i] = Math.Min(dp[i], (dp[s2] == int.MaxValue ? 0 : dp[s2]) + C2);
                        dp[i] = Math.Min(dp[i], (dp[s3] == int.MaxValue ? 0 : dp[s3]) + C3);
                    }
                    else
                        dp[i] = Math.Min(dp[i], (dp[s3] == int.MaxValue ? 0 : dp[s3]) + C3);
                }
                Console.WriteLine(dp[ei]);
                //break;
            }
        }
    }
}
