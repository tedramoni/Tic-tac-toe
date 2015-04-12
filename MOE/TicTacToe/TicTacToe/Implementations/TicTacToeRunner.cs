using System;

namespace TicTacToe
{
	public class TicTacToeRunner : ITicTacToeRunner
	{
		private ITicTacToeGame _game;
		private IReader _reader;
		private IDisplayer _displayer;
		private IBoardFormatter _formatter;

		public ITicTacToeGame Game { get { return _game; } }

		public TicTacToeRunner (IReader reader, IDisplayer displayer, IBoardFormatter formatter)
		{
			_reader = reader;
			_displayer = displayer;
			_formatter = formatter;

			_game = new TicTacToeGame (_reader, _displayer, _formatter);
		}

		public void Run ()
		{
			_game.Start ();
		}
	}
}

