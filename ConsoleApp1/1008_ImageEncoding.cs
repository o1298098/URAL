using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1008_ImageEncoding
    {
        static void Main1008(string[] args)
        {

            List<point> coord = new List<point>();
            List<point> last = new List<point>();
            List<point> selected = new List<point>();
            List<string> inputs = new List<string>();
            char[] dis = { 'R', 'T', 'L', 'B' };
            while (true)
            {
                string read = Console.ReadLine();
                string[] split = read.Split(' ');
                if (split.Length > 1)
                {
                    point fpoint = new point { x = int.Parse(split[0]), y = int.Parse(split[1]) };
                    selected.Add(fpoint);
                    while (!string.IsNullOrWhiteSpace(read))
                    {
                        read = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(read))
                            break;
                        inputs.Add(read);
                    }
                    while (read != ".")
                    {

                        read = inputs[0];
                        inputs.RemoveAt(0);
                        point npoint = new point();
                        foreach (var q in read)
                        {
                            string sy = q.ToString();
                            switch (sy)
                            {
                                case "R":
                                    selected.Add(new point { x = fpoint.x + 1, y = fpoint.y });
                                    last.Add(new point { x = fpoint.x + 1, y = fpoint.y });
                                    break;
                                case "T":
                                    selected.Add(new point { x = fpoint.x, y = fpoint.y + 1 });
                                    last.Add(new point { x = fpoint.x, y = fpoint.y + 1 });
                                    break;
                                case "L":
                                    selected.Add(new point { x = fpoint.x - 1, y = fpoint.y });
                                    last.Add(new point { x = fpoint.x - 1, y = fpoint.y });
                                    break;
                                case "B":
                                    selected.Add(new point { x = fpoint.x, y = fpoint.y - 1 });
                                    last.Add(new point { x = fpoint.x, y = fpoint.y - 1 });
                                    break;
                            }

                        }
                        if (last.Count > 0)
                        {
                            fpoint = last[0];
                            last.RemoveAt(0);
                        }

                    }
                    selected.Sort((point a, point b) => { return a.x > b.x ? 1 : a.x == b.x && a.y > b.y ? 1 : -1; });
                    Console.WriteLine(selected.Count);
                    foreach (var q in selected)
                    {
                        if (q.x <= 10 && q.y <= 10)
                            Console.WriteLine(string.Format("{0} {1}", q.x, q.y));
                    }

                }
                else
                {
                    int num = int.Parse(read);
                    while (!string.IsNullOrWhiteSpace(read))
                    {
                        read = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(read))
                            break;
                        string[] w = read.Split(' ');
                        coord.Add(new point { x = int.Parse(w[0]), y = int.Parse(w[1]) });
                    }
                    coord.Sort((point a, point b) => { return a.x > b.x ? 1 : a.x == b.x && a.y > b.y ? 1 : -1; });
                    point spoint = coord[0];
                    selected.Add(spoint);
                    Console.WriteLine(coord[0].x + " " + coord[0].y);

                    while (spoint != null)
                    {

                        StringBuilder stringBuilder = new StringBuilder();
                        point rpointselected = null;
                        point tpointselected = null;
                        point lpointselected = null;
                        point bpointselected = null;
                        var rpoint = (from q in coord
                                      where q.y == spoint.y && q.x == spoint.x + 1
                                      select q).FirstOrDefault();
                        var tpoint = (from q in coord
                                      where q.y == spoint.y + 1 && q.x == spoint.x
                                      select q).FirstOrDefault();
                        var lpoint = (from q in coord
                                      where q.y == spoint.y && q.x == spoint.x - 1
                                      select q).FirstOrDefault();
                        var bpoint = (from q in coord
                                      where q.y == spoint.y - 1 && q.x == spoint.x
                                      select q).FirstOrDefault();
                        if (selected.Count > 0)
                        {
                            rpointselected = (from q in selected
                                              where q.y == spoint.y && q.x == spoint.x + 1
                                              select q).FirstOrDefault();
                            tpointselected = (from q in selected
                                              where q.y == spoint.y + 1 && q.x == spoint.x
                                              select q).FirstOrDefault();
                            lpointselected = (from q in selected
                                              where q.y == spoint.y && q.x == spoint.x - 1
                                              select q).FirstOrDefault();
                            bpointselected = (from q in selected
                                              where q.y == spoint.y - 1 && q.x == spoint.x
                                              select q).FirstOrDefault();
                        }
                        if (rpoint != null)
                        {
                            if (rpointselected == null)
                            {
                                stringBuilder.Append("R");
                                selected.Add(rpoint);
                                last.Add(rpoint);
                            }

                        }
                        if (tpoint != null)
                        {
                            if (tpointselected == null)
                            {
                                stringBuilder.Append("T");
                                selected.Add(tpoint);
                                last.Add(tpoint);
                            }
                        }
                        if (lpoint != null)
                        {
                            if (lpointselected == null)
                            {
                                stringBuilder.Append("L");
                                selected.Add(lpoint);
                                last.Add(lpoint);
                            }
                        }
                        if (bpoint != null)
                        {
                            if (bpointselected == null)
                            {
                                stringBuilder.Append("B");
                                selected.Add(bpoint);
                                last.Add(bpoint);
                            }
                        }

                        if (last.Count > 0)
                        {
                            spoint = last[0];
                            last.RemoveAt(0);
                            Console.WriteLine(stringBuilder.ToString() + ",");
                        }
                        else
                        {
                            Console.WriteLine(".");
                            break;
                        }

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
