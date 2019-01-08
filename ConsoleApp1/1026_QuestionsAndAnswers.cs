using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1026_QuestionsAndAnswers
    {
        static void Main1026(string[] args)
        {
            while (true)
            {
                int N = int.Parse(Console.ReadLine());
                List<int> list = new List<int>();
                for (int i = 0; i < N; i++)
                {
                    list.Add(int.Parse(Console.ReadLine()));
                }
                Console.ReadLine();
                int K = int.Parse(Console.ReadLine());
                list.Sort();
                for (int i = 0; i < K; i++)
                {
                    int j = int.Parse(Console.ReadLine());
                    Console.WriteLine(list[j - 1]);
                }
                //break;
            }
        }
    }
}
