namespace TicTacToe
{
	public class GameRepository : IGameRepository
	{
		public bool Save (Game game)
		{
			return false;
		}

		public Game Load ()
		{
			return null;
		}
	}
}