using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1016_CubeOnTheWalk
    {
        static void Main1016(string[] args)
        {
            List<int[]> rtype = new List<int[]>
            {
               new int[] {0,1,2,3,4,5}, new int[]{0,1,4,5,2,3}, new int[]{0,1,3,4,5,2}, new int[] {0,1,5,2,3,4},
               new int[] {1,0,2,5,4,3}, new int[]{1,0,3,2,5,4}, new int[]{1,0,4,3,2,5}, new int[] {1,0,5,4,3,2},
               new int[] {2,4,0,5,1,3}, new int[]{2,4,1,3,0,5}, new int[]{2,4,3,0,5,1}, new int[] {2,4,5,1,3,0},
               new int[] {3,5,0,2,1,4}, new int[]{3,5,1,4,0,2}, new int[]{3,5,2,1,4,0}, new int[] {3,5,4,0,2,1},
               new int[] {4,2,0,3,1,5}, new int[]{4,2,1,5,0,3}, new int[]{4,2,3,1,5,0}, new int[] {4,2,5,0,3,1},
               new int[] {5,3,0,4,1,2}, new int[]{5,3,1,2,0,4}, new int[]{5,3,2,0,4,1}, new int[] {5,3,4,1,2,0},
            };
            int[,] type = new int[,] { { 0, -1 }, { 0, 1 }, { 1, 0 }, { -1, 0 } };//TBRL
            int[,] rotatetype = new int[4, 6]{
                    {2,4,1,3,0,5 },//down
                    {4,2,0,3,1,5 },//up                    
                    {0,1,5,2,3,4 },//right
                    {0,1,3,4,5,2 },//left
                };
            while (true)
            {
                string input = Console.ReadLine();
                string[] split = input.Split(' ');
                string start = split[0];
                string end = split[1];
                point sp = new point { X = start[0] - 'a', Y = start[1] - '1' };
                point ep = new point { X = end[0] - 'a', Y = end[1] - '1' };
                int near = int.Parse(split[2]);
                int far = int.Parse(split[3]);
                int top = int.Parse(split[4]);
                int right = int.Parse(split[5]);
                int bottom = int.Parse(split[6]);
                int left = int.Parse(split[7]);
                string letter = "abcdefgh";
                int[] incube = new int[6] { near, far, top, right, bottom, left };
                int[,,] dis = new int[8, 8, 24];
                for (int i = 0; i < dis.GetLength(0); i++)
                    for (int j = 0; j < dis.GetLength(1); j++)
                        for (int k = 0; k < dis.GetLength(2); k++)
                        {
                            dis[i, j, k] = int.MaxValue;
                        }
                dis[sp.X, sp.Y, 0] = incube[4];
                cube[,,] prev = new cube[8, 8, 24];
                PriorityQueue<cube> queue = new PriorityQueue<cube>(new DinoComparer());
                queue.Push(new cube(sp.X, sp.Y, incube[4], 0));
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(start + " ");
                cube position = new cube(sp.X, sp.Y, incube[4], 0);
                DinoComparer comparer = new DinoComparer();
                while (position.X != ep.X || position.Y != ep.Y)
                {
                    cube next = queue.Pop();
                    position = next;
                    if (next.Len <= dis[next.X, next.Y, next.Rtype])
                    {
                        for (int i = 0; i < type.GetLength(0); i++)
                        {
                            point pr = new point { X = next.X + type[i, 0], Y = next.Y + type[i, 1] };
                            if (pr.X < 0 || pr.Y < 0 || pr.X > 7 || pr.Y > 7)
                                continue;
                            int[] ncube = new int[] { rtype[next.Rtype][rotatetype[i, 0]], rtype[next.Rtype][rotatetype[i, 1]], rtype[next.Rtype][rotatetype[i, 2]], rtype[next.Rtype][rotatetype[i, 3]], rtype[next.Rtype][rotatetype[i, 4]], rtype[next.Rtype][rotatetype[i, 5]] };
                            int ntype = rtype.FindIndex(new Predicate<int[]>(delegate (int[] x) {
                                int o = 0;
                                while (o < x.Length && x[o] == ncube[o]) o++;
                                return (o == x.Length) ? true : false;
                            }));
                            int newlen = next.Len + incube[rtype[ntype][4]];
                            if (dis[pr.X, pr.Y, ntype] <= newlen)
                                continue;
                            dis[pr.X, pr.Y, ntype] = newlen;
                            prev[pr.X, pr.Y, ntype] = next;
                            queue.Push(new cube(pr.X, pr.Y, newlen, ntype));

                        }
                    }
                }
                Stack<point> path = new Stack<point>();
                cube endcube = new cube(ep.X, ep.Y, 0, position.Rtype);
                while (endcube.X != sp.X || endcube.Y != sp.Y || endcube.Rtype != 0)
                {
                    endcube = prev[endcube.X, endcube.Y, endcube.Rtype];
                    path.Push(new point { X = endcube.X, Y = endcube.Y });
                }
                Console.Write(dis[ep.X, ep.Y, position.Rtype] + " ");
                foreach (var q in path.ToArray())
                {
                    string p = letter[q.X].ToString() + (q.Y + 1);
                    Console.Write(p + " ");
                }
                Console.Write(end);
                //break;
            }

        }

        public class DinoComparer : IComparer<cube>
        {
            public int Compare(cube x, cube y)
            {
                return (x.Len == y.Len) ? 0 : ((x.Len < y.Len) ? 1 : -1);
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
        public class cube
        {
            public int Len { get; }
            public point Point { get; }
            public int Rtype { get; }
            public int X { get { return Point.X; } }
            public int Y { get { return Point.Y; } }
            public cube(int X, int Y, int Len, int Rtype)
            {
                this.Point = new point { X = X, Y = Y };
                this.Len = Len;
                this.Rtype = Rtype;
            }

        }
        public class point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
