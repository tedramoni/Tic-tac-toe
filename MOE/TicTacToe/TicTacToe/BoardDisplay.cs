using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class BoardDisplay
    {

        public string display(BoardState paramBoard)
        {
            String board = "";
            var length = paramBoard.board.GetLength(0);
            var row = Math.Sqrt(length);
            var current = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    board += " " +paramBoard.board[current];
                    current++;
                }
                board += "\n";
            }

            return board;
        }

    }
}
