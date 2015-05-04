using System.IO;
using System.Runtime.Serialization;
using System;
using System.Xml;

namespace TicTacToe
{
	public class GameRepositoryXML : IGameRepository
	{
		public bool Save (Game game)
		{
			
			StreamWriter wr = new StreamWriter ("game.xml");
				
			var serializer = new DataContractSerializer(game.GetType(), null, 
				0x7FFF /*maxItemsInObjectGraph*/, 
				false /*ignoreExtensionDataObject*/, 
				true /*preserveObjectReferences : this is where the magic happens */, 
				null /*dataContractSurrogate*/);
			serializer.WriteObject(wr.BaseStream, game);

			wr.Close ();

			return true;
		}

		public Game Load ()
		{
			Game g = null;

			var serializer = new DataContractSerializer(typeof(Game), null, 
				0x7FFF /*maxItemsInObjectGraph*/, 
				false /*ignoreExtensionDataObject*/, 
				true /*preserveObjectReferences : this is where the magic happens */, 
				null /*dataContractSurrogate*/);

			if (File.Exists (@"game.xml")) {
				using (XmlReader rd = XmlReader.Create ("game.xml")) {

					g = serializer.ReadObject (rd) as Game;
				}

				return g;
			} else
				return null;
		}

		public void Delete ()
		{
			if(File.Exists(@"game.xml"))
			{
				File.Delete(@"game.xml");
			}
		}
	}
}