using Autofac;

namespace TicTacToe
{
	class Program
	{
		static void Main (string[] args)
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<Reader>().As<IReader>();
			builder.RegisterType<Displayer>().As<IDisplayer>();
			builder.RegisterType<BoardFormatter>().As<IBoardFormatter>();
			builder.RegisterType<BoardFactory>().As<IBoardFactory>();
			builder.RegisterType<PlayerFactory>().As<IPlayerFactory>();
			builder.RegisterType<RoundFactory>().As<IRoundFactory>();
			builder.RegisterType<GameFactory>().As<IGameFactory>();
			builder.RegisterType<GameRepositoryJSON>().As<IGameRepository>();
			builder.RegisterType<TicTacToeRunner>().As<ITicTacToeRunner>();

			var container = builder.Build();

			var e = container.Resolve<ITicTacToeRunner>();
			e.Run ();
		}
	}
}