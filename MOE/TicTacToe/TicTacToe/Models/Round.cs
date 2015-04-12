using System;

namespace TicTacToe
{
	public class Round
	{
		private Board _board;
		public Board Board { get { return _board; } }

		public Round ()
		{
			_board = new Board ();
		}
	}
}

