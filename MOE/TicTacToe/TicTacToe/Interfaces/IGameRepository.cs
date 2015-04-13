namespace TicTacToe
{
	public interface IGameRepository
	{
		bool Save (Game game);

		Game Load ();
	}
}