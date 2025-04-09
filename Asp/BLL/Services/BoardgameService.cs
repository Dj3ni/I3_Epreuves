using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class BoardgameService : IBoardgameRepository<Boardgame>
	{
		// Service injection
		private readonly IBoardgameRepository<DAL.Entities.Boardgame> _boardgameService;
		private readonly IUserRepository<DAL.Entities.User> _userService;


		public BoardgameService(
			IBoardgameRepository<DAL.Entities.Boardgame> boardgameService, IUserRepository<DAL.Entities.User> userService)
		{
			_boardgameService = boardgameService;
			_userService = userService;
		}

		//Methods
		public IEnumerable<Boardgame> GetAll()
		{
			return _boardgameService.GetAll().Select(dal=>dal.ToBLL());
		}

		public Boardgame GetById(int id)
		{
			//For data set with script, will disappear in production
			Boardgame game = _boardgameService.GetById(id).ToBLL();
			User user = _userService.GetById(game.Registerer).ToBll();
			game.Registerer_Name = user.Pseudo;

			return game;
		}

		public int Insert(Boardgame game)
		{
			User user = _userService.GetById(game.Registerer).ToBll();
			game.Registerer_Name = user.Pseudo;

			return _boardgameService.Insert(game.ToDAL());
		}
	}
}
