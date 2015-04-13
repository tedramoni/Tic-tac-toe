using System;

namespace TicTacToe
{
	public class TicTacToeRunner : ITicTacToeRunner
	{
		private ITicTacToeGame _game;
		private IReader _reader;
		private IDisplayer _displayer;
		private IGameRepository _game_repository;

		private Game _game_model;

		private static int NUMBER_ROUND = 5;

		public TicTacToeRunner (IReader reader, IDisplayer displayer, IBoardFormatter formatter, IPlayerFactory player_factory, IRoundFactory round_factory, IGameFactory game_factory, IGameRepository game_repository)
		{
			_reader = reader;
			_displayer = displayer;
			_game_repository = game_repository;

			//_game_model = game_factory.Create (NUMBER_ROUND);
			_game_model = _game_repository.Load();
			_game = new TicTacToeGame (_reader, _displayer, formatter, player_factory, round_factory, _game_model);
		}

		public void Run ()
		{
			_game.Start ();
			_game_repository.Save (_game_model);
		}
	}
}