using ASP_MVC.Models.Library;
using BLL.Entities;

namespace ASP_MVC.Mappers
{
	internal static class LibraryMapper
	{
		/// <summary>
		/// Convert Data from GameCopyCreate form to BLL GameCopy
		/// </summary>
		/// <param name="form">GameCopyCreate</param>
		/// <returns>BLL GameCopy</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static GameCopy ToBLL(this GameCopyCreate form)
		{
			if (form is null) throw new ArgumentNullException(nameof(form));
			return new GameCopy(
				0,
				form.Game_Id,
				form.User_Id,
				form.State
			);
		}

		/// <summary>
		/// Convert BLL GameCopy to GamecopyListItem
		/// </summary>
		/// <param name="game">BLL GameCopy</param>
		/// <returns>GamecopyListItem</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static GameCopyListItem ToListItem(this GameCopy gameCopy)
		{
			if(gameCopy is null) throw new ArgumentNullException( nameof(gameCopy));
			return new GameCopyListItem()
			{
				Game_Copy_Id = gameCopy.Game_Id,
				Game_Id = gameCopy.Game_Id,
				User_Id = gameCopy.User_Id,
				State = gameCopy.State.ToString(),
				Game_Title = gameCopy.Game_Title,
				Owner = gameCopy.Owner
			};
		}

		/// <summary>
		/// Convert BLL Gamecopy to Data for GameCopyDelete view model
		/// </summary>
		/// <param name="gameCopy">BLL Gamecopy</param>
		/// <returns>GameCopyDelete</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static GameCopyDelete ToDelete(this GameCopy gameCopy)
		{
			if( gameCopy is null) throw new ArgumentNullException(nameof (gameCopy));
			return new GameCopyDelete() { 
				Game_Copy_Id = gameCopy.Game_Copy_Id,
				Game_title = gameCopy.Game_Title,
				State = gameCopy.State,
				User_Id= gameCopy.User_Id,
			};
		}
	}
}

		