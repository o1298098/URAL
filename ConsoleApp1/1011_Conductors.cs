using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1011_Conductors
    {
        static void Main1011(string[] args)
        {
            while (true)
            {

                string[] num = Console.ReadLine().Trim().Split(' ');
                double P = double.Parse(num[0]);
                double Q = double.Parse(num[1]);
                int citizens = 1;
                double min = 1;
                double max = 0;
                while (min >= max)
                {
                    min = (int)(citizens * P * 100) / 10000 + 1;
                    max = (int)(citizens * Q * 100) / 10000;
                    if ((int)(citizens * Q * 100) % 10000 != 0)
                        max++;
                    citizens++;
                }
                Console.WriteLine(citizens - 1);
                break;
            }
        }
    }
}
