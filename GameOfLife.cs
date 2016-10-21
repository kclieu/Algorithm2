using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //http://www.programcreek.com/2014/05/leetcode-game-of-life-java/
    public class GameOfLife
    {
        public void GetGameOfLife(int[][] board)
        {
            int m = board.Length;
            int n = board[0].Length;

            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1};
            int[] dy = { 1, 0,  -1, 1, -1, 1, 0, -1 };

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int count = 0;

                    for (int k = 0; k < 8; k++)
                    {
                        int x = i + dx[k];
                        int y = j + dy[k];

                        count += GetNeighbor(board, x, y);

                        //Any live cell with fewer than two live neighbors dies
                        if (count < 2 && board[i][j] == 1)
                            board[i][j] &= 1;

                        //Any dead cell with exactly three live neighbors becomes a live cell
                        if (count == 3 && board[i][j] == 0)
                            board[i][j] |= 2;

                        // any live cells with 2 or 3 neigbors lives on to the next generation 
                        if (count >= 2 && count <= 3 && board[i][j] == 1)
                        {
                            board[i][j] |= 2;
                        }
                        //Any live cell with more than three live neighbors dies
                        if (count > 3 && board[i][j] == 1)
                        {
                            board[i][j] &= 1; // this line can be ignored, since next state is 0 by default
                        }
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i][j] >>= 1;
                }
            }

        }
        public int GetNeighbor(int[][] board, int x, int y)
        {
            int m = board.Length;
            int n = board[0].Length;

            if (x < 0 || x >= m || y < 0 || y > n)
                return 0;

            return board[x][y] & 1;
        }

        public static void MainGameOfLife(string[] args)
        { }
    }
}
