using System;

namespace TicTacToe
{
	public class PlayerFactory : IPlayerFactory
	{
		public PlayerFactory ()
		{
		}

		#region IPlayerFactory implementation

		public Player Create (string name, string symbol)
		{
			return new Player (name, symbol);
		}

		#endregion
	}
}

