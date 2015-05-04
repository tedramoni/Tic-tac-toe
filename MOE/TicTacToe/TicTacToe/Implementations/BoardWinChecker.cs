using System;

namespace TicTacToe
{
	public class BoardWinChecker : IBoardWinChecker
	{
		private Board _board;
		private Player _winner = null;

		public Player Winner { get { return _winner; } }

		public BoardWinChecker (Board board)
		{
			_board = board;
		}

		public Boolean HaveWinner ()
		{
			var isLineWinner = this.checkLines ();
			var isColumnWinner = this.checkColumns ();
			var isDiagonalWinner = this.checkDiagonal ();

			if (isLineWinner || isColumnWinner || isDiagonalWinner) {
				return true;
			}

			return false;
		}

		public Boolean IsTied ()
		{
			var length = _board.BoardState.GetLength (0);
			for (int line = 0; line < length; line++) {
				for (int column = 0; column < length; column++) {
					if (_board.BoardState [column][line] == null)
						return false;
				}
			}


			return true;
		}

		protected bool checkLines ()
		{
			var length = _board.BoardState.GetLength (0);
			var board = _board.BoardState;

			Player prevValue;
			var winner = false;

			for (int line = 0; line < length; line++) {
				prevValue = board [0][line];
				for (int column = 0; column < length; column++) {

					if (board [column][line] == prevValue && prevValue != null) {
						winner = true;
					} else {
						winner = false;
						break;
					}
				}
				if (winner == true) {
					_winner = prevValue;
					return true;
				}

			}
			return false;
		}

		protected bool checkColumns ()
		{
			var length = _board.BoardState.GetLength (0);
			var board = _board.BoardState;

			for (int column = 0; column < length; column++) {

				var winner = false;
				var prevValue = board [column][0];

				for (int line = 0; line < length; line++) {
					if (board [column][line] == prevValue && prevValue != null) {
						winner = true;
					} else {
						winner = false;
						break;
					}
				}
				if (winner == true) {
					_winner = prevValue;
					return true;
				}

			}
			return false;
		}

		protected bool checkDiagonal ()
		{
			return (this.checkFirstDiagonal () || this.checkSecondDiagonal ());
		}

		protected bool checkFirstDiagonal ()
		{
			var length = _board.BoardState.GetLength (0);
			var board = _board.BoardState;

			var winner = false;
			var column = 0;
			var line = 0;

			var prevValue = board [0][0];
			for (int cell = 1; cell < length; cell++) {
				column++;
				line++;
				if (board [column][line] == prevValue && prevValue != null) {
					winner = true;
				} else {
					winner = false;
					break;
				}
			}

			if (winner == true) {
				_winner = prevValue;
			}

			return winner;
		}

		protected bool checkSecondDiagonal ()
		{
			var length = _board.BoardState.GetLength (0);
			var board = _board.BoardState;

			var winner = false;
			var column = length - 1;
			var line = 0;

			var prevValue = board [column][line];
			for (int cell = 1; cell < length; cell++) {
				column--;
				line++;

				if (board [column][line] == prevValue && prevValue != null) {
					winner = true;
				} else {
					winner = false;
					break;
				}
			}
			if (winner == true) {
				_winner = prevValue;
			}

			return winner;
		}
	}
}