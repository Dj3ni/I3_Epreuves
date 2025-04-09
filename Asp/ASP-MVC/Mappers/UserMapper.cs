using ASP_MVC.Models.User;
using BLL.Entities;

namespace ASP_MVC.Mappers
{
	internal static class UserMapper
	{
		/// <summary>
		/// Convert BLL User to data for UserListItem view model
		/// </summary>
		/// <param name="user">BLL User</param>
		/// <returns>UserListItem</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static UserListItem ToListItem(this User user)
		{
			if(user is null) throw new ArgumentNullException(nameof(user));
			return new UserListItem()
			{
				User_Id = user.User_Id,
				Pseudo = user.Pseudo,
			};
		}

		/// <summary>
		/// Convert BLL User to data for UserDetails view model
		/// </summary>
		/// <param name="user">BLL User</param>
		/// <returns>UserDetails</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static UserDetails ToDetails(this User user)
		{
			if(user is null) throw new ArgumentNullException(nameof(user));
			return new UserDetails()
			{
				User_Id = user.User_Id,
				Pseudo = user.Pseudo,
				Email = user.Email,
				Library = (user.Library is null)? null : user.Library.Select(g=>g.ToListItem()),
			};
		}

		/// <summary>
		/// Con,
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static UserUpdate ToEdit(this User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return new UserUpdate()
			{
				User_Id = user.User_Id,
				Pseudo = user.Pseudo,
				//Email = user.Email,
				//Password = user.Password,
			};
		}

		/// <summary>
		/// Convert UserUpdate form data to User BLL
		/// </summary>
		/// <param name="form">UserUpdate</param>
		/// <returns>BLL User</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static User ToBLL(this UserUpdate form)
		{
			if (form is null) throw new ArgumentNullException(nameof(form));
			return new User(
					form.User_Id,
					form.Pseudo,
					"",
					""
				);
		}

		/// <summary>
		/// Convert UserInsert form data to BLL User 
		/// </summary>
		/// <param name="form">UserInsert</param>
		/// <returns>BLL User</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static User ToBLL(this UserInsert form)
		{
			if (form is null) throw new ArgumentNullException(nameof(form));
			return new User(
					Guid.Empty,
					form.Pseudo,
					form.Email,
					form.Password
				);
		}

		/// <summary>
		/// convert BLL User to Data for UserUnsubscribe view model
		/// </summary>
		/// <param name="user">BLL User</param>
		/// <returns>UserUnsubscribe</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static UserUnsubscribe ToUnsubscribe(this User user)
		{
			if(user is null) throw new ArgumentNullException( nameof(user));
			return new UserUnsubscribe()
			{
				User_Id = user.User_Id,
				Pseudo = user.Pseudo,
				Email = user.Email,
				//Deactivation_Date = user.Deactivation_Date,
			};
		}

		/// <summary>
		/// Init desactivation date with DateTime.Now and convert all data from To BLL User
		/// </summary>
		/// <param name="form"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static User ToBLL(this UserUnsubscribe form)
		{
			if (form is null) throw new ArgumentNullException(nameof(form));
			return new User(
					Guid.Empty,
					"",
					"",
					"",
					DateTime.Now
				);
		}


	}
}
