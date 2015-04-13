namespace TicTacToe
{
	class Program
	{
		static void Main (string[] args)
		{
			IReader reader = new Reader ();
			IDisplayer displayer = new Displayer ();
			IBoardFormatter formatter = new BoardFormatter ();
			IBoardFactory board_factory = new BoardFactory ();
			IPlayerFactory player_factory = new PlayerFactory ();
			IRoundFactory round_factory = new RoundFactory (board_factory);
			IGameFactory game_factory = new GameFactory ();

			ITicTacToeRunner runner = new TicTacToeRunner (reader, displayer, formatter, player_factory, round_factory, game_factory);
			runner.Run ();
		}
	}
}