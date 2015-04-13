using System;

namespace TicTacToe
{
	public class TicTacToeRunner : ITicTacToeRunner
	{
		private ITicTacToeGame _game;
		private IReader _reader;
		private IDisplayer _displayer;

		public TicTacToeRunner (IReader reader, IDisplayer displayer, IBoardFormatter formatter, IPlayerFactory player_factory, IRoundFactory round_factory, IGameFactory game_factory)
		{
			_reader = reader;
			_displayer = displayer;

			_game = new TicTacToeGame (_reader, _displayer, formatter, player_factory, round_factory, game_factory);
		}

		public void Run ()
		{
			_game.Start ();
		}
	}
}

