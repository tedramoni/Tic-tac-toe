namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
			IReader reader = new Reader ();
			IDisplayer displayer = new Displayer ();
			IBoardFormatter formatter = new BoardFormatter ();

			ITicTacToeRunner runner = new TicTacToeRunner (reader, displayer, formatter);
			runner.Run ();
        }
    }
}
