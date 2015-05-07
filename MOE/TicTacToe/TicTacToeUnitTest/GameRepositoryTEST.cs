using NUnit.Framework;
using System;
using TicTacToe;

namespace TicTacToeTST
{
	[TestFixture ()]
	public class GameRepositoryXMLTEST
	{
		[Test ()]
		public void SaveLoadTest ()
		{
			string errMsg;
			bool equal,exists;
			int boardSize = 3;
			int numberRound = 5;
			Player player1;
			Player player2;
			Board boardTEST;
			BoardWinChecker boardWinCheckerTEST;
			Game gameTest = new Game (numberRound);
			Game gameLoad = new Game (numberRound);
			GameRepositoryXML gameRepositoryTestXML = new GameRepositoryXML ();
			GameRepositoryJSON gameRepositoryTestJSON = new GameRepositoryJSON ();

			//On simule une partie en cours
			player1 = new Player("Bob", "O");
			player2 = new Player("Bill", "X");
			player1.NumberWin = 0;
			player2.NumberWin = 0;
			boardTEST = new Board(boardSize);
			boardWinCheckerTEST = new BoardWinChecker(boardTEST);
			gameTest.Rounds[0] = new Round(boardTEST);
			boardTEST.playTurn(1, gameTest.Player1);
			boardTEST.playTurn(2, gameTest.Player2);
			boardTEST.playTurn(3, gameTest.Player1);
			boardTEST.playTurn(5, gameTest.Player2);
			boardTEST.playTurn(4, gameTest.Player1);
			//Etat de la grille
			//O X O
			//O X
			gameTest.Current = gameTest.Rounds[0];
			gameTest.Player1 = player1;
			gameTest.Player2 = player2;


			//Test Save-Load en XML
			gameRepositoryTestXML.Save (gameTest);
			gameLoad = gameRepositoryTestXML.Load ();

			errMsg = "Erreur : le chargement de la partie a renvoye null (XML)";
			exists = gameLoad != null;
			Assert.IsTrue (exists, errMsg);

			errMsg = "Erreur : la partie chargee est differente de la partie en cours lors de la sauvegarde (XML)";
			equal = Game.Equals(gameTest,gameLoad);
			Assert.IsTrue(equal, errMsg);

			//Test Save-Load JSON
			gameRepositoryTestJSON.Save (gameTest);
			gameLoad = gameRepositoryTestJSON.Load ();

			errMsg = "Erreur : le chargement de la partie a renvoye null (JSON)";
			exists = gameLoad != null;
			Assert.IsTrue (exists, errMsg);

			errMsg = "Erreur : la partie chargee est differente de la partie en cours lors de la sauvegarde (JSON)";
			equal = Game.Equals(gameTest,gameLoad);
			Assert.IsTrue(equal, errMsg);


		}
	}
}

