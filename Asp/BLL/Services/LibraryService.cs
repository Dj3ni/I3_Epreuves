using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class LibraryService : ILibraryRepository<GameCopy>
	{
		//Service injection
		private readonly ILibraryRepository<DAL.Entities.GameCopy> _libraryService;
		private readonly IUserRepository<DAL.Entities.User> _userService;
		private readonly IBoardgameRepository<DAL.Entities.Boardgame> _boardgameService;

		public LibraryService(ILibraryRepository<DAL.Entities.GameCopy> libraryService, IUserRepository<DAL.Entities.User> userService, IBoardgameRepository<DAL.Entities.Boardgame> boardgameService)
		{
			_libraryService = libraryService;
			_userService = userService;
			_boardgameService = boardgameService;
		}

		//Methods

		//For Debug
		public IEnumerable<GameCopy> GetAll()
		{
			return _libraryService.GetAll().Select(dal => dal.ToBLL());
		}

		public IEnumerable<GameCopy> GetByGameId(int game_id)
		{
			return _libraryService.GetByGameId(game_id).Select(dal=>dal.ToBLL());
		}

		public GameCopy GetById(int id)
		{
			GameCopy gameCopy = _libraryService.GetById(id).ToBLL();
			User owner = _userService.GetById(gameCopy.User_Id).ToBll();
			Boardgame boardgame = _boardgameService.GetById(gameCopy.Game_Id).ToBLL();

			gameCopy.SetOwner(owner);
			gameCopy.SetTitle(boardgame);

			//foreach(GameCopy game in owner.Library)
			//{
			//	game.SetTitle(boardgame);
			//	game.SetOwner(owner);
			//}

			return gameCopy;
		}

		public IEnumerable<GameCopy> GetByUserId(Guid user_id)
		{
			//IEnumerable<GameCopy> library = 


			//foreach (GameCopy gameCopy in library)
			//{
				
			//}

			//foreach(GameCopy gameCopy in library.ToList())
			//{
			//	User user = _userService.GetById(user_id).ToBll();
			//	Boardgame game = _boardgameService.GetById(gameCopy.Game_Id).ToBLL();

			//	gameCopy.Owner = user.Pseudo;
			//	gameCopy.Game_Title = game.Game_Title;				
			//}

			return _libraryService.GetByUserId(user_id).Select(dal => dal.ToBLL());
		}

		public int Insert(GameCopy gameCopy)
		{
			return _libraryService.Insert(gameCopy.ToDAL());
		}

		public void Update(int id, GameCopy gameCopy)
		{
			_libraryService.Update(id, gameCopy.ToDAL());
		}

		public void Delete(int id)
		{
			_libraryService.Delete(id);
		}
	}
}
