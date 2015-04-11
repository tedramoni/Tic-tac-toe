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
            var length = paramBoard.getBoard().GetLength(0);
            var current = 0;
            for (int row = 0; row < length; row++)
            {
                for (int line = 0; line < length; line++)
                {
                    board += " " + paramBoard.getBoard()[row, line];
                    current++;
                }
                board += "\n";
            }

            return board;
        }

    }
}
