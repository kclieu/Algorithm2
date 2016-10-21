using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    class ProgramMaze
    {
        static void Main1(string[] args)
        {
            Maze m = new Maze();
            Console.WriteLine("Begin");
            m.Print();

            //Console.WriteLine("Solve using Stack");
            //m.SolveStack();
           // Console.WriteLine("Solve using Q");
            //m.SolveQueue();
            Console.WriteLine("Solve using Recursive.");
            m.SolveRecursive();

            Console.Read();
        }
    }
}
