using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ASP_MVC.Models.Library;

namespace ASP_MVC.Models.User
{
	public class UserDetails
	{
		[ScaffoldColumn(false)]
		public Guid User_Id { get; set; }

		[DisplayName("Pseudo")]
		public string Pseudo { get; set; }

		[DisplayName("Email")]
		public string Email { get; set; }

		public IEnumerable<GameCopyListItem>? Library { get; set; }

	}
}
