namespace TicTacToe
{
	public interface IGameFactory
	{
		Game Create (int numberRound);
	}
}