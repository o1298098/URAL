using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1029_Ministry_dijkstra
    {
        static void Main1029(string[] args)
        {
            while (true)
            {
                string[] str = Console.ReadLine().Split(' ');
                int M = int.Parse(str[0]);
                int N = int.Parse(str[1]);
                int[,] floor = new int[M, N];
                int[,] dic = new int[M, N];
                Room[,] path = new Room[M, N];
                int[,] type = new int[,] { { 1, 0 }, { 0, -1 }, { 0, 1 } };
                for (int i = 0; i < M; i++)
                {
                    str = Console.ReadLine().Split(' ');
                    for (int j = 0; j < N; j++)
                    {
                        floor[i, j] = int.Parse(str[j]);
                        dic[i, j] = int.MaxValue;
                    }

                }
                PriorityQueue<Room> queue = new PriorityQueue<Room>(new DinoComparer());
                int min = int.MaxValue;
                int index = -1;
                for (int i = 0; i < N; i++)
                {
                    if (min >= floor[0, i])
                    {
                        queue.Push(new Room { M = 0, N = i, cost = floor[0, i] });
                    }
                }
                int f = 0;

                Room r = new Room();
                while (f < M - 1)
                {
                    r = queue.Pop();
                    f = r.M;
                    for (int i = 0; i < type.GetLength(0); i++)
                    {
                        int newM = r.M + type[i, 0];
                        int newN = r.N + type[i, 1];
                        if (newN > N - 1 || newN < 0 || newM > M - 1 || newM < 0)
                            continue;
                        int newcost = r.cost + floor[newM, newN];
                        if (dic[newM, newN] <= newcost)
                            continue;
                        queue.Push(new Room { M = newM, N = newN, cost = newcost });
                        dic[newM, newN] = newcost;
                        path[newM, newN] = r;
                    }
                }
                StringBuilder ans = new StringBuilder();
                while (r != null)
                {

                    int ks = r.N + 1;
                    ans.Insert(0, ks + " ");
                    if (r.M == 0)
                        break;
                    r = path[r.M, r.N];
                }
                Console.WriteLine(ans.ToString());
                //break;
            }
        }

        public class Room
        {
            public int M { get; set; }
            public int N { get; set; }
            public int cost { get; set; }
        }
        public class DinoComparer : IComparer<Room>
        {
            public int Compare(Room x, Room y)
            {
                return (x.cost == y.cost) ? 0 : ((x.cost < y.cost) ? 1 : -1);
            }
        }
        class PriorityQueue<T>
        {
            List<T> queue = new List<T>();
            IComparer<T> comparer;

            public PriorityQueue(IComparer<T> comparer)
            {
                this.comparer = comparer;
            }

            public void Push(T v)
            {
                int i = queue.BinarySearch(v, comparer);
                queue.Insert((i < 0) ? ~i : i, v);
            }

            public T Pop()
            {
                T v = queue[queue.Count - 1];
                queue.RemoveAt(queue.Count - 1);
                return v;
            }
        }
    }
}

