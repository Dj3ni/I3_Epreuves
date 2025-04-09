using BLL.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Library
{
	public class GameCopyCreate
	{

		[ScaffoldColumn(false)]
		public int Game_Id { get; set; } //Change with GameName

		[ScaffoldColumn(false)]
		public Guid User_Id { get; set; }

		public string Game_Title {  get; set; }

		[DisplayName("Select the tate of your game:'New', 'Incomplete', 'Damaged'")]
		[Required(ErrorMessage = "You have to inform the state of your game")]
		public string State { get; set; } //User Choice

		public List<SelectListItem> States { get; set; }

		

		
	}
}
