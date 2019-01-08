using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1023_Buttons
    {
        static void Main1023(string[] args)
        {
            while (true)
            {
                int K = int.Parse(Console.ReadLine());
                int i = 0;
                for (i = 3; i <= K; i++)
                {
                    if (K % i == 0)
                        break;
                }
                Console.WriteLine(i - 1);
                break;
            }
        }
    }
}
