using System;

namespace TicTacToe
{
	public class Player
	{
		private string _name, _symbol;

		public string Name { get { return _name; } }
		public string Symbol { get { return _symbol; } }

		public Player (string name, string symbol)
		{
			_name = name;
			_symbol = symbol;
		}
	}
}

