using System;
using System.Runtime.Serialization;

namespace TicTacToe
{
	[DataContract]
	public class Game
	{
		private Player _player1, _player2;
		private Round[] _rounds;
		private int _current;

		[DataMember(Order = 0)]
		public Player Player1 { get { return _player1; } set { _player1 = value; } }

		[DataMember(Order = 1)]
		public Player Player2 { get { return _player2; } set { _player2 = value; } }

		[DataMember(Order = 2)]
		public Round[] Rounds { get { return _rounds; } set { _rounds = value; } }

		[DataMember(Order = 3)]
		public Round Current { get { return _rounds[_current]; } set { _current = Array.IndexOf(_rounds, value); } }

		public Game (int numberRound)
		{
			_rounds = new Round[numberRound];
		}
	}
}