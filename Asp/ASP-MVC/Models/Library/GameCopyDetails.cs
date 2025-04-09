using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Library
{
	public class GameCopyDetails
	{
		[ScaffoldColumn(false)]
		public int Game_Copy_Id { get; set; }

		[DisplayName("Game")]
		public int Game_Id { get; set; } //Change with GameName

		[DisplayName("Owner")]
		public Guid User_Id { get; set; } // Change with Pseudo
		public string State { get; set; }
	}
}
