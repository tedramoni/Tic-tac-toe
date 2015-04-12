using System;

namespace TicTacToe
{
	public class RoundFactory : IRoundFactory
	{
		private IBoardFactory _board_factory;

		public RoundFactory (IBoardFactory board_factory)
		{
			_board_factory = board_factory;
		}

		#region IRoundFactory implementation

		public Round Create ()
		{
			return new Round (_board_factory.Create());
		}

		#endregion
	}
}

