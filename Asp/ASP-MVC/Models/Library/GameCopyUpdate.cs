using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BLL.Entities;

namespace ASP_MVC.Models.Library
{
	public class GameCopyUpdate
	{
		[ScaffoldColumn(false)]
		public int Game_Copy_Id { get; set; }

		[DisplayName("Game")]
		public int Game_Id { get; set; } //Change with GameName

		[ScaffoldColumn(false)]
		public Guid User_Id { get; set; }

		[DisplayName("State of the game:'New', 'Incomplete', 'Damaged'")]
		[Required(ErrorMessage = "You have to inform the state of your game")]
		public StateEnum State { get; set; }
	}
}
