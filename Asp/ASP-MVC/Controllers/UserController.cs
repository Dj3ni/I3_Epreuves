using ASP_MVC.Handlers.ActionFilters;
using ASP_MVC.Handlers.Managers;
using ASP_MVC.Mappers;
using ASP_MVC.Models.User;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
	public class UserController : Controller
	{
		//Services injection
		private readonly IUserRepository<User> _userService;
		private readonly SessionManager _sessionManager;


		public UserController(IUserRepository<User> userService, SessionManager sessionManager)
		{
			_userService = userService;
			_sessionManager = sessionManager;

		}


		// GET: UserController (Only for Debug)
		public ActionResult Index()
		{
			IEnumerable<UserListItem> model = _userService.GetAll().Select(bll=>bll.ToListItem());
			return View(model);
		}

		// GET: UserController/Details/5
		[ConnectionNeeded]
		public ActionResult Details(Guid id)
		{
			UserDetails model = _userService.GetById(id).ToDetails();
			

			return View(model);
		}

		// GET: UserController/Create
		[AnonymousNeeded]
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AnonymousNeeded]
		public ActionResult Create(UserInsert form)
		{
			try
			{
				if (!ModelState.IsValid) throw new ArgumentException(nameof(form));

				//Add in DB
				Guid id = _userService.Insert(form.ToBLL());

				//Connect to Session (see if possible to redirect to Login Post)
				User user = _userService.GetById(id);
				ConnectedUser sessionUser = new ConnectedUser()
				{
					User_Id = user.User_Id,
					Pseudo = user.Pseudo,
					Email = user.Email,
					ConnectedAt = DateTime.Now,
				};
				_sessionManager.Login(sessionUser);

				//Redirect
				return RedirectToAction(nameof(Index), "Home");
				//return RedirectToAction(nameof(Details), new {id});
			}
			catch
			{
				return View();
			}
		}

		// GET: UserController/Edit/5
		[ConnectionNeeded]
		public ActionResult Edit(Guid id)
		{
			UserUpdate model = _userService.GetById(id).ToEdit();
			return View(model);
		}

		// POST: UserController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ConnectionNeeded]
		public ActionResult Edit(Guid id, UserUpdate form)
		{
			try
			{
				if(!ModelState.IsValid)throw new ArgumentException(nameof(form));
				_userService.Update(id, form.ToBLL());
				return RedirectToAction(nameof(Details), new {id});
			}
			catch
			{
				return View();
			}
		}

		// GET: UserController/Unsubscribe/5
		[ConnectionNeeded]
		public ActionResult Unsubscribe(Guid id)
		{
			UserUnsubscribe model = _userService.GetById(id).ToUnsubscribe();
			return View(model);
		}

		// POST: UserController/Unsubscribe/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ConnectionNeeded]
		public ActionResult Unsubscribe(Guid id, UserUnsubscribe form)
		{
			try
			{
				_userService.Update(id, form.ToBLL());
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
