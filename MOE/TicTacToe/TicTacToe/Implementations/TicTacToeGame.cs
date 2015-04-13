using System;

namespace TicTacToe
{
	public class TicTacToeGame : ITicTacToeGame
	{
		private Game _game;

		private IReader _reader;
		private IDisplayer _displayer;
		private IBoardFormatter _formatter;
		private IPlayerFactory _player_factory;
		private IRoundFactory _round_factory;

		static string[] choices = new string[]{ "X", "O" };

		public TicTacToeGame (IReader reader, IDisplayer displayer, IBoardFormatter formatter, IPlayerFactory player_factory, IRoundFactory round_factory, Game game)
		{
			_game = game;
			_reader = reader;
			_displayer = displayer;
			_formatter = formatter;
			_player_factory = player_factory;
			_round_factory = round_factory;
		}

		public void Start ()
		{
			if (_game.Player1 == null || _game.Player2 == null)
				_Create_Players ();
			
			_displayer.Clear ();

			//Lancement de la partie

			int t = 0;
			if (_game.Current != null)
				t = Array.IndexOf (_game.Rounds, _game.Current);

			for (int i = t; i < _game.Rounds.Length; i++) {

				if (_game.Rounds [i] == null) {
					_game.Rounds [i] = _round_factory.Create ();
					_game.Current = _game.Rounds [i];
				}
				
				_displayer.Clear ();

				//For testing purpose
				var round = new TicTacToeRound (_reader, _displayer, _formatter, _game);
				round.Start ();
			}

			_displayer.Show ("Fin de partie : ", ConsoleColor.Cyan, false);
			if (_game.Player1.NumberWin > _game.Player2.NumberWin)
				_displayer.Show ("Le joueur " + _game.Player1.Name + " a gagné la partie.");
			else if (_game.Player2.NumberWin > _game.Player1.NumberWin)
				_displayer.Show ("Le joueur " + _game.Player2.Name + " a gagné la partie.");
			else
				_displayer.Show ("Match nul !");
		}

		private void _Create_Players ()
		{
			string name;
			string symbol;

			//Création des players
			_displayer.Show ("Prénom du joueur 1 : ");
			name = _reader.Read ();

			do {
				_displayer.Show ("Symbole du joueur 1 : ");
				symbol = _reader.Read ().ToUpper();
			} while(Array.IndexOf (choices, symbol) == -1);

			_game.Player1 = _player_factory.Create (name, symbol);

			_displayer.Show ("Prénom du joueur 2 : ");
			name = _reader.Read ();

			if (_game.Player1.Symbol == choices [0]) {
				symbol = choices [1];
			} else {
				symbol = choices [0];
			}
			_displayer.Show (name + " votre symbol est: "+ symbol);

			_displayer.Show ("\nAppuyez sur une touche pour continuer", ConsoleColor.Yellow);
			_reader.Read ();
			_game.Player2 = _player_factory.Create (name, symbol);
		}
	}
}