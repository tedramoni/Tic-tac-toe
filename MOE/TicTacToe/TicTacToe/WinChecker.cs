using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class WinChecker
    {
        String winner = null;
        public Boolean haveWinner(BoardState paramBoard)
        {
            var board = paramBoard.getBoard();
            var length = board.GetLength(0);

            var isLineWinner = this.checkLines(board, length);
            var isRowWinner = this.checkRows(board, length);
            var isDiagonalWinner = this.checkDiagonal(board, length);

            if (isLineWinner || isRowWinner || isDiagonalWinner)
            {
                return true;
            }

            return false;
        }



        public string getWinner()
        {
            return this.winner;
        }


        protected bool checkLines(string[,] board, int length)
        {
            string prevValue;
            var winner = false;

            for (int line = 0; line < length; line++)
            {

                prevValue = board[line, 0];
                for (int row = 0; row < length; row++)
                {

                    if (board[line, row] == prevValue)
                    {
                        winner = true;
                    }
                    else
                    {
                        winner = false;
                        break;
                    }
                }
                if (winner == true)
                {
                    this.winner = prevValue;
                    return true;
                }

            }
            return false;
        }
        protected bool checkRows(string[,] board, int length)
        {
            for (int row = 0; row < length; row++)
            {

                var winner = false;
                var prevValue = board[0, row];

                for (int line = 0; line < length; line++)
                {
                    if (board[line, row] == prevValue)
                    {
                        winner = true;
                    }
                    else
                    {
                        winner = false;
                        break;
                    }
                }
                if (winner == true)
                {
                    this.winner = prevValue;
                    return true;
                }

            }
            return false;
        }
        protected bool checkDiagonal(string[,] board, int length)
        {
            return (this.checkFirstDiagonal(board, length) || this.checkSecondDiagonal(board, length));
        }

        protected bool checkFirstDiagonal(string[,] board, int length)
        {
            var winner = false;
            var row = 0;
            var line = 0;

            var prevValue = board[0, 0];
            for (int cell = 1; cell < length; cell++)
            {
                row++;
                line++;
                if (board[row, line] == prevValue)
                {
                    winner = true;
                }
                else
                {
                    winner = false;
                    break;
                }
            }

            if (winner == true)
            {
                this.winner = prevValue;
            }

            return winner;
        }

        protected bool checkSecondDiagonal(string[,] board, int length)
        {
            var winner = false;
            var row = length - 1;
            var line = 0;

            var prevValue = board[row, line];
            for (int cell = 1; cell < length; cell++)
            {
                row--;
                line++;

                if (board[row, line] == prevValue)
                {
                    winner = true;
                }
                else
                {
                    winner = false;
                    break;
                }
            }
            if (winner == true)
            {
                this.winner = prevValue;
            }

            return winner;
        }
    }
}
