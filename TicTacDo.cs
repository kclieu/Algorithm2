using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public class TicTacDo
    {
        private char[,] Board;
        int BoardDim = 3;

        public TicTacDo()
        {
            this.Board = new char[BoardDim, BoardDim];
            ClearBoard();
            
        }

        public TicTacDo(char[,] board)
        {
            this.Board = new char[BoardDim, BoardDim]; 
            this.Board = board;
            ClearBoard();
        }

        public void Move(char c, int x, int y)
        {
            Board[x, y] = c;
        }

        public void Print()
        {
            for (int i = 0; i < BoardDim; i++)
            {
                for (int j = 0; j < BoardDim; j++)
                {
                    Console.Write(Board[i, j] + "      |");

                }

                Console.WriteLine();
            }
        }

        public bool HasWinner()
        {
            return HasRowWinner()|| HasColumnWinner()||HasDiagonalWinner();
        
        }

        private bool HasRowWinner()
        {
            bool hasRowWinner = false;

            for (int i = 0; i < BoardDim; i++)
            {
                for (int j = 0; j < BoardDim; j++)
                {
                    if ((Board[i, 0] == Board[i, 1]) && (Board[i, 0] == Board[i, 2]) && Board[i, 0] != ' ' && Board[i, 1] != ' ' && Board[i, 2] != ' ')
                        hasRowWinner = true;
                }
            }

            return hasRowWinner;
        }

        private bool HasColumnWinner()
        {
            bool hasColumnWinner = false;

            for (int j = 0; j < BoardDim; j++)
            {
                for (int i = 0; i < BoardDim; i++)
                {
                    if ((Board[0, j] == Board[1, j]) && (Board[0, j] == Board[2, j]) && Board[0,j] != ' ' && Board[1,j] != ' ' && Board[1,j] != ' ')
                        hasColumnWinner = true;
                
                }
            }

            return hasColumnWinner;
        }

        private bool HasDiagonalWinner()
        {
            bool hasDiagonalWinner1 = false;
            bool hasDiagonalWinner2 = false;

          
            if ((Board[0, 0] == Board[1, 1]) && (Board[0, 0] == Board[2, 2] && Board[0,0] != ' ' && Board[1,1] != ' ' && Board[2,2] != ' '))
                hasDiagonalWinner1 = true;

            if ((Board[2, 0] == Board[1, 1]) && (Board[2, 0] == Board[0, 2]) && Board[2, 0] != ' ' && Board[1, 1] != ' ' && Board[0, 2] != ' ')
                hasDiagonalWinner2 = true;

            return hasDiagonalWinner1 || hasDiagonalWinner2;
        
        }


        private void ClearBoard()
        {
            for (int i = 0; i < BoardDim; i++)
            {
                for (int j = 0; j < BoardDim; j++)
                {
                    Board[i, j] = ' ';
                }
            }
        }
    }
}
