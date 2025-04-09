using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.User
{
	public class UserUnsubscribe
	{
		[ScaffoldColumn(false)]
		public Guid User_Id { get; set; }

		[DisplayName("Pseudo")]
		public string Pseudo { get; set; }

		[DisplayName("Email")]
		public string Email { get; set; }

		//[ScaffoldColumn(false)]
		//public DateTime? Deactivation_Date { get; set; }

		//[ScaffoldColumn(false)]
		//public string Password { get; set; }

	}
}
