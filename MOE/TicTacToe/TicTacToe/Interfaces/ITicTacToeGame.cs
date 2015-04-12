﻿using System;

namespace TicTacToe
{
	public interface ITicTacToeGame
	{
		void Start();
		ITicTacToeRound[] Rounds { get; }
		Player Player1 { get; }
		Player Player2 { get; }
	}
}
