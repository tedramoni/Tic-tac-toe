using System;

namespace TicTacToe
{
	public class TicTacToeGame : ITicTacToeGame
	{
		private ITicTacToeRound[] _rounds;
		private Player _player1, _player2;

		private IReader _reader;
		private IDisplayer _displayer;
		private IBoardFormatter _formatter;
		private IPlayerFactory _player_factory;
		private IRoundFactory _round_factory;

		static string[] choices = new string[]{ "X", "O" };

		public ITicTacToeRound[] Rounds { get { return _rounds; } }
		public Player Player1 { get { return _player1; } }
		public Player Player2 { get { return _player2; } }

		public TicTacToeGame (IReader reader, IDisplayer displayer, IBoardFormatter formatter, IPlayerFactory player_factory, IRoundFactory round_factory, int numberRound = 1)
		{
			_rounds = new ITicTacToeRound[numberRound];
			_reader = reader;
			_displayer = displayer;
			_formatter = formatter;
			_player_factory = player_factory;
			_round_factory = round_factory;
		}

		public void Start ()
		{
			string name;
			string symbol;

			//Création des players
			_displayer.Show("Prénom du joueur 1 : ");
			name = _reader.Read();

			do{
				_displayer.Show("Symbole du joueur 1 : ");
				symbol = _reader.Read();
			}while(Array.IndexOf(choices, symbol) == -1);

			_player1 = _player_factory.Create(name, symbol);

			_displayer.Show("Prénom du joueur 2 : ");
			name = _reader.Read();

			do{
				_displayer.Show("Symbole du joueur 2 : ");
				symbol = _reader.Read();
			}while(Array.IndexOf(choices, symbol) == -1);

			_player2 = _player_factory.Create(name, symbol);

			_displayer.Clear ();

			//Lancement de la partie
			for (int i = 0; i < _rounds.Length; i++) {
				//For testing purpose
				_rounds [i] = new TicTacToeRound(_reader, _displayer, this, _formatter, _round_factory);
				_rounds [i].Start ();
			}
		}
	}
}

