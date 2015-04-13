using System;

namespace TicTacToe
{
	public class GameFactory : IGameFactory
	{

		#region IRoundFactory implementation

		public Game Create (int numberRound)
		{
			return new Game(numberRound);
		}

		#endregion
	}
}

