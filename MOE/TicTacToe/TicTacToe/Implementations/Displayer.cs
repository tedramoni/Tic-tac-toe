using System;

namespace TicTacToe
{
	public class Displayer : IDisplayer
	{
		public virtual void Show(string s, ConsoleColor color = ConsoleColor.White, bool mustAddCarriageReturn = true)
		{
			if(color != null)
				Console.ForegroundColor = color;

			if (mustAddCarriageReturn)
				Console.WriteLine(s);
			else
				Console.Write(s);

			Console.ResetColor ();
		}
		public virtual void Clear()
		{
			Console.Clear();
		}
	}
}

