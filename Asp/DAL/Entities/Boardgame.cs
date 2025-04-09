using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Boardgame
	{
		public int Game_id { get; set; }
		public string Game_Title { get; set; }
		public string Description { get; set; }
		public int MinAge {  get; set; }
		public int MaxAge { get; set; }
		public int MinPlayers { get; set; }
		public int MaxPlayers { get; set; }
		public int? Duration { get; set; }
		public Guid Registerer {  get; set; }
	}
}
