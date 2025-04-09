using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class User
	{
		public Guid User_Id { get; set; }
		public string Pseudo { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime? Deactivation_Date { get; set; }

		//Link with Library
		private List<GameCopy> _library;
		public GameCopy[] Library
		{
			get { return _library.ToArray(); }
		}


		public User(Guid user_id, string pseudo, string email, string password, DateTime? deactivation_date)
		{
			User_Id = user_id;
			Pseudo = pseudo;
			Email = email;
			Password = password;
			Deactivation_Date = deactivation_date;
			_library = new List<GameCopy>();
		}

		public User(Guid user_id, string pseudo, string email, string password) :this(user_id, pseudo, email, password, null){ }

		//Methods

		/// <summary>
		/// Add a GameCopy to the User Library
		/// </summary>
		/// <param name="gamecopy">GameCopy</param>
		/// <exception cref="ArgumentNullException"></exception>
		public void AddGameCopy(GameCopy gamecopy)
		{
			if(gamecopy is null) throw new ArgumentNullException(nameof(gamecopy));
			_library.Add(gamecopy);
		}

		/// <summary>
		/// Initialisation of the Library
		/// </summary>
		/// <param name="library"></param>
		/// <exception cref="ArgumentNullException">IEnumerable<GameCopy></exception>
		public void AddGameCopies(IEnumerable<GameCopy> library)
		{
			if (library is null) throw new ArgumentNullException(nameof(library));
			foreach (GameCopy game in library)
			{
				AddGameCopy(game);
			}
		}
	}
}
