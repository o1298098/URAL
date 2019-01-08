using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1007_CodeWords
    {
        static void Main1007(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();
            while (true)
            {
                string read = Console.ReadLine();
                while (!string.IsNullOrWhiteSpace(read))
                {
                    words.Add(read);
                    read = Console.ReadLine();
                }
                while (words.Count != 0)
                {

                    string word = words[0].Trim();
                    words.RemoveAt(0);
                    int nw = N - word.Length;
                    int count = 0;
                    Dictionary<int, int> dicword = new Dictionary<int, int>();
                    Dictionary<int, int> dicsum = new Dictionary<int, int>();
                    List<int> add = new List<int>();
                    foreach (var q in word)
                    {
                        string symbols = q.ToString();
                        count++;
                        if (symbols == "1")
                        {
                            add.Add(count);
                            dicword[count] = 1;
                            dicsum[count] = count;

                        }
                        else
                        {
                            dicword[count] = 0;
                            dicsum[count] = 0;
                        }


                    }
                    for (int i = word.Length - 1; i >= 1; i--)
                    {
                        dicword[i] += dicword[i + 1];
                    }
                    int total = add.Sum();
                    int p = total / (N + 1);
                    int remainder = total % (N + 1);
                    if (nw == 0)
                    {
                        if (remainder != 0)
                        {
                            if (dicsum.ContainsValue(remainder))
                            {
                                string ws = word.Substring(0, remainder - 1);
                                string we = word.Substring(remainder);
                                word = ws + "0" + we;
                                Console.WriteLine(word);
                            }
                        }
                        else
                            Console.WriteLine(word);
                    }
                    else if (nw < 0)
                    {
                        int keycount = N + 1;
                        while (keycount != 0)
                        {
                            string s = word.Substring(keycount - 1, 1);
                            if ((s == "1" && (total - dicword[keycount] - keycount + 1) % (N + 1) == 0) || (s == "0" && (total - dicword[keycount]) % (N + 1) == 0))
                                break;
                            keycount--;
                        }
                        string ws = word.Substring(0, keycount - 1);
                        string we = word.Substring(keycount);
                        word = ws + we;
                        Console.WriteLine(word);
                    }
                    else
                    {
                        if (remainder == 0)
                        {
                            word = word + "0";
                            Console.WriteLine(word);
                        }
                        else if ((total + N) % (N + 1) == 0)
                        {
                            word = word + "1";
                            Console.WriteLine(word);
                        }
                        else
                        {
                            int keycount = N - 1;
                            int sy = 0;
                            while (keycount != 0)
                            {

                                if ((total + dicword[keycount]) % (N + 1) == 0)
                                    break;
                                else if ((total + dicword[keycount] + keycount) % (N + 1) == 0)
                                {
                                    sy = 1;
                                    break;
                                }

                                keycount--;
                            }
                            string ws = word.Substring(0, keycount - 1);
                            string we = word.Substring(keycount - 1);
                            word = ws + sy + we;
                            Console.WriteLine(word);
                        }
                    }

                }
                //break;
            }
        }


    }
}
