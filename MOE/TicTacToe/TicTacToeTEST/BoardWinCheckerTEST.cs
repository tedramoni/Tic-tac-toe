using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeTEST
{
    [TestClass]
    public class BoardWinCheckerTEST
    {
        [TestMethod]
        public void haveWinnerTest()
        {
            string errMsg;
            int boardSize = 3;
            Player player1;
            //Player player2 = new Player("Bill", "X");
            Board boardTEST;
            BoardWinChecker boardWinCheckerTEST; 

            //on teste la victoire sur chaque ligne
            for(int j = 0;j<boardSize-1;j++)
            { 
                player1 = new Player("Bob", "O");
                boardTEST = new Board(boardSize);
                boardWinCheckerTEST = new BoardWinChecker(boardTEST);
                for (int i = 1; i <= boardSize; i++)
                {   
                    boardTEST.playTurn(boardSize*j + i , player1);
                }
                errMsg = "Erreur : victoire non detecté pour la ligne " + (j + 1);
                Assert.IsTrue(boardWinCheckerTEST.HaveWinner(), errMsg);
            }

            //on teste la victoire sur chaque colonne
            for (int j = 1; j <= boardSize - 1; j++)
            {
                player1 = new Player("Bob", "O");
                boardTEST = new Board(boardSize);
                boardWinCheckerTEST = new BoardWinChecker(boardTEST);
                for (int i = 0; i < boardSize; i++)
                {
                    boardTEST.playTurn(boardSize * i + j, player1);
                }
                errMsg = "Erreur : victoire non detecté pour la colonne " + j;
                Assert.IsTrue(boardWinCheckerTEST.HaveWinner(), errMsg);
            }

            //on teste la non victoire sur chaque ligne
            for (int j = 0; j < boardSize - 1; j++)
            {
                player1 = new Player("Bob", "O");
                boardTEST = new Board(boardSize);
                boardWinCheckerTEST = new BoardWinChecker(boardTEST);
                for (int i = 1; i <= boardSize-1; i++)
                {
                    boardTEST.playTurn(boardSize * j + i, player1);
                }
                errMsg = "Erreur : victoire detecté pour la ligne " + (j + 1);
                Assert.IsFalse(boardWinCheckerTEST.HaveWinner(), errMsg);
            }

            //on teste la non victoire sur chaque colonne
            for (int j = 1; j <= boardSize - 1; j++)
            {
                player1 = new Player("Bob", "O");
                boardTEST = new Board(boardSize);
                boardWinCheckerTEST = new BoardWinChecker(boardTEST);
                for (int i = 0; i < boardSize-1; i++)
                {
                    boardTEST.playTurn(boardSize * i + j, player1);
                }
                errMsg = "Erreur : victoire detecté pour la colonne " + j;
                Assert.IsFalse(boardWinCheckerTEST.HaveWinner(), errMsg);
            }
        }
    }
}

