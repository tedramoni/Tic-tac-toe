using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeTEST
{
    [TestClass]
    public class TicTacToeTESTS
    {
        [TestMethod]
        public void TestGenerateBoard()
        {
            int tailleGrille = 3;
            int cell = 0;

            BoardState testBoardState = new BoardState();
            testBoardState.generateBoard(tailleGrille);
            string[,] boardTest = testBoardState.getBoard();

            //On test que la dimension 0 de la grille contient le bon nombre d'éléments
            Assert.AreEqual(tailleGrille, boardTest.GetLength(0), "Le nombre d'elements dans la dimension 0 grille est de " + boardTest.GetLength(0) + " au lieu de " + tailleGrille);

            //On test que la dimension 1 de la grille contient le bon nombre d'éléments
            Assert.AreEqual(tailleGrille, boardTest.GetLength(1), "Le nombre d'elements dans la dimension 1 grille est de " + boardTest.GetLength(1) + " au lieu de " + tailleGrille);

            for (int line = 0; line < tailleGrille; line++)
            {
                for (int row = 0; row < tailleGrille; row++)
                {
                    cell++;
                    Assert.AreEqual(boardTest[line, row], cell.ToString(), "L'élément [" + line + "," + row + "] vaut " + boardTest[line, row] + " au lieu de la valeur attendue " + cell.ToString());
                }
            }
        }
    }
}

