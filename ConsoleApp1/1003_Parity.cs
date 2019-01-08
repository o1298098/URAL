using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Parity1003
    {
        static Dictionary<int, bool> odd;
        static Dictionary<int, int> prev;
        static void Main1003(string[] args)
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
                    //isrun = false;
                }
            }

        }
        static void run(List<String> inputs)
        {
            int range = int.Parse(inputs[0]);
            inputs.Remove(inputs[0]);
            if (range == -1)
                return;
            int count = int.Parse(inputs[0]);
            inputs.Remove(inputs[0]);
            odd = new Dictionary<int, bool>();
            prev = new Dictionary<int, int>();
            List<string[]> list = new List<string[]>();
            bool f = false;
            for (int i = 2; i < count + 2; i++)
            {
                string[] splitlist = inputs[0].Split(' ');
                inputs.Remove(inputs[0]);
                int start = int.Parse(splitlist[0]);
                int end = int.Parse(splitlist[1]);
                if (!f)
                {
                    if (end > range)
                    {
                        Console.WriteLine(i - 2);
                        f = true;
                        continue;
                    }
                    if (!add(start, end, splitlist[2] == "odd"))
                    {
                        Console.WriteLine(i - 2);
                        f = true;
                    }
                }
            }
            if (!f)
            {
                Console.WriteLine(count);
            }
            run(inputs);
        }

        static bool add(int a, int b, bool c)
        {
            if (!prev.ContainsKey(b))
            {
                odd[b] = c;
                prev[b] = a;
            }
            int i = prev[b];
            if (i == a)
                return odd[b] == c;
            if (i < a)
                return add(i, a - 1, c != odd[b]);
            return add(a, i - 1, c != odd[b]);
        }


    }
}
