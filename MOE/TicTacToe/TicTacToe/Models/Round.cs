using System.Runtime.Serialization;

namespace TicTacToe
{
	[DataContract]
	public class Round
	{
		private Board _board;
		private Player _current;

		[DataMember]
		public Board Board { get { return _board; } set { _board = value; } }

		[DataMember]
		public Player Current { get { return _current; } set { _current = value; } }

		public Round (Board board)
		{
			_board = board;
		}

		public static bool Equals(Round r1,Round r2)
		{
			if (r1 == null && r2 == null) {
				return true;
			} else if ((r1 == null && r2 != null) || (r1 != null && r2 == null)) {
				return false;
			} else {
				bool board = Board.Equals (r1.Board, r2.Board);
				bool current = Player.Equals (r1.Current, r2.Current);
				return (board && current);
			}
		}

		public static bool Equals(Round[] r1,Round[] r2)
		{
			bool result;
			int dim1 = r1.GetLength (0);
			int dim2 = r2.GetLength (0);
			//Si p1 et p2 n'ont pas la meme taille, on renvoie false
			if (dim1 != dim2) {
				return false;
			}
			for (int i = 0; i < dim1; i++) {
				result = Round.Equals (r1 [i], r2 [i]);
				if (!result) {
					return false;
				}

			}
			return true;
		}	
	}
}