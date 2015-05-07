using System;
using System.Runtime.Serialization;

namespace TicTacToe
{
	[DataContract]
	public class Game
	{
		private Player _player1, _player2;
		private Round[] _rounds;
		private Round _current;

		[DataMember(Order = 0)]
		public Player Player1 { get { return _player1; } set { _player1 = value; } }

		[DataMember(Order = 1)]
		public Player Player2 { get { return _player2; } set { _player2 = value; } }

		[DataMember(Order = 2)]
		public Round[] Rounds { get { return _rounds; } set { _rounds = value; } }

		[DataMember(Order = 3)]
		public Round Current { get { return _current; } set { _current = value; } }

		public Game (int numberRound)
		{
			_rounds = new Round[numberRound];
		}

		public static bool Equals(Game g1, Game g2)
		{
			bool player1 = Player.Equals (g1.Player1, g2.Player1);
			bool player2 = Player.Equals (g1.Player2, g2.Player2);
			bool rounds = Round.Equals (g1.Rounds, g2.Rounds);
			bool current = Round.Equals (g1.Current, g2.Current);
			return (player1 && player2 && rounds && current);
		}
	}
}