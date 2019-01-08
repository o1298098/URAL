using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1010_DiscreteFunction
    {
        static void Main1010(string[] args)
        {
            while (true)
            {
                int num = int.Parse(Console.ReadLine());
                long[] values = new long[num];
                for (int i = 0; i < num; i++)
                {
                    values[i] = long.Parse(Console.ReadLine());
                }
                int max = 1;
                long maxins = Math.Abs(values[1] - values[0]);
                for (int i = 2; i < num; i++)
                {
                    if (maxins < Math.Abs(values[i] - values[i - 1]))
                    {
                        maxins = Math.Abs(values[i] - values[i - 1]);
                        max = i;
                    }
                }
                Console.WriteLine(string.Format("{0} {1}", max, max + 1));
                break;
            }
        }
    }
}
