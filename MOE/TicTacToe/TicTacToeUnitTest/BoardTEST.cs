using NUnit.Framework;
using System;
using TicTacToe;

namespace TicTacToeTST
{
	[TestFixture ()]
	public class BoardTEST
	{
		[Test ()]
		public void playTurnTest ()
		{
			string errMsg;
			int boardSize = 3;
			Player player1;
			Player[][] player;
			Board boardTEST;
			//L'objet PrivateObject permet d'acceder aux methodes et attributs
			//normalement prives de l'objet clone

			player1 = new Player("Bob", "O");
			boardTEST = new Board(boardSize);

			for (int i = 1; i <= 9;i++ )
			{
				boardTEST.playTurn(i, player1);
				player = boardTEST.BoardState;
				var length = player.GetLength (0);
				errMsg = "Erreur : playTurn n'a pas fonctionné sur la cellule "+i;
				if (i % length == 0){
					Assert.IsTrue(Board.Equals(player[i/length-1][length-1],player1),errMsg);
				} 
				else {
					Assert.IsTrue(Board.Equals(player[(int)Math.Truncate((double)(i / length))][i % length - 1],player1), errMsg);
				}
			}

		}
	}
}

