using System;

namespace TicTacToe
{
	public class BoardFactory : IBoardFactory
	{
		public BoardFactory ()
		{
		}

		#region IBoardFactory implementation

		public Board Create ()
		{
			return new Board ();
		}

		#endregion
	}
}

