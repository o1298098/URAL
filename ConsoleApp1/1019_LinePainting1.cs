using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1019_LinePainting1
    {
        static int max = 10010;
        static List<Node> node = new List<Node>();
        static int[] num = new int[max];
        static int[] color = new int[max];
        static int n;
        static Dictionary<int, int> map;
        static int t;
        static void Main1019(string[] args)
        {
            while (true)
            {
                n = int.Parse(Console.ReadLine());
                num[t++] = 0;
                num[t++] = 1000000000;
                map = new Dictionary<int, int>();
                for (int i = 0; i < n; i++)
                {
                    string[] strsplit = Console.ReadLine().Split(' ');
                    node.Add(new Node { L = int.Parse(strsplit[0]), R = int.Parse(strsplit[1]), C = strsplit[2] == "b" ? true : false });
                    num[t++] = node[i].L;
                    num[t++] = node[i].R;
                }
                num = num.OrderBy(o => o).ToArray();
                num = num.Distinct().ToArray();
                t = num.Count();
                for (int i = 0; i < num.Count(); i++)
                    map[num[i]] = i;
                for (int i = 0; i < n; i++)
                {
                    int temp = 0;
                    if (node[i].C)
                        temp = 1;
                    for (int j = map[node[i].L] + 1; j <= map[node[i].R]; j++)
                    {
                        color[j] = temp;
                    }
                }
                int L = 0, R = 0, len = 0;
                for (int i = 0; i < t; i++)
                {
                    if (color[i] == 1)
                        continue;
                    int j = i;
                    int k = i == 0 ? i : i - 1;
                    while (color[j] == 0 && j < t)
                        j++;
                    if (len < num[j - 1] - num[k])
                    {
                        L = num[k];
                        R = num[j - 1];
                        len = num[j - 1] - num[k];
                    }

                }
                Console.WriteLine(L + " " + R);
                //break;
            }
        }
        public class Node
        {
            public int L { get; set; }
            public int R { get; set; }
            public bool C { get; set; }

        }

    }
}
