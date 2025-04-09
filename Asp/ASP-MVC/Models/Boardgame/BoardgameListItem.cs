using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Boardgame
{
	public class BoardgameListItem
	{
		[ScaffoldColumn(false)]
		public int Game_id { get; set; }

		[DisplayName("Game title")]
		public string Game_Title { get; set; }
	}
}
