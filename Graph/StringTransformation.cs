using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://community.topcoder.com/tc?module=Static&d1=tutorials&d2=graphsDataStrucs2
    //http://apps.topcoder.com/forums/?module=Thread&threadID=699619&start=0&mc=5#1667411 (Similar problem)
    //DFS use Stack
    //BFS use Queue
    //Java don't have a Queue class, so use LinkedList class

    public static class StringTransformation
    {
        public static string RandString(int len)
        {
            Random r = new Random();
            StringBuilder ret = new StringBuilder(len);

            while (len-- > 0)
            {
                ret.Append((char)(r.Next(26) + 'a'));
            }

            return ret.ToString();
        }


        public static int TransformString(HashSet<string> D, string s, string t)
        {
            Queue<Pair<string, int>> q = new Queue<Pair<string, int>>();
            D.Remove(s);  //Mark as as visited by erasing it in D;
            q.Enqueue(new Pair<string, int>(s, 0));

            while (q.Count > 0)
            {
                Pair<string, int> f = q.Peek();

                //Returns if we find a matcch
                if (f.GetFirst().Equals(t))
                    return f.GetSecond(); //Number of steps to reach t

                //Tries all possible transformation of f.first
                string str = f.GetFirst();

                for (int i = 0; i < str.Length; i++)
                {
                    string start = i == 0 ? string.Empty : str.Substring(0, i);
                    string end = i + 1 < str.Length ? str.Substring(i + 1) : string.Empty;

                    //Iterates through 'a' => 'z'

                    for (int j = 0; j < 26; ++j)
                    {
                        string modStr = start + (char)('a' + j) + end;

                        if (D.Remove(modStr))
                        {
                            q.Enqueue(new Pair<string, int>(modStr, f.GetSecond() + 1));
                        }
                    }
                }

                q.Dequeue();
            }

            //Cannot find a possible transformation
            return -1;
        }
    }
}
