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

		public static bool Equals(Player p1,Player p2)
		{
			if (p1== null && p2 == null) {
				return true;
			} else if ((p1 == null && p2 != null) || (p1 != null && p2 == null)) {
				return false;
			} else {
				bool name = p1.Name == p2.Name;
				bool symbol = p1.Symbol == p2.Symbol;
				bool number_win = p1.NumberWin == p2.NumberWin;
				return (name && symbol && number_win);
			}
		}

		public static bool Equals(Player[][] p1,Player[][] p2)
		{
			bool result;
			int dim1 = p1.GetLength (0);
			int dim2 = p2.GetLength (0);
			//Si p1 et p2 n'ont pas la meme taille, on renvoie false
			if (dim1 != dim2) {
				return false;
			}

			for (int i = 0; i < dim1; i++) {
				for (int j = 0; j < dim2; j++) {
					result = Player.Equals (p1 [i] [j], p2 [i] [j]);
					if (!result) {
						return false;
					}
				}
			}
			return true;
		}	
	}
}