using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.User
{
	public class UserUpdate
	{
		[ScaffoldColumn(false)]
		public Guid User_Id { get; set; }

		[DisplayName("Pseudo")]
		[MinLength(6, ErrorMessage = "The Field Pseudo must have a minimum of 6 characters")]
		[MaxLength(64, ErrorMessage = "The Field Pseudo must have a maximum of 64 characters")]
		public string Pseudo { get; set; }


		//[ScaffoldColumn(false)]
		//public string Email { get; set; }
		
		//[ScaffoldColumn(false)]
		//public string Password { get; set; }
	}
}
