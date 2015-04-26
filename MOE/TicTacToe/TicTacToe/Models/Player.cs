namespace TicTacToe
{
	public class Player
	{
		private string _name, _symbol;
		private int _number_win;

		public string Name { get { return _name; } set { _name = value; } }

		public string Symbol { get { return _symbol; } set { _symbol = value; } }

		public int NumberWin { get { return _number_win; } set { _number_win = value; } }

		public Player (string name, string symbol)
		{
			_name = name;
			_symbol = symbol;
			_number_win = 0;
		}
	}
}