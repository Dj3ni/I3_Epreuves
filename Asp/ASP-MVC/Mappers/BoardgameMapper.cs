using ASP_MVC.Models.Boardgame;
using BLL.Entities;

namespace ASP_MVC.Mappers
{
	internal static class BoardgameMapper
	{
		/// <summary>
		/// Convert BLL Boardgame to BoardgameListItem view model
		/// </summary>
		/// <param name="game">BLL Boardgame</param>
		/// <returns>BoardgameListItem</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static BoardgameListItem ToListItem(this Boardgame game)
		{
			if(game is null) throw new ArgumentNullException(nameof(game));
			return new BoardgameListItem()
			{
				Game_id = game.Game_id,
				Game_Title = game.Game_Title,
			};
		}

		/// <summary>
		/// Convert BLL Boardgame To BoardgameDetails view model
		/// </summary>
		/// <param name="game"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static BoardgameDetails ToDetails(this Boardgame game)
		{
			if( game is null) throw new ArgumentNullException( nameof(game));
			return new BoardgameDetails()
			{
				Game_id = game.Game_id,
				Game_Title = game.Game_Title,
				Description = game.Description,
				MinAge = game.MinAge,
				MaxAge = game.MaxAge,
				MinPlayers = game.MinPlayers,
				MaxPlayers = game.MaxPlayers,
				Duration = game.Duration,
				Registerer_Name = game.Registerer_Name,
				Registerer = game.Registerer,
			};
		}

		/// <summary>
		/// Convert data from BoardgameCreate form to a BLL Boardgame
		/// </summary>
		/// <param name="form">BoardgameCreate</param>
		/// <returns>BLL Boardgame</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Boardgame ToBLL(this BoardgameCreate form)
		{
			if(form is null) throw new ArgumentNullException(nameof(form));
			return new Boardgame(
					-1,
					form.Game_Title,
					form.Description,
					form.MinAge,
					form.MaxAge,
					form.MinPlayers,
					form.MaxPlayers,
					form.Duration ?? null,
					form.Registerer
					//new Guid("568E2481-4ECD-414E-B370-506D603D3727") //For debug
				);
		}
	}
}
