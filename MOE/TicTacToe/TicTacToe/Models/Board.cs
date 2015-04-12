using System;

namespace TicTacToe
{
	public class Board
	{
		private Player[,] _board_state;
		public Player[,] BoardState { get { return _board_state; } }

		public Board (int size = 3)
		{
			_board_state = new Player[size, size];
		}

		public void playTurn(int index, Player player)
		{
			var length = _board_state.GetLength(0);
			if (index % length == 0)
			{
				_board_state[index / length - 1, length - 1] = player;
			}
			else
			{
				_board_state[(int)Math.Truncate((double)(index / length)), index % length - 1] = player;
			}
		}
	}
}

