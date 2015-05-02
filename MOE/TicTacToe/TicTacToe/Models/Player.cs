using System.Runtime.Serialization;

namespace TicTacToe
{
	[DataContract]
	public class Player
	{
		private string _name, _symbol;
		private int _number_win;

		[DataMember]
		public string Name { get { return _name; } set { _name = value; } }

		[DataMember]
		public string Symbol { get { return _symbol; } set { _symbol = value; } }

		[DataMember]
		public int NumberWin { get { return _number_win; } set { _number_win = value; } }

		public Player (string name, string symbol)
		{
			_name = name;
			_symbol = symbol;
			_number_win = 0;
		}
	}
}