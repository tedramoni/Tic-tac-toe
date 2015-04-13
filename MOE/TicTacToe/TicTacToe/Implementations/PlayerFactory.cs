namespace TicTacToe
{
	public class PlayerFactory : IPlayerFactory
	{
		public Player Create (string name, string symbol)
		{
			return new Player (name, symbol);
		}
	}
}