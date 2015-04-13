using System;

namespace TicTacToe
{
	public interface IDisplayer
	{
		void Show (string s,
		          ConsoleColor color = ConsoleColor.White,
		          bool mustAddCarriageReturn = true);

		void Clear ();
	}
}