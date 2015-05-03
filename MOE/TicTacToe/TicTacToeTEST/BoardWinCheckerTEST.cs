using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeTEST
{
    [TestClass]
    public class BoardWinCheckerTEST
    {

        [TestMethod]
        public void checkRowsTest()
        {
            string errMsg;
            int boardSize = 3;
            Player player1;
            Board boardTEST;
            BoardWinChecker boardWinCheckerTEST;
            //L'objet PrivateObject permet d'acceder aux methodes normalement
            //privee de l'objet clone
            PrivateObject privateObject;

            player1 = new Player("Bob", "O");

            //TEST SUR LA PREMIERE LIGNE
            boardTEST = new Board(boardSize);
            boardWinCheckerTEST = new BoardWinChecker(boardTEST);
            privateObject = new PrivateObject(boardWinCheckerTEST);
            
            boardTEST.playTurn(1, player1);
            boardTEST.playTurn(3, player1);
            //Etat de la grille
            //O   O
            //
            //
            //Premiere ligne non remplie par Joueur 1 : checkRows doit renvoyer false
            errMsg = "Erreur : victoire détectée sur la premiere ligne";
            Assert.IsFalse((bool)privateObject.Invoke("checkRows"), errMsg);

            boardTEST.playTurn(2, player1);
            //Etat de la grille
            //O O O
            //
            //
            //Premiere ligne  remplie par Joueur 1 : checkRows doit renvoyer true
            errMsg = "Erreur : victoire non détectée sur la premiere ligne";
            Assert.IsTrue((bool)privateObject.Invoke("checkRows"), errMsg);

            //TEST SUR LA DERNIERE LIGNE
            player1 = new Player("Bob", "O");
            boardTEST = new Board(boardSize);
            boardWinCheckerTEST = new BoardWinChecker(boardTEST);
            privateObject = new PrivateObject(boardWinCheckerTEST);

            boardTEST.playTurn(7, player1);
            boardTEST.playTurn(8, player1);
            //Etat de la grille
            //   
            //
            //O O  
            //Derniere ligne non remplie par Joueur 1 : checkRows doit renvoyer false
            errMsg = "Erreur : victoire détectée sur la derniere ligne";
            Assert.IsFalse((bool)privateObject.Invoke("checkRows"), errMsg);

            boardTEST.playTurn(9, player1);
            //Etat de la grille
            //O O O
            //
            //
            //Derniere ligne  remplie par Joueur 1 : checkRows doit renvoyer true
            errMsg = "Erreur : victoire non détectée sur la derniere ligne";
            Assert.IsTrue((bool)privateObject.Invoke("checkRows"), errMsg);

        }


        [TestMethod]
        public void checkLinesTest()
        {
            string errMsg;
            int boardSize = 3;
            Player player1;
            Board boardTEST;
            BoardWinChecker boardWinCheckerTEST;
            //L'objet PrivateObject permet d'acceder aux methodes normalement
            //privee de l'objet clone
            PrivateObject privateObject;

            player1 = new Player("Bob", "O");

            //TEST SUR LA PREMIERE COLONNE
            boardTEST = new Board(boardSize);
            boardWinCheckerTEST = new BoardWinChecker(boardTEST);
            privateObject = new PrivateObject(boardWinCheckerTEST);

            boardTEST.playTurn(1, player1);
            boardTEST.playTurn(4, player1);
            //Etat de la grille
            //O  
            //O
            //
            //Premiere colonne non remplie par Joueur 1 : checkLines doit renvoyer false
            errMsg = "Erreur : victoire détectée sur la premiere colonne";
            Assert.IsFalse((bool)privateObject.Invoke("checkLines"), errMsg);

            boardTEST.playTurn(7, player1);
            //Etat de la grille
            //O 
            //O
            //O
            //Premiere colonne remplie par Joueur 1 : checkLines doit renvoyer true
            errMsg = "Erreur : victoire non détectée sur la premiere colonne";
            Assert.IsTrue((bool)privateObject.Invoke("checkLines"), errMsg);

            //TEST SUR LA DERNIERE COLONNE
            boardTEST = new Board(boardSize);
            boardWinCheckerTEST = new BoardWinChecker(boardTEST);
            privateObject = new PrivateObject(boardWinCheckerTEST);

            boardTEST.playTurn(3, player1);
            boardTEST.playTurn(6, player1);
            //Etat de la grille
            //     O  
            //     O
            //
            //Derniere colonne non remplie par Joueur 1 : checkLines doit renvoyer false
            errMsg = "Erreur : victoire détectée sur la premiere colonne";
            Assert.IsFalse((bool)privateObject.Invoke("checkLines"), errMsg);

            boardTEST.playTurn(9, player1);
            //Etat de la grille
            //     O  
            //     O
            //     O
            //Derniere colonne remplie par Joueur 1 : checkLines doit renvoyer true
            errMsg = "Erreur : victoire non détectée sur la premiere colonne";
            Assert.IsTrue((bool)privateObject.Invoke("checkLines"), errMsg);

        }


        [TestMethod]
        public void checkFirstDiagonalTest()
        {
            string errMsg;
            int boardSize = 3;
            Player player1;
            Board boardTEST;
            BoardWinChecker boardWinCheckerTEST;
            //L'objet PrivateObject permet d'acceder aux methodes normalement
            //privee de l'objet clone
            PrivateObject privateObject;

            player1 = new Player("Bob", "O");

            boardTEST = new Board(boardSize);
            boardWinCheckerTEST = new BoardWinChecker(boardTEST);
            privateObject = new PrivateObject(boardWinCheckerTEST);

            boardTEST.playTurn(1, player1);
            boardTEST.playTurn(5, player1);
            //Etat de la grille
            //O  
            //  O
            //
            //Premiere diagonale non remplie par Joueur 1 : checkFirstDiagonal doit renvoyer false
            errMsg = "Erreur : victoire détectée sur la premiere diagonale";
            Assert.IsFalse((bool)privateObject.Invoke("checkFirstDiagonal"), errMsg);

            boardTEST.playTurn(9, player1);
            //Etat de la grille
            //O  
            //  O
            //    O
            //Premiere diagonale remplie par Joueur 1 : checkFirstDiagonal doit renvoyer true
            errMsg = "Erreur : victoire non détectée sur la premiere diagonale";
            Assert.IsTrue((bool)privateObject.Invoke("checkFirstDiagonal"), errMsg);

        }

        [TestMethod]
        public void checkSecondDiagonalTest()
        {
            string errMsg;
            int boardSize = 3;
            Player player1;
            Board boardTEST;
            BoardWinChecker boardWinCheckerTEST;
            //L'objet PrivateObject permet d'acceder aux methodes normalement
            //privee de l'objet clone
            PrivateObject privateObject;

            player1 = new Player("Bob", "O");

            boardTEST = new Board(boardSize);
            boardWinCheckerTEST = new BoardWinChecker(boardTEST);
            privateObject = new PrivateObject(boardWinCheckerTEST);

            boardTEST.playTurn(3, player1);
            boardTEST.playTurn(5, player1);
            //Etat de la grille
            //    O  
            //  O
            //
            //Deuxieme diagonale non remplie par Joueur 1 : checkSecondDiagonal doit renvoyer false
            errMsg = "Erreur : victoire détectée sur la deuxieme diagonale";
            Assert.IsFalse((bool)privateObject.Invoke("checkSecondDiagonal"), errMsg);

            boardTEST.playTurn(7, player1);
            //Etat de la grille
            //    O  
            //  O
            //O
            //Deuxieme diagonale remplie par Joueur 1 : checkSecondDiagonal doit renvoyer true
            errMsg = "Erreur : victoire non détectée sur la deuxieme diagonale";
            Assert.IsTrue((bool)privateObject.Invoke("checkSecondDiagonal"), errMsg);

        }


        [TestMethod]
        public void haveWinnerTest()
        {
            string errMsg;
            int boardSize = 3;
            Player player1;
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
            //(on ne remplie pas la dernière cellule de la ligne)
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
            //(on ne remplie pas la dernière cellule de la colonne)
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
        }//haveWinnerTest()





        [TestMethod]
        public void IsTiedTest()
        {
            string errMsg;
            int boardSize = 3;
            Player player1;
            Player player2;
            Board boardTEST;
            BoardWinChecker boardWinCheckerTEST;

            player1 = new Player("Bob", "O");
            player2 = new Player("Bill", "X");
            boardTEST = new Board(boardSize);
            boardWinCheckerTEST = new BoardWinChecker(boardTEST);
            boardTEST.playTurn(1, player1);
            boardTEST.playTurn(2, player2);
            boardTEST.playTurn(3, player1);
            boardTEST.playTurn(5, player2);
            boardTEST.playTurn(4, player1);
            boardTEST.playTurn(7, player2);
            boardTEST.playTurn(6, player1);
            boardTEST.playTurn(9, player2);
            //Etat de la grille
            //O X O
            //O X O
            //X   X

            //Grille non remplie : IsTied() doit renvoyer false
            errMsg = "Erreur : égalité détectée";
            Assert.IsFalse(boardWinCheckerTEST.IsTied(), errMsg);

            boardTEST.playTurn(8, player1);
            //Etat de la grille
            //O X O
            //O X O
            //X O X

            //Grille remplie : IsTied() doit renvoyer true
            errMsg = "Erreur : égalité non détectée";
            Assert.IsTrue(boardWinCheckerTEST.IsTied(),errMsg);
        }

        


    }
}

