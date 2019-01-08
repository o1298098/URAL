using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1027_D___Again
    {
        static void Main1027(string[] args)
        {
            while (true)
            {
                string txt = "";
                string read = Console.ReadLine();
                string a = "=+-*/0123456789)(";
                while (!string.IsNullOrWhiteSpace(read) || string.IsNullOrWhiteSpace(txt))
                {
                    txt += read;
                    read = Console.ReadLine();
                }
                int r = 0;
                int l = 0;
                int rs = 0;
                int ls = 0;
                int c = 0;
                int d = 0;
                char ps = new char();
                bool flags = true;
                foreach (var q in txt)
                {
                    if (ps == 40 && q == 42 && flags)
                    {
                        ls++;
                        l--;
                        c--;
                        flags = false;
                        ps = new char();
                        continue;
                    }
                    else if (ps == 42 && q == 41 && !flags)
                    {
                        flags = true;
                        rs++;
                    }
                    else if (q == 40 && flags)
                    {
                        l++;
                        c++;
                    }
                    else if (q == 41 && flags && c != 0)
                    {
                        r++;
                        c--;
                    }
                    else if (q == 41 && flags && c == 0)
                    {
                        d++;
                    }
                    else if (a.IndexOf(q) < 0 && flags && c != 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    ps = q;
                }
                if (l == r && rs == ls && d == 0)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
                //break;
            }
        }
    }
}
