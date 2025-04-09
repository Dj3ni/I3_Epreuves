using ASP_MVC.Handlers;
using ASP_MVC.Handlers.ActionFilters;
using ASP_MVC.Handlers.Managers;
using ASP_MVC.Mappers;
using ASP_MVC.Models.Boardgame;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
	public class BoardgameController : Controller
	{
		// Service injection
		private readonly IBoardgameRepository<Boardgame> _boardgameService;
		private readonly SessionManager _sessionManager;

		public BoardgameController(IBoardgameRepository<Boardgame> boardgameService, SessionManager sessionManager)
		{
			_boardgameService = boardgameService;
			_sessionManager = sessionManager;
		}

		// GET: BoardgameController
		public ActionResult Index()
		{
			IEnumerable<BoardgameListItem> model = _boardgameService.GetAll().Select(bll=>bll.ToListItem());
			return View(model);
		}

		// GET: BoardgameController/Details/5
		public ActionResult Details(int id)
		{
			BoardgameDetails model = _boardgameService.GetById(id).ToDetails();
			return View(model);
		}

		// GET: BoardgameController/Create
		[ConnectionNeeded]
		public ActionResult Create()
		{
			return View();
		}

		// POST: BoardgameController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ConnectionNeeded]
		public ActionResult Create(BoardgameCreate form)
		{
			try
			{
				//Custom validations
				ModelState.MinMaxValidation(form.MinAge,form.MaxAge, nameof(form.MinAge), nameof(form.MaxAge));
				ModelState.MinMaxValidation(form.MinPlayers, form.MaxPlayers, nameof(form.MinPlayers), nameof(form.MaxPlayers));

				//FormValidation
				if(!ModelState.IsValid) throw new ArgumentException(nameof(form));

				//We get the userId with SessionManager
				ConnectedUser? user = _sessionManager.ConnectedUser ?? null;

				if(user is not null)
				{
					//We get it's Id and link it to Boardgame
					Guid user_id = user.User_Id;
					form.Registerer = user_id;
				
					//Insert in DB
					int id = _boardgameService.Insert(form.ToBLL());

					//Redirect
					return RedirectToAction(nameof(Details), new { id });
				}

				else return View();
			}
			catch
			{
				return View();
			}
		}

	}
}
