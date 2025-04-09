using ASP_MVC.Handlers.ActionFilters;
using ASP_MVC.Handlers.Managers;
using ASP_MVC.Models.Auth;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
	public class AuthController : Controller
	{
		//Service injection
		private readonly IUserRepository<User> _userService;
		private readonly SessionManager _sessionManager;

		public AuthController(IUserRepository<User> userService, SessionManager sessionManager)
		{
			_userService = userService;
			_sessionManager = sessionManager;
		}

		//Actions
		[AnonymousNeeded]
		public IActionResult Index()
		{
			return RedirectToAction(nameof(Login));
		}

		//Get
		[AnonymousNeeded]
		public IActionResult Login()
		{
			return View();
		}

		//Post
		[HttpPost]
		[AnonymousNeeded]
		public IActionResult Login(AuthLoginForm form)
		{
			try
			{
				if (!ModelState.IsValid) throw new ArgumentException(nameof(form));

				//1. Check if identifiers match
				Guid id = _userService.CheckPassword(form.Email, form.Password);

				//2. Init session: 
				User user = _userService.GetById(id);
				ConnectedUser sessionUser = new ConnectedUser()
				{
					User_Id = user.User_Id,
					Pseudo = user.Pseudo,
					Email = user.Email,
					ConnectedAt = DateTime.Now,
				};

				//3. Login
				_sessionManager.Login(sessionUser);

				//4. Redirect
				return RedirectToAction("Index", "Home");
				//return RedirectToAction("Details", "User", new {id});

			}
			catch (Exception)
			{

				return View();
			}
		}

		//Get
		[ConnectionNeeded]
		public IActionResult Logout()
		{
			return View();
		}

		//Post
		[HttpPost]
		[ConnectionNeeded]
		public IActionResult Logout(IFormCollection form)
		{
			try
			{
				_sessionManager.Logout();
				return RedirectToAction(nameof(Login));
			}
			catch (Exception)
			{
				return View();
			}
		}
	}
}
