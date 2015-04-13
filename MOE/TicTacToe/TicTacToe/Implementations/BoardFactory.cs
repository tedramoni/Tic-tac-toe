namespace TicTacToe
{
	public class BoardFactory : IBoardFactory
	{
		public Board Create ()
		{
			return new Board ();
		}
	}
}