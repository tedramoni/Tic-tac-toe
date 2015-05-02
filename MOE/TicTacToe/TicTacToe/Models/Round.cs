using System.Runtime.Serialization;

namespace TicTacToe
{
	[DataContract]
	public class Round
	{
		private Board _board;
		private Player _current;

		[DataMember]
		public Board Board { get { return _board; } set { _board = value; } }

		[DataMember]
		public Player Current { get { return _current; } set { _current = value; } }

		public Round (Board board)
		{
			_board = board;
		}
	}
}