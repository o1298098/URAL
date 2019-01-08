using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1025_DemocracyInDanger
    {
        static void Main1025(string[] args)
        {
            while (true)
            {
                int k = int.Parse(Console.ReadLine());
                List<int> list = new List<int>();
                string[] str = Console.ReadLine().Split(' ');
                for (int i = 0; i < k; i++)
                {
                    list.Add(int.Parse(str[i]));
                }
                int d = k / 2;
                int sum = 0;
                list.Sort();
                for (int i = 0; i < d + 1; i++)
                {
                    int a = list[i];
                    int d1 = a / 2;
                    sum += d1 + 1;
                }
                Console.WriteLine(sum);
                //break;
            }
        }
    }
}
