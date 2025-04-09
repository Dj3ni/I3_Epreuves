using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Boardgame
{
	public class BoardgameDetails
	{
		[ScaffoldColumn(false)]
		public int Game_id { get; set; }

		[DisplayName("Title: ")]
		public string Game_Title { get; set; }

		[DisplayName("Description")]
		public string Description { get; set; }

		[DisplayName("Start playing : ")]
		public int MinAge { get; set; }
		[DisplayName("You'r too old to play this: ")]
		public int MaxAge { get; set; }
		[DisplayName("Minimum friends around the table: ")]
		public int MinPlayers { get; set; }
		[DisplayName("Maximum players: ")]
		public int MaxPlayers { get; set; }
		[DisplayName("Fun part duration, without rules explanation: ")]
		public int? Duration { get; set; }

		[DisplayName("Who we need to thank for these precious informations: ")]
		public string Registerer_Name { get; set; }

		[ScaffoldColumn(false)]
		public Guid Registerer { get; set; }
	}
}
