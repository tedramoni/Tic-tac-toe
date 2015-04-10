using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class WinChecker
    {
        String user;
        public Boolean haveWinner(BoardState paramBoard)
        {
            var board = paramBoard.getBoard();
            var length = paramBoard.getBoard().GetLength(0);
            var row = Math.Sqrt(length);
            bool winner = false;


            //Checking lines
            string prevValue;
            for (int line = 1; line <= row; line++)
            {
                prevValue = board[(int)(line * row - row)];
                for (int cell = 1; cell <= row; cell++)
                {

                    if (board[(int)(line * row - row) + cell - 1] == prevValue)
                    {
                        prevValue = board[(int)(line * row - row) + cell - 1];
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
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Winner ! " + prevValue);
                    Console.ResetColor();
                    break;
                }
            }

            return true;
        }


        public string getWinner()
        {
            return this.user;
        }
    }
}
