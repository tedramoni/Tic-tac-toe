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

		public int Start ()
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
						int n;
						if (IsCommand (index) > 0) {
							return IsCommand (index);
						} else if (int.TryParse (index, out n) == false || Convert.ToInt32 (index) > _game.Current.Board.getNbCells () | Convert.ToInt32 (index) < 1) {
							validMove = false;
							_displayer.Show ("La saisie " + index + " ne correspond pas à une case");
						} else {
								

							validMove = _round.Board.playTurn (Convert.ToInt32 (index), _round.Current);
							if (validMove == false) {
								_displayer.Show ("Case " + index + " déjà utilisée");
							}
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

			return 0;
		}

		private int IsCommand (string read)
		{
			if (read == "/quit")
				return 1;
			if (read == "/retry")
				return 2;

			return 0;
		}

		private string GetMenu ()
		{
			var roundNumber = (Array.IndexOf (_game.Rounds, _game.Current) == -1) ? _game.Rounds.Length : Array.IndexOf (_game.Rounds, _game.Current) + 1;

			var s = "======================================================================\n " +
			        "Round " + roundNumber + " / " + _game.Rounds.Length + "\n";
				
			if (Array.IndexOf (_game.Rounds, _game.Current) == -1)
				s += "MORT SUBITE ! \n";

			s += "\n======================================================================\n";
			s += "Menu : \t\t\t\n\t/retry : lancer une nouvelle partie \n";
			s += "\t/quit : quitter le jeu (partie sauvegardée) \n\n";
			s += "Scores : " + _game.Player1.Name + " : " + _game.Player1.NumberWin + "\n";
			s += "\t " + _game.Player2.Name + " : " + _game.Player2.NumberWin + "\n";
			s += "======================================================================\n";
			return s;
		}
	}
}