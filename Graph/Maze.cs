using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algos
{
    public class MazePos
    {
        int i, j;

        public MazePos(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public int I() { return i; }
        public int J() { return j; }

        public void Print()
        {
            Console.WriteLine("(" + i + "," + j + ")");
        }

        public MazePos North()
        {
            return new MazePos(i - 1, j);
        }

        public MazePos South()
        {
            return new MazePos(i + 1, j);
        }

        public MazePos East()
        {
            return new MazePos(i, j + 1);
        }

        public MazePos West()
        {
            return new MazePos(i, j - 1);
        }

    }

    public class Maze
    {
        static char C = ' ', X = 'x', S = 's', E = 'e', V = '.';

        static int START_I = 1, START_J = 1;
        static int END_I = 2, END_J = 9;

        //private static char[,] maze = 
        //    {
        //        {X, X, X, X, X, X, X, X, X, X}, 
        //        {X, S, C, C, C, C, C, C, C, X},
        //        {X, C, C, C, X, C, X, X, C, E},
        //        {X, C, X, X, X, C, X, X, C, X}, 
        //        {X, C, C, C, C, X, X, X, C, X},
        //        {X, X, X, X, C, X, X, X, C, X},
        //        {X, X, X, X, C, X, C, C, C, X},
        //        {X, X, C, X, C, X, X, C, C, X}, 
        //        {X, X, C, C, C, C, C, C, C, X},  
        //        {X, X, X, X, X, X, C, X, X, X}
        //    };

        private static char[,] maze = 
        {
                {X, X, X, X, X, X, X, X, X, X}, 
                {X, S, C, C, C, C, C, C, C, X},
                {X, C, C, C, X, C, X, X, C, X},
                {X, C, X, X, X, C, X, X, C, X}, 
                {X, C, C, C, C, X, X, X, C, X},
                {X, X, X, X, C, X, X, X, C, X},
                {X, X, X, X, C, X, X, C, C, X},
                {X, X, X, X, C, X, X, C, C, X}, 
                {X, X, X, C, C, C, C, C, C, X},  
                {X, X, X, X, X, X, C, X, X, X}
            };

        public int Size()
        {
            //return maze.Length;
            return 10;
        }

        public void Print()
        {
            for (int i = 0; i < Size(); i++)
            {
                for (int j = 0; j < Size(); j++)
                {
                    Console.Write(maze[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public char Mark(int i, int j, char val)
        {
            System.Diagnostics.Debug.Assert(IsInMaze(i, j));
            char tmp = maze[i, j];
            maze[i, j] = val;
            return tmp;
        }

        public char Mark(MazePos pos, char val)
        {
            return Mark(pos.I(), pos.J(), val);
        }

        public bool IsMarked(int i, int j)
        {
            System.Diagnostics.Debug.Assert(IsInMaze(i, j));
            return maze[i, j] == V;
        }

        public bool IsMarked(MazePos pos)
        {
            return IsMarked(pos.I(), pos.J());
        }

        public bool IsClear(int i, int j)
        {
            System.Diagnostics.Debug.Assert(IsInMaze(i, j));
            return (maze[i, j] != X && maze[i, j] != V);
        }

        public bool IsClear(MazePos pos)
        {
            return IsClear(pos.I(), pos.J());
        }

        public bool IsInMaze(int i, int j)
        {
            if (i >= 0 && i < Size() && j >= 0 && j < Size())
                return true;
            return false;
        }

        public bool IsInMaze(MazePos pos)
        {
            return IsInMaze(pos.I(), pos.J());
        }

        public bool IsFinal(int i, int j)
        {
            return (i == Maze.END_I && j == Maze.END_J);
        }

        public bool IsFinal(MazePos pos)
        {
            return IsFinal(pos.I(), pos.J());
        }

        public char[,] Clone()
        {
            char[,] mazeCopy = new char[Size(), Size()];

            for (int i = 0; i < Size(); i++)
            {
                for (int j = 0; j < Size(); j++)
                {
                    mazeCopy[i, j] = maze[i, j];
                }
            }

            return mazeCopy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="savedMaze"></param>
        public void ReStore(char[,] savedMaze)
        {
            for (int i = 0; i < Size(); i++)
            {
                for (int j = 0; j < Size(); j++)
                {
                    maze[i, j] = savedMaze[i, j];
                }
            }
        }

        public void SolveStack()
        {
            char[,] savedMaze = Clone();

            Stack<MazePos> candidates = new Stack<MazePos>();
            candidates.Push(new MazePos(START_I, START_J));

            MazePos current, next;

            while (candidates.Count > 0)
            {
                //Get current position
                current = candidates.Pop();

                if (IsFinal(current)) break;

                //Mark the current position
                Mark(current, V);

                //put its neighbors in th queue
                next = current.North();
                if (IsInMaze(next) && IsClear(next)) candidates.Push(next);

                next = current.East();
                if (IsInMaze(next) && IsClear(next)) candidates.Push(next);

                next = current.West();
                if (IsInMaze(next) && IsClear(next)) candidates.Push(next);

                next = current.South();
                if (IsInMaze(next) && IsClear(next)) candidates.Push(next);
            }

            if (candidates.Count > 0)
                Console.WriteLine("You got it!");
            else
                Console.WriteLine("You are stuck in the maze!");

            Print();
            ReStore(savedMaze);
        }

        public void SolveQueue()
        {
            char[,] savedMaze = Clone();

            Queue<MazePos> candidates = new Queue<MazePos>();
            candidates.Enqueue(new MazePos(START_I, START_J));

            MazePos current, next;

            while (candidates.Count > 0)
            {
                current = candidates.Dequeue();

                if (IsFinal(current)) break;

                Mark(current, V);

                next = current.North();
                if (IsInMaze(next) && IsClear(next)) candidates.Enqueue(next);

                next = current.East();
                if (IsInMaze(next) && IsClear(next)) candidates.Enqueue(next);

                next = current.West();
                if (IsInMaze(next) && IsClear(next)) candidates.Enqueue(next);

                next = current.South();
                if (IsInMaze(next) && IsClear(next)) candidates.Enqueue(next);
            }

            if (candidates.Count > 0)
                Console.WriteLine("You got it!");
            else
                Console.WriteLine("You are stuck in the maze!");

            Print();
            ReStore(savedMaze);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SolveRecursive()
        {
            if (Solve(new MazePos(START_I, START_J))) 
	            Console.WriteLine("Got it: "); 
	        else 
                Console.WriteLine("You're stuck in the maze."); 
	        
            Print(); 
        }

        public Boolean Solve(MazePos pos)
        { 
            //Basecase
            if (!IsInMaze(pos)) return false;
            if (IsFinal(pos)) return true;
            if (!IsClear(pos)) return false;

            System.Diagnostics.Debug.Assert(IsClear(pos));
            Mark(pos, V);

            if(Solve(pos.South()))
                return true;

            if (Solve(pos.West()))
                return true;

            if (Solve(pos.North()))
                return true;

            if (Solve(pos.East()))
                return true;

            Mark(pos, C);

            return false;

        }


    }
}
