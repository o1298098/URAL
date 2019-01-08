﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class phonenumber
    {
        static StringBuilder stringBuilder = new StringBuilder();

        static void Main1002(string[] args)
        {
            List<String> inputs = new List<string>();
            bool isrun = true;
            while (isrun)
            {
                string input = Console.ReadLine();
                inputs.Add(input);
                if (input == "-1")
                {
                    run2(inputs);
                    isrun = false;
                }
            }
        }


        private static bool getword(string num, List<string> wnums, string[] word, StringBuilder builder)
        {
            int count = word.Count() > 1000 ? 1000 : word.Count();

            for (int j = 0; j < count; j++)
            {
                string num2 = num;
                StringBuilder builder2 = new StringBuilder();
                builder2.Append(builder.ToString());
                if (num.Length >= wnums[j].Length)
                {
                    string newnum2 = num2.Substring(0, wnums[j].Length);
                    if (newnum2 == wnums[j])
                    {
                        num2 = num2.Substring(wnums[j].Length);
                        builder2.Append(" " + word[j]);
                        if (num2.Length == 0)
                        {
                            stringBuilder = builder2;
                            num = num2;
                            return true;
                        }
                        bool s = getword(num2, wnums, word, builder2);
                        if (s)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return false;


        }
        private static void run2(List<string> inputs)
        {
            string outstr = "";

            for (int i = 0; i < dp.Count(); i++)
                if (dp[i] != -1)
                    for (int j = 0; j < count; j++)
                    {
                        int numsLen = wnums[j].Length;
                        if (i + numsLen <= numLength)
                        {
                            int last = num.Substring(i, numsLen).IndexOf(wnums[j]);
                            if (last == 0)
                            {
                                if (dp[i + numsLen] != -1)
                                {
                                    if (dp[i + numsLen] > dp[i] + 1)
                                    {
                                        dp[i + numsLen] = dp[i] + 1;
                                        path[i + numsLen] = i;
                                        wo[i + numsLen] = j;
                                    }
                                }
                                else
                                {
                                    dp[i + numsLen] = dp[i] + 1;
                                    path[i + numsLen] = i;
                                    wo[i + numsLen] = j;
                                }

                            }

                        }
            run2(inputs);
        }


        static void writeword(int i, int[] path, int[] wo, string[] words)
        {
            if (path[i] != -1)
                writeword(path[i], path, wo, words);
            if (wo[i] != -1)
                Console.Write(words[wo[i]] + " ");
            if (i == path.Count() - 1)
            {
                Console.WriteLine();
            }




        }
    }
}