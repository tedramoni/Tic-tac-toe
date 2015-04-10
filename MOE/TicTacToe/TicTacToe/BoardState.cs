using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class BoardState
    {
        private string[] board;
        public void generateBoard(int size = 3){
            this.board = new string[size*size];
            int cellNumber = 0;
            for (int line = 1; line <= size; line++)
            {
                for (int row = 1; row <= size; row++)
                {
                    cellNumber = cellNumber + 1;
                    this.board[cellNumber-1] = cellNumber.ToString();

                }
            }
        }

        public void updateBoard(int index, string value)
        {
            this.board[index-1] = value;
        }

        public string[] getBoard()
        {
            return this.board;
        }



    }
}
