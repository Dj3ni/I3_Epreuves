using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.User
{
	public class UserInsert
	{
		[DisplayName("Pseudo")]
		[MinLength(6, ErrorMessage = "The Field Pseudo must have a minimum of 6 characters")]
		[MaxLength(64, ErrorMessage = "The Field Pseudo must have a maximum of 64 characters")]
		public string Pseudo { get; set; }

		[DisplayName("Email")]
		[Required(ErrorMessage ="The Field Email is compulsory")]
		[EmailAddress]
		public string Email { get; set; }

		[DisplayName("Password")]
		[Required(ErrorMessage = "The Password Field is compulsory")]
		[MinLength(8, ErrorMessage = "Le champ 'Mot de passe' doit contenir au minimum 8 caractères.")]
		[MaxLength(32, ErrorMessage = "Le champ 'Mot de passe' doit contenir au maximum 32 caractères.")]
		[RegularExpression(@"^.*(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\-_+=\.()\[\]$µ£\\/*§?{}]).*", ErrorMessage = "Le champ 'Mot de passe' doit contenir au minimum une minuscule, une majuscule, un chiffre et un symbole.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DisplayName("Confirm Password")]
		[Required(ErrorMessage = "The Confirm Password Field is compulsory")]
		[Compare(nameof(Password),ErrorMessage = "Your confirmation doesn't match with Password")]
		[DataType(DataType.Password)]
		public string Confirm_Password { get; set; }

		[Required(ErrorMessage = "Vous devez lire et accepter les termes des conditions d'utilisation.")]
		public bool Consent { get; set; }

	}
}
