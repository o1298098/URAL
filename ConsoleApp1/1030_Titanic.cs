using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1030_Titanic
    {
        static void Main1030(string[] args)
        {
            while (true)
            {
                double D = 6875;
                for (int i = 0; i < 3; i++)
                    Console.ReadLine();
                string[] str1 = Console.ReadLine().Split(' ');
                double x1 = AngleToRadians(convertangle(str1[0]));
                string xf1 = str1[1];
                str1 = Console.ReadLine().Split(' ');
                double y1 = AngleToRadians(convertangle(str1[1]));
                string yf1 = str1[2];
                Console.ReadLine();
                str1 = Console.ReadLine().Split(' ');
                double x2 = AngleToRadians(convertangle(str1[0]));
                string xf2 = str1[1];
                str1 = Console.ReadLine().Split(' ');
                double y2 = AngleToRadians(convertangle(str1[1]));
                string yf2 = str1[2];
                Console.ReadLine();
                double w = xf1 == xf2 ? x1 - x2 : x1 + x2;
                double j = yf1 == yf2 ? y1 - y2 : y1 + y2;
                double c = Math.Sqrt(Math.Pow(Math.Sin(w / 2), 2) + Math.Cos(x1) * Math.Cos(x2) * Math.Pow(Math.Sin(j / 2), 2));
                //double d = Math.Acos(Math.Cos(x1)*Math.Cos(x2)*Math.Cos(j)+Math.Sin(x1)*Math.Sin(x2));
                double l = D * Math.Asin(c);
                //double l2 = D / 2 * d;
                Console.WriteLine(string.Format("The distance to the iceberg: {0} miles.", l.ToString("f2")));
                if (Math.Round(l, 2) < 100)
                    Console.WriteLine("DANGER!");
                //break;
            }
        }
        static double AngleToRadians(double a)
        {
            return a * Math.PI / 180;
        }
        static double convertangle(string a)
        {
            string[] b = a.Split('^');
            double d = double.Parse(b[0]);
            string[] e = b[1].Split('\'');
            double m = double.Parse(e[0]);
            double s = double.Parse(e[1].Replace("\"", ""));
            return d + m / 60 + s / 3600;
        }
    }
}
