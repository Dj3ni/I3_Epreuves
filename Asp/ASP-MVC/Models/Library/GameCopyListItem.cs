using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Library
{
	public class GameCopyListItem
	{
		[ScaffoldColumn(false)]
		public int Game_Copy_Id { get; set; }

		public Guid User_Id { get; set; }
		public int Game_Id { get; set; }

		[DisplayName("Game")]
		public string Game_Title { get; set; }


		[DisplayName("Owner")]
		public string Owner { get; set; }

		public string State { get; set; }

	}
}
