using System;

namespace TicTacToe
{
	public interface IPlayerFactory
	{
		Player Create(string name, string symbol);
	}
}

