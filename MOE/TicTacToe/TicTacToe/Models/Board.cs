using System;
using System.Runtime.Serialization;

namespace TicTacToe
{
	[DataContract]
	public class Board
	{
		private Player[][] _board_state;

		[DataMember]
		public Player[][] BoardState { get { return _board_state; } set { _board_state = value; } }


		public Board (int size = 3)
		{
			_board_state = new Player[size][];
			for (int i = 0; i<size;i++) {
				_board_state[i] = new Player[size];
			}
		}


		public bool playTurn (int index, Player player)
		{
			var length = _board_state.GetLength (0);
			if (index % length == 0) {
				if (_board_state [index / length - 1][length - 1] == null) {
					_board_state [index / length - 1][length - 1] = player;
					return true;
				} else {
					return false;
				}

			} else {

				if (_board_state [(int)Math.Truncate ((double)(index / length))][index % length - 1] == null) {
					_board_state [(int)Math.Truncate ((double)(index / length))][index % length - 1] = player;
					return true;
				} else {
					return false;
				}

			}
		}

		public double getNbCells ()
		{
			return Math.Pow (_board_state.Length, 2);
		}

		public static bool Equals(Board b1,Board b2)
		{
			bool boardstate = Player.Equals (b1.BoardState, b2.BoardState);
			return boardstate;
		}
	}
}