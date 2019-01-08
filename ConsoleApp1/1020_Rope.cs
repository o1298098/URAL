using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1020_Rope
    {
        static void Main1020(string[] args)
        {
            while (true)
            {
                string[] strsplit = Console.ReadLine().Split(' ');
                int n = int.Parse(strsplit[0]);
                double r = double.Parse(strsplit[1]);
                List<point> p = new List<point>();
                for (int i = 0; i < n; i++)
                {
                    string[] a = Console.ReadLine().Split(' ');
                    p.Add(new point { X = double.Parse(a[0]), Y = double.Parse(a[1]) });
                }
                point sp = p[0];
                double sum = 0;
                for (int i = 1; i < p.Count; i++)
                {
                    double x = Math.Abs(p[i].X - sp.X);
                    double y = Math.Abs(p[i].Y - sp.Y);
                    sum = sum + Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                    sp = p[i];
                    if (i == p.Count - 1)
                    {
                        x = Math.Abs(p[i].X - p[0].X);
                        y = Math.Abs(p[i].Y - p[0].Y);
                        sum = sum + Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                    }
                }
                double output = 2 * Math.PI * r + sum;
                Console.WriteLine(output.ToString("f2"));
                //break;
            }
        }

        public class point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
    }
}
