using System;

namespace TicTacToe
{
	public class TicTacToeRunner : ITicTacToeRunner
	{
		private ITicTacToeGame _game;
		private IReader _reader;
		private IDisplayer _displayer;
		private IGameRepository _game_repository;
		private IGameFactory _game_factory;
		private IRoundFactory _round_factory;
		private IPlayerFactory _player_factory;
		private IBoardFormatter _formatter;

		private Game _game_model;

		private static int NUMBER_ROUND = 5;

		public TicTacToeRunner (IReader reader, IDisplayer displayer, IBoardFormatter formatter, IPlayerFactory player_factory, IRoundFactory round_factory, IGameFactory game_factory, IGameRepository game_repository)
		{
			_reader = reader;
			_displayer = displayer;
			_game_repository = game_repository;
			_game_factory = game_factory;
			_formatter = formatter;
			_round_factory = round_factory;
			_player_factory = player_factory;

			//on charge la partie dans le repo
			_game_model = _game_repository.Load();

			if(_game_model == null)
				_game_model = game_factory.Create (NUMBER_ROUND);
			
			_game = new TicTacToeGame (_reader, _displayer, formatter, player_factory, round_factory, _game_model, _game_repository);
		}

		public void Run ()
		{
			var returnCode = 2;

			while (returnCode == 2) {
				returnCode = _game.Start ();

				//Code : on quite
				if (returnCode == 0) {
					_game_repository.Delete ();
				}

				//[1] Code : on quitte en sauvegardant

				//Code : lancement d'une nouvelle partie
				if (returnCode == 2) {
					_displayer.Clear ();
					_displayer.Show ("Lancement d'une nouvelle partie !");
					_game_repository.Delete ();
					_game_model = _game_factory.Create (NUMBER_ROUND);
					_game = new TicTacToeGame (_reader, _displayer, _formatter, _player_factory, _round_factory, _game_model, _game_repository);
				}
			}
		}
	}
}