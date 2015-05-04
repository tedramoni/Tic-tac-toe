using System.IO;
using System.Runtime.Serialization;
using System;
using Newtonsoft.Json;

namespace TicTacToe
{
	public class GameRepositoryJSON : IGameRepository
	{
		public bool Save (Game game)
		{
			string json = JsonConvert.SerializeObject(game, Newtonsoft.Json.Formatting.Indented,
				new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

			using (StreamWriter outfile = new StreamWriter(@"game.json"))
			{
				outfile.Write(json);
			}

			return true;
		}

		public Game Load ()
		{
			Game g = null;

			if (File.Exists (@"game.json")) {
				string json = File.ReadAllText(@"game.json");
				g = JsonConvert.DeserializeObject<Game>(json,
					new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

				return g;
			} else
				return null;
		}

		public void Delete ()
		{
			if(File.Exists(@"game.json"))
			{
				File.Delete(@"game.json");
			}
		}
	}
}