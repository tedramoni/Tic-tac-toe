using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            //******************************************
            //              TEMPORARY TEST
            //******************************************
            BoardState board = new BoardState();
            BoardDisplay displayer = new BoardDisplay();
            WinChecker checker = new WinChecker();

            board.generateBoard(3);
            Console.WriteLine(displayer.display(board));
            bool stop = false;
            string[] user = new string[] { "X", "O" };
            string currentUser;
            int turn = 0;
            string index;
            while (stop == false)
            {
                turn++;
                currentUser = user[turn % 2];
                Console.WriteLine("Joueur " + currentUser + " entrez un numéro de case");
                index = Console.ReadLine();

                if (index != "")
                {
                    board.updateBoard(Convert.ToInt32(index), currentUser);
                    checker.haveWinner(board);
                }
                else
                {
                    stop = true;
                }
                Console.WriteLine(displayer.display(board));

            }
            Console.ReadLine();

        }
    }
}
