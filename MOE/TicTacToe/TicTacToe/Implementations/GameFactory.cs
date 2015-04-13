namespace TicTacToe
{
	public class GameFactory : IGameFactory
	{
		public Game Create (int numberRound)
		{
			return new Game (numberRound);
		}
	}
}