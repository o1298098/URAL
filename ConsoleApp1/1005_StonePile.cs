using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class StonePile1005
    {
        static double min = int.MaxValue;
        static string[] numarray;
        static List<int> list = new List<int>();
        static void Main1005(string[] args)
        {
            bool isrun = true;
            while (isrun)
            {

                int numcount = int.Parse(Console.ReadLine());
                string nums = Console.ReadLine();
                numarray = nums.Split(' ');
                List<int> listA = new List<int>();
                double total = 0;
                for (int i = 0; i < numarray.Count(); i++)
                {
                    int add = int.Parse(numarray[i]);
                    if (add < 1 || add > 100000)
                        continue;
                    total = total + add;
                    run(add, i, numarray.Count());
                }

                double p = total / 2;
                for (int i = 0; i < list.Count; i++)
                {
                    if (Math.Abs(p - list[i]) < Math.Abs(p - min))
                        min = list[i];


                }
                Console.WriteLine(Math.Abs(total - 2 * min));
            }
        }
        static void run(int a, int index, int p)
        {
            list.Add(a);
            for (int i = index + 1; i < p; i++)
                run(a + int.Parse(numarray[i]), i, p);

        }
    }
}