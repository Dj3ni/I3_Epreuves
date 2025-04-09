using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.User
{
	public class UserListItem
	{
		[ScaffoldColumn(false)]
		public Guid User_Id { get; set; }

		[DisplayName("Pseudo")]
		public string Pseudo { get; set; }
	}
}
