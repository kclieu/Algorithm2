using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class Program3
    {
        static void Main3(string[] args)
        {
            Maze m = new Maze();
            Console.WriteLine("Begin");
            m.Print();

            //Console.WriteLine("Solve using Stack");
            //m.SolveStack();

            Console.WriteLine("String Transformation");

            HashSet<string> D = new HashSet<string>();
            string s = "animal";
            string t = "bnimat";
            D.Add(s);
            D.Add(t);

            Random r = new Random();
            int n = r.Next(1000000) + 1;
            for (int i = 0; i < n; ++i)
            {
                D.Add(StringTransformation.RandString(6));
            }

            Console.WriteLine(D);
            Console.WriteLine(s + " " + t + " " + D.Count);
            Console.WriteLine(StringTransformation.TransformString(D, s, t));

            Console.Read();
        }
    }
}
