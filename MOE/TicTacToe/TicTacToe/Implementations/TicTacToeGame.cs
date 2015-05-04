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
		private IGameRepository _game_repository;

		static string[] choices = new string[]{ "X", "O" };

		public TicTacToeGame (IReader reader, IDisplayer displayer, IBoardFormatter formatter, IPlayerFactory player_factory, IRoundFactory round_factory, Game game, IGameRepository game_repository)
		{
			_game = game;
			_reader = reader;
			_displayer = displayer;
			_formatter = formatter;
			_player_factory = player_factory;
			_round_factory = round_factory;
			_game_repository = game_repository;
		}

		public int Start ()
		{
			if (_game.Player1 == null || _game.Player2 == null)
				_Create_Players ();
			
			_displayer.Clear ();

			//Lancement de la partie

			int t = 0;
			if (_game.Current != null)
				t = Array.IndexOf (_game.Rounds, _game.Current);

			//Si on est en mode mort subite on ne passe pas par là
			if (t != -1) {
				for (int i = t; i < _game.Rounds.Length; i++) {
					//Si un des joueurs est dans une position ou le deuxième ne pourra remonter le score étant 
					//donné qu'il lui faudrait plus de tour qu'il n'y en a (ex : 3 - 0, comme il n'y a que 5 tours, 
					// le joueur 2 ne pourras dépasser le joueur1, le joueur1 a donc gagné même si le nombre de tour n'a pas été effectué)
					if (_game.Player1.NumberWin > (_game.Rounds.Length / 2) || _game.Player2.NumberWin > (_game.Rounds.Length / 2))
						break;

					if (_game.Rounds [i] == null) {
						_game.Rounds [i] = _round_factory.Create ();
						_game.Current = _game.Rounds [i];
					}
					_game_repository.Save(_game);

					_displayer.Clear ();

					var round = new TicTacToeRound (_reader, _displayer, _formatter, _game, _game_repository);
					var returnCode = round.Start ();

					if (returnCode > 0) {
						return returnCode;
					}
				}

				//On créer le round pour la mort subite (dans le cas ou il y en aurait besoin)
				_game.Current = _round_factory.Create ();
				_game_repository.Save(_game);
			}

			//Lancement du mode "mort subite" si match nul
			while (_game.Player1.NumberWin == _game.Player2.NumberWin) {

				_displayer.Clear ();

				var round = new TicTacToeRound (_reader, _displayer, _formatter, _game, _game_repository);
				var returnCode = round.Start ();

				if (returnCode > 0) {
					return returnCode;
				}

				//Si match nul on recréer un round et on fait ça jusqu'au moment ou les joueurs seront départagés
				if (_game.Player1.NumberWin == _game.Player2.NumberWin) {
					_game.Current = _round_factory.Create ();
					_game_repository.Save(_game);
				}
			}

			_displayer.Show ("Fin de partie : ", ConsoleColor.Cyan, false);
			if (_game.Player1.NumberWin > _game.Player2.NumberWin)
				_displayer.Show ("Le joueur " + _game.Player1.Name + " a gagné la partie.");
			else if (_game.Player2.NumberWin > _game.Player1.NumberWin)
				_displayer.Show ("Le joueur " + _game.Player2.Name + " a gagné la partie.");
			else
				_displayer.Show ("Match nul !");
			
			String userChoice = "";
			do {
				_displayer.Show ("Voulez vous recommencer une partie ? [O/N]");
				userChoice = _reader.Read ();

				if (userChoice != null && userChoice.ToLower () == "o") {
					return 2;
				} else if (userChoice != null && userChoice.ToLower () == "n") {
					return 0;
				}
			} while(userChoice == null || userChoice.ToLower () != "o" | userChoice.ToLower () != "n");

			return 0;
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
				symbol = _reader.Read ();
				if (symbol != null) {
					symbol = symbol.ToUpper ();
				}
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