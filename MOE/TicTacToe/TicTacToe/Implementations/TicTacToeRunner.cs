using System;

namespace TicTacToe
{
	public class TicTacToeRunner : ITicTacToeRunner
	{
		private ITicTacToeGame _game;
		private IReader _reader;
		private IDisplayer _displayer;

		private static int NUMBER_ROUND = 5;

		public TicTacToeRunner (IReader reader, IDisplayer displayer, IBoardFormatter formatter, IPlayerFactory player_factory, IRoundFactory round_factory, IGameFactory game_factory)
		{
			Game game = game_factory.Create (NUMBER_ROUND);

			_reader = reader;
			_displayer = displayer;

			_game = new TicTacToeGame (_reader, _displayer, formatter, player_factory, round_factory, game);
		}

		public void Run ()
		{
			_game.Start ();
		}
	}
}

