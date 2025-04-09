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
	public class UserService : IUserRepository<User>
	{
		//Service injection
		private readonly IUserRepository<DAL.Entities.User> _userService;
		private readonly ILibraryRepository<DAL.Entities.GameCopy> _libraryService;
		private readonly IBoardgameRepository<DAL.Entities.Boardgame> _boardgameService;

		public UserService(IUserRepository<DAL.Entities.User> userService, ILibraryRepository<DAL.Entities.GameCopy> libraryService, IBoardgameRepository<DAL.Entities.Boardgame> boardgameService)
		{
			_userService = userService;
			_libraryService = libraryService;
			_boardgameService = boardgameService;
		}

		//Methods

		public IEnumerable<User> GetAll()
		{
			return _userService.GetAll().Select(dal=>dal.ToBll());
		}

		public User GetById(Guid id)
		{
			User user = _userService.GetById(id).ToBll();
			List<GameCopy> library = _libraryService.GetByUserId(id).Select(dal=>dal.ToBLL()).ToList();

			foreach(GameCopy gameCopy in library)
			{
				Boardgame game = _boardgameService.GetById(gameCopy.Game_Id).ToBLL();
				gameCopy.SetTitle(game);
				gameCopy.SetOwner(user);			
			}
			user.AddGameCopies(library);

			return user;
		}

		public Guid Insert(User user)
		{
			return _userService.Insert(user.ToDAL());
		}

		public void Update(Guid id, User user)
		{
			_userService.Update(id, user.ToDAL());
		}

		public Guid CheckPassword(string email, string password)
		{
			return _userService.CheckPassword(email, password);
		}
	}
}
