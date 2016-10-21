using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//https://bob-carpenter.github.io/games/sudoku/java_sudoku.html
namespace Algos
{
    public class Soduko
    {
        public static bool Solve(int i, int j, int[][] cells)
        {
            if(i == 9)
            {
                i = 0;
                if (++j == 9)
                    return true;
            }

            if (cells[i][j] != 0)    //skip filled cells
                return Solve(i + 1, j, cells);

            for (int val = 1; val <= 9; ++val)
            {
                if (IsLegal(i, j, val, cells))
                {
                    cells[i][j] = val;
                    if (Solve(i + 1, j, cells))
                        return true;
                }
            }

            cells[i][j] = 0; //reset on backtrack
            return false;
        }
        public static bool IsLegal(int i, int j, int val, int[][] cells)
        {
            for (int k = 0; k < 9; ++k) //row
            {
                if (val == cells[k][j])
                    return false;
            }

            for (int k = 0; k < 9; ++k) //col
            {
                if (val == cells[i][k])
                    return false;
            }

            int boxRowOffset = (i / 3) * 3;
            int boxColOffset = (j / 3) * 3;

            for (int k = 0; k < 3; ++k) //box
                for (int m = 0; m < 3; ++m)
                    if (val == cells[boxRowOffset + k][boxColOffset + m])
                        return false;

            return true; //no violations, so it's legal
        }

        public static int[][] ParseProblem(string[] args)
        {
            int[][] problem = new int[9][]; //default to 0;
            for(int i = 0; i < 9; i++)
            {
                problem[i] = new int[9];
            }

            for (int n = 0; n < args.Length; ++n)
            {
                int i = Int32.Parse(args[n].Substring(0, 1));
                int j = Int32.Parse(args[n].Substring(1, 1));
                int val = Int32.Parse(args[n].Substring(2,1));
                problem[i][j] = val;
            }

            return problem;
        }

        public static void WiteMatrix(int[][] solution)
        {
            for (int i = 0; i < 9; ++i)
            {
                if (i % 3 == 0)
                    Console.WriteLine(" -----------------------");
                for (int j = 0; j < 9; ++j)
                {
                    if (j % 3 == 0) Console.Write("| ");
                    Console.Write(solution[i][j] == 0
                                     ? " "
                                     : solution[i][j].ToString());

                    Console.Write(' ');
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(" -----------------------");
        }


        public static void MainSoduko(string[] args)
        {
            args = new string[] { "014", "023", "037", "069", "088",
            "125", "143", "211", "263", "306", "342", "357", "404", "427", "461", "483",
            "535", "544", "589", "622", "673", "745", "764", "805", "824", "851", "862", "876" };

            int[][] matrix = ParseProblem(args);

            WiteMatrix(matrix);

            if (Solve(0, 0, matrix))  //Solve in place
                WiteMatrix(matrix);
            else
                Console.Write("None");

            Console.Read();
        }
    }

}
