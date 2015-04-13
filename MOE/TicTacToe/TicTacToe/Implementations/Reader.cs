using System;

namespace TicTacToe
{
	public class Reader : IReader
	{
		public virtual string Read ()
		{
			var buffer = Console.ReadLine ();
			if (buffer == "")
				return null;
			return buffer;
		}
	}
}