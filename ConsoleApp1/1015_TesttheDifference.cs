using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class _1015_TesttheDifference
    {
        static void Main1015(string[] args)
        {
            while (true)
            {
                int num = int.Parse(Console.ReadLine());
                int[] type = new int[30] {
                     123456,124356,124365,123546,123645,126534,
                     132456,134256,134265,132546,132645,136524,
                     143256,142356,142365,143526,143625,146532,
                     153426,154326,154362,153246,153642,156234,
                     163452,164352,164325,163542,163245,162534,
          };
                int[,] fristr = new int[6, 6] {
                     {0,1,2,3,4,5 },//L
                     {1,0,2,5,4,3 },//R->L                     
                     {2,4,1,3,0,5 },//T->L
                     {3,5,2,1,4,0 },//F->L                     
                     {4,2,0,3,1,5 },//B->L                     
                     {5,3,2,0,4,1 },//O->L
                };
                int[] rtype = new int[6] {
                     0,1,3,4,5,2
                };
                List<Dice> dices = new List<Dice>();
                for (int i = 1; i <= num; i++)
                {
                    string dicestr = Console.ReadLine().Replace(" ", "");
                    int oneindex = dicestr.IndexOf("1");
                    if (oneindex != 0)
                    {
                        StringBuilder builder = new StringBuilder();
                        for (int j = 0; j < 6; j++)
                        {
                            builder.Append(dicestr[fristr[oneindex, j]]);
                        }
                        dicestr = builder.ToString();
                    }

                    dices.Add(new Dice { index = i, vaule = dicestr });
                }
                Dictionary<int, string> dic = new Dictionary<int, string>();
                for (int i = 0; i < 30; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    int keyindex = -1;
                    for (int j = dices.Count - 1; j >= 0; j--)
                    {
                        if (dices[j].vaule == type[i].ToString())
                        {
                            stringBuilder.Insert(0, dices[j].index + " ");
                            keyindex = dices[j].index;
                            dices.RemoveAt(j);
                        }
                        else
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                StringBuilder roatestr = new StringBuilder();
                                string vaule = dices[j].vaule;
                                roatestr.Append(vaule[rtype[0]]);
                                roatestr.Append(vaule[rtype[1]]);
                                roatestr.Append(vaule[rtype[2]]);
                                roatestr.Append(vaule[rtype[3]]);
                                roatestr.Append(vaule[rtype[4]]);
                                roatestr.Append(vaule[rtype[5]]);
                                dices[j].vaule = roatestr.ToString();
                                if (dices[j].vaule == type[i].ToString())
                                {
                                    stringBuilder.Insert(0, dices[j].index + " ");
                                    keyindex = dices[j].index;
                                    dices.RemoveAt(j);
                                    break;
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(stringBuilder.ToString()))
                    {
                        dic[keyindex] = stringBuilder.ToString().Trim();
                    }
                }
                dic = dic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
                Console.WriteLine(dic.Count);
                foreach (var q in dic)
                {
                    Console.WriteLine(q.Value);
                }
                break;
            }

        }
        public class Dice
        {
            public int index { get; set; }
            public string vaule { get; set; }

        }

    }
}
