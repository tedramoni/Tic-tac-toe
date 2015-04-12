using System;

namespace TicTacToe
{
	public class TicTacToeRunner : ITicTacToeRunner
	{
		private ITicTacToeGame _game;
		private IReader _reader;
		private IDisplayer _displayer;

		public ITicTacToeGame Game { get { return _game; } }

		public TicTacToeRunner (IReader reader, IDisplayer displayer, IBoardFormatter formatter, IPlayerFactory player_factory, IRoundFactory round_factory)
		{
			_reader = reader;
			_displayer = displayer;

			_game = new TicTacToeGame (_reader, _displayer, formatter, player_factory, round_factory);
		}

		public void Run ()
		{
			_game.Start ();
		}
	}
}

