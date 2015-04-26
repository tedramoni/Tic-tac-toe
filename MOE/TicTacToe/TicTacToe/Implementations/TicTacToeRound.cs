using System;

namespace TicTacToe
{
	public class TicTacToeRound : ITicTacToeRound
	{
		private Round _round;
		private Game _game;

		private IDisplayer _displayer;
		private IReader _reader;
		private IBoardWinChecker _checker;
		private IBoardFormatter _formatter;
		private IGameRepository _game_repository;

		public TicTacToeRound (IReader reader, IDisplayer displayer, IBoardFormatter formatter, Game game, IGameRepository game_repository)
		{
			_reader = reader;
			_displayer = displayer;
			_game = game;
			_round = _game.Current;
			_checker = new BoardWinChecker (_round.Board);
			_formatter = formatter;
			_game_repository = game_repository;
		}

		public void Start ()
		{
			_round.Current = _game.Player1;

			if (!_checker.HaveWinner () && !_checker.IsTied ()) {
				do {
					_displayer.Clear ();
					_displayer.Show (GetMenu (), ConsoleColor.Blue);

					_displayer.Show (_formatter.Format (_round.Board));

					string index;
					bool validMove;
					do {
						_displayer.Show ("Joueur " + _round.Current.Name + " a vous de choisir une case :");
						index = _reader.Read ();
						validMove = _round.Board.playTurn (Convert.ToInt32 (index), _round.Current);
						if (validMove == false) {
							_displayer.Show ("Case " + index + " déjà utilisée");

						}
					} while(validMove != true);

					_round.Current = (_round.Current == _game.Player1) ? _game.Player2 : _game.Player1;

					_game_repository.Save (_game);

				} while(!_checker.HaveWinner () && !_checker.IsTied ());
			}

			if (_checker.IsTied ()) {
				_displayer.Show ("Match nul !", ConsoleColor.Yellow);
			} else {
				_checker.Winner.NumberWin++;
				_displayer.Show ("Le gagnant du round est : " + _checker.Winner.Name, ConsoleColor.Green);
			}

			_displayer.Show (_formatter.Format (_round.Board));
			_displayer.Show ("Appuyer sur une touche pour continuer...");
			_reader.Read ();
		}

		private string GetMenu ()
		{
			var s = "======================================================================\n " +
			        "Round " + (Array.IndexOf (_game.Rounds, _game.Current) + 1) + " / " + _game.Rounds.Length;
			s += "\n======================================================================\n";
			s += "Menu : NONE\t\t\t\n";
			s += "Scores : " + _game.Player1.Name + " : " + _game.Player1.NumberWin + "\n";
			s += "\t " + _game.Player2.Name + " : " + _game.Player2.NumberWin + "\n";
			s += "======================================================================\n";
			return s;
		}
	}
}