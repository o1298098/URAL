﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1012_KbasedNumbersVersion2
    {
        static void Main1012(string[] args)
        {
            while (true)
            {
                int N = int.Parse(Console.ReadLine());
                int K = int.Parse(Console.ReadLine());
                BigInteger[] dp = new BigInteger[N + 1];

                dp[1] = K - 1;
                dp[2] = K * dp[1];
                for (int i = 3; i < N + 1; i++)
                {
                    dp[i] = (K - 1) * dp[i - 1] + (K - 1) * dp[i - 2];
                }
                Console.WriteLine(dp[N]);
                //break;
            }
        }
    }
}
