using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Auth
{
	public class AuthLoginForm
	{
		[DisplayName("E-mail : ")]
		[Required(ErrorMessage = "The field Email is compulsory")]
		[EmailAddress]
		public string Email { get; set; }

		[DisplayName("Password : ")]
		[Required(ErrorMessage = "The field Password is compulsory")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
