using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class BoardState
    {
        private string[,] board;

        public void generateBoard(int size = 3)
        {
            this.board = new string[size, size];
            int cellNumber = 0;
            for (int line = 0; line < size; line++)
            {
                for (int row = 0; row < size; row++)
                {

                    cellNumber = cellNumber + 1;
                    this.board[line, row] = cellNumber.ToString();

                }
            }
        }

        public void updateBoard(int index, string value)
        {
            var length = this.getBoard().GetLength(0);
            if (index % length == 0)
            {
                this.getBoard()[index / length - 1, length - 1] = value;
            }
            else
            {
                this.getBoard()[(int)Math.Truncate((double)(index / length)), index % length - 1] = value;

            }
        }

        public string[,] getBoard()
        {
            return this.board;
        }

    }
}
