using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Boardgame
	{
		public int Game_id { get; set; }
		public string Game_Title { get; set; }
		public string Description { get; set; }
		public int MinAge { get; set; }
		public int MaxAge { get; set; }
		public int MinPlayers { get; set; }
		public int MaxPlayers { get; set; }
		public int? Duration { get; set; }
		public Guid Registerer { get; set; }

		public string Registerer_Name { get; set; }

		public Boardgame(int game_id, string game_Title, string description, int minAge, int maxAge, int minPlayers, int maxPlayers, int? duration, Guid registerer)
		{
			Game_id = game_id;
			Game_Title = game_Title;
			Description = description;
			MinAge = minAge;
			MaxAge = maxAge;
			MinPlayers = minPlayers;
			MaxPlayers = maxPlayers;
			Duration = duration;
			Registerer = registerer;
		}

		public Boardgame(int game_id, string game_Title, string description, int minAge, int maxAge, int minPlayers, int maxPlayers, int? duration, Guid registerer, string registerer_Name): this(game_id,game_Title,description,minAge,maxAge,minPlayers,maxPlayers,duration,registerer)
		{
			Registerer_Name = registerer_Name;
		}

	}
}
