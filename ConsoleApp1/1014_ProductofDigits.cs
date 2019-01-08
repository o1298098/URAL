using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1014_ProductofDigits
    {
        static void Main1014(string[] args)
        {
            while (true)
            {

                int input = int.Parse(Console.ReadLine());
                if (input < 10 && input > 0)
                {
                    Console.WriteLine(input);
                }
                else if (input == 0)
                {
                    Console.WriteLine("10");
                }
                else
                {
                    int n = 9;
                    int f = input;
                    List<int> num = new List<int>();
                    while (n > 1 && f > 1)
                    {
                        int rem = -1;
                        int div = Math.DivRem(f, n, out rem);
                        if (rem == 0)
                        {
                            f = div;
                            num.Add(n);
                        }
                        else
                        {
                            n--;
                        }
                    }
                    if (f > 10)
                    {
                        Console.WriteLine("-1");
                    }
                    else
                    {
                        for (int i = num.Count - 1; i >= 0; i--)
                        {
                            Console.Write(num[i]);
                        }
                        Console.WriteLine();

                    }
                }
                //break;
            }
        }
    }
}
