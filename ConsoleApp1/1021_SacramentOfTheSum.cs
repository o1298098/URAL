using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1021_SacramentOfTheSum
    {
        static void Main1021(string[] args)
        {
            while (true)
            {
                int n1 = int.Parse(Console.ReadLine());
                List<int> list1 = new List<int>();
                for (int i = 0; i < n1; i++)
                {
                    list1.Add(int.Parse(Console.ReadLine()));
                }
                int n2 = int.Parse(Console.ReadLine());
                List<int> list2 = new List<int>();
                for (int i = 0; i < n2; i++)
                {
                    list2.Add(int.Parse(Console.ReadLine()));
                }
                for (int i = 0; i < n2; i++)
                {
                    int r = 10000 - list2[i];
                    var a = list1.BinarySearch(r);
                    if (a >= 0)
                    {
                        Console.WriteLine("YES");
                        return;
                    }
                }
                Console.WriteLine("NO");
                break;
            }
        }
    }
}
