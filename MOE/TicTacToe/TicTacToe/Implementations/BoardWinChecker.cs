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
			var length = _board.BoardState.GetLength (0);

			var isLineWinner = this.checkLines ();
			var isRowWinner = this.checkRows ();
			var isDiagonalWinner = this.checkDiagonal ();

			if (isLineWinner || isRowWinner || isDiagonalWinner) {
				return true;
			}

			return false;
		}

		public Boolean IsTied ()
		{
			var length = _board.BoardState.GetLength (0);
			for (int line = 0; line < length; line++) {
				for (int row = 0; row < length; row++) {
					if (_board.BoardState [row, line] == null)
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
				prevValue = board [0, line];
				for (int row = 0; row < length; row++) {

					if (board [row, line] == prevValue && prevValue != null) {
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

		protected bool checkRows ()
		{
			var length = _board.BoardState.GetLength (0);
			var board = _board.BoardState;

			for (int row = 0; row < length; row++) {

				var winner = false;
				var prevValue = board [row, 0];

				for (int line = 0; line < length; line++) {
					if (board [row, line] == prevValue && prevValue != null) {
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
			var row = 0;
			var line = 0;

			var prevValue = board [0, 0];
			for (int cell = 1; cell < length; cell++) {
				row++;
				line++;
				if (board [row, line] == prevValue && prevValue != null) {
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
			var row = length - 1;
			var line = 0;

			var prevValue = board [row, line];
			for (int cell = 1; cell < length; cell++) {
				row--;
				line++;

				if (board [row, line] == prevValue && prevValue != null) {
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