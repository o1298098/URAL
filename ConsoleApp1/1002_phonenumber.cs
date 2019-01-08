using System;
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
            string outstr = "";            string num = inputs[0];            inputs.Remove(num);            List<string> wnums = new List<string>();            if (num == "-1")                return;            const int maxn = 50001 * 51;            int numLength = num.Length;            int count = int.Parse(inputs[0]);            int[] dp = new int[numLength + 1];            int[] path = new int[numLength + 1];            int[] wo = new int[numLength + 1];            string[] words = new string[count];            inputs.Remove(inputs[0]);            for (int i = 0; i < count; i++)            {                string word = inputs[0];                inputs.Remove(word);                words[i] = word;            }            foreach (var a in words)            {                StringBuilder wnum = new StringBuilder();                foreach (var q in a)                {                    switch (q.ToString())                    {                        case "i":                        case "j":                            wnum.Append(1);                            break;                        case "a":                        case "b":                        case "c":                            wnum.Append(2);                            break;                        case "d":                        case "e":                        case "f":                            wnum.Append(3);                            break;                        case "g":                        case "h":                            wnum.Append(4);                            break;                        case "k":                        case "l":                            wnum.Append(5);                            break;                        case "m":                        case "n":                            wnum.Append(6);                            break;                        case "p":                        case "r":                        case "s":                            wnum.Append(7);                            break;                        case "t":                        case "u":                        case "v":                            wnum.Append(8);                            break;                        case "w":                        case "x":                        case "y":                            wnum.Append(9);                            break;                        case "o":                        case "q":                        case "z":                            wnum.Append(0);                            break;                    }                }                wnums.Add(wnum.ToString());            }

            for (int i = 0; i < dp.Count(); i++)            {                dp[i] = -1;                path[i] = -1;                wo[i] = -1;            }            dp[0] = 0;            for (int i = 0; i < numLength; i++)            {
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

                        }                    }            }            if (dp[numLength] > 0)            {                writeword(numLength, path, wo, words);            }            else            {                Console.WriteLine("No solution.");            }
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
