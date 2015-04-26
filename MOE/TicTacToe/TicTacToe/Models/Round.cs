using System.Runtime.Serialization;

namespace TicTacToe
{
	public class Round
	{
		private Board _board;
		private Player _current;

		public Board Board { get { return _board; } set { _board = value; } }


		public Player Current { get { return _current; } set { _current = value; } }

		public Round (Board board)
		{
			_board = board;
		}
	}
}