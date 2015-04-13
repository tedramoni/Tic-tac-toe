﻿using System;

namespace TicTacToe
{
	public class Game
	{
		private Player _player1, _player2;
		private Round[] _rounds;
		private int _current;

		public Player Player1 { get { return _player1; } set { _player1 = value; } }

		public Player Player2 { get { return _player2; } set { _player2 = value; } }

		public Round[] Rounds { get { return _rounds; } }

		public Round Current { get { return _rounds[_current]; } set { _current = Array.IndexOf(_rounds, value); } }

		public Game (int numberRound)
		{
			_rounds = new Round[numberRound];
		}
	}
}