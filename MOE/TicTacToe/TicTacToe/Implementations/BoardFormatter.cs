using System;

namespace TicTacToe
{
	public class BoardFormatter : IBoardFormatter
	{
		public string Format (Board board)
		{
			String format = "+++++++++++++\n";
			var length = board.BoardState.GetLength (0);

			for (int row = 0; row < length; row++) {
				for (int line = 0; line < length; line++) {
					Player p = board.BoardState [row, line];

					if (p != null)
						format += "+ " + p.Symbol + " ";
					else
						format += "+ " + ((row * length) + line + 1) + " ";
				}
				format += "+\n+++++++++++++\n";
			}

			return format;
		}
	}
}