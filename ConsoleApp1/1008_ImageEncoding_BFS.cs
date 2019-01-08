using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1008_ImageEncoding_BFS
    {
        static void Main1008(string[] args)
        {

            List<string> inputs = new List<string>();
            string letter = "RTLB";
            bool[,] pixels = new bool[11, 11];
            int[,] dis = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
            while (true)
            {
                string read = Console.ReadLine();
                string[] split = read.Split(' ');
                if (split.Length > 1)
                {
                    point fpoint = new point { x = int.Parse(split[0]), y = int.Parse(split[1]) };
                    Queue<point> points = new Queue<point>();
                    points.Enqueue(fpoint);
                    pixels[fpoint.x, fpoint.y] = true;
                    while (!string.IsNullOrWhiteSpace(read))
                    {
                        read = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(read))
                            break;
                        inputs.Add(read);
                    }
                    int count = 1;
                    while (points.Count > 0)
                    {
                        read = inputs[0];
                        inputs.RemoveAt(0);
                        point p = points.Dequeue();
                        foreach (var q in read)
                        {
                            int hasletter = letter.IndexOf(q);
                            if (hasletter >= 0)
                            {
                                point np = new point { x = p.x + dis[hasletter, 0], y = p.y + dis[hasletter, 1] };
                                points.Enqueue(np);
                                pixels[np.x, np.y] = true;
                                count++;
                            }

                        }
                    }
                    Console.WriteLine(count);
                    for (int i = 1; i < pixels.GetLength(0); i++)
                    {
                        for (int j = 1; j < pixels.GetLength(1); j++)
                        {
                            if (pixels[i, j])
                                Console.WriteLine(string.Format("{0} {1}", i, j));
                        }


                    }

                }
                else
                {
                    int num = int.Parse(read);
                    point spoint = new point();
                    for (int i = 0; i < num; i++)
                    {
                        read = Console.ReadLine();
                        string[] w = read.Split(' ');
                        point p = new point { x = int.Parse(w[0]), y = int.Parse(w[1]) };
                        pixels[p.x, p.y] = true;
                        if (i == 0)
                            spoint = p;

                    }
                    Console.WriteLine(spoint.x + " " + spoint.y);
                    pixels[spoint.x, spoint.y] = false;
                    Queue<point> points = new Queue<point>();
                    points.Enqueue(spoint);
                    while (points.Count > 0)
                    {
                        point nq = points.Dequeue();
                        for (int i = 0; i < dis.GetLength(0); i++)
                        {
                            point p = new point { x = nq.x + dis[i, 0], y = nq.y + dis[i, 1] };
                            if (!pixels[p.x, p.y])
                                continue;
                            points.Enqueue(p);
                            pixels[p.x, p.y] = false;
                            Console.Write(letter[i]);

                        }
                        Console.WriteLine(points.Count > 0 ? "," : ".");
                    }
                }
                //break; 
            }
        }
        public class point
        {
            public int x { get; set; }
            public int y { get; set; }
        }
    }
}
