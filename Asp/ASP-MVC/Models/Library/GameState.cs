using BLL.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Library
{
	public class GameState
	{
		[DisplayName("State of the game:'New', 'Incomplete', 'Damaged'")]
		[Required(ErrorMessage = "You have to inform the state of your game")]
		public IEnumerable<StateEnum> States { get; set; }
	}
}
