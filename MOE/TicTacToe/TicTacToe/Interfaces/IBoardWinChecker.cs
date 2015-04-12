using System;

namespace TicTacToe
{
	public interface IBoardWinChecker
	{
		Boolean HaveWinner();
		Boolean IsTied();
		Player Winner { get; }
	}
}

