using System;

namespace TicTacToe
{
	public class TicTacToeRound : ITicTacToeRound
	{
		private Round _round;
		private IDisplayer _displayer;
		private IReader _reader;
		private ITicTacToeGame _game;
		private IBoardWinChecker _checker;
		private IBoardFormatter _formatter;

		public Round Round { get { return _round; } }

		public TicTacToeRound (IReader reader, IDisplayer displayer, ITicTacToeGame game, IBoardFormatter formatter, IRoundFactory round_factory)
		{
			_round = round_factory.Create();
			_reader = reader;
			_displayer = displayer;
			_game = game;
			_checker = new BoardWinChecker(_round.Board);
			_formatter = formatter;
		}

		public void Start ()
		{
			Player currentUser = _game.Player2;

			do {
				_displayer.Show (_game.GetMenu (this), ConsoleColor.Blue);

				currentUser = (currentUser == _game.Player1) ? _game.Player2 : _game.Player1;

				_displayer.Show (_formatter.Format (_round.Board));
				string index;
				bool validMove;
				do {
					_displayer.Show ("Joueur " + currentUser.Name + " a vous de choisir une case :");
					 index = _reader.Read ();
					 validMove = _round.Board.playTurn (Convert.ToInt32 (index), currentUser);
					if(validMove == false){
						_displayer.Show ("Case " + index + " déjà utilisée");

					}
				} while(validMove != true);
				_displayer.Clear ();

			} while(!_checker.HaveWinner () && !_checker.IsTied ());

			if (_checker.IsTied ()) {
				_displayer.Show ("Match nul !", ConsoleColor.Yellow);
			} else {
				_checker.Winner.NumberWin++;
				_displayer.Show ("Le gagnant du round est : " + _checker.Winner.Name, ConsoleColor.Green);
			}
			_displayer.Show (_formatter.Format (_round.Board));
		}
	}
}

