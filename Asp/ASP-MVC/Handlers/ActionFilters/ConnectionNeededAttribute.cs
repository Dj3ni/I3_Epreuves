using ASP_MVC.Handlers.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_MVC.Handlers.ActionFilters
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ConnectionNeededAttribute : Attribute, IAuthorizationFilter
	{
		private string _action;
		private string _controller;
		private bool _getRouteValue;

		//Constructor
		public ConnectionNeededAttribute() : this("Login", "Auth") { }
		public ConnectionNeededAttribute(string action, string controller, bool getRouteValue = false)
		{
			_action = action;
			_controller = controller;
			_getRouteValue = getRouteValue;
		}

		//Implement Interface
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			//Si user non connecté
			if (context.HttpContext.Session.GetString(nameof(SessionManager.ConnectedUser)) is null)
			{
				object? routeValue = null;
				//Si route à paramètres
				if (_getRouteValue)
				{
					routeValue = context.RouteData.Values;
				}
				context.Result = new RedirectToActionResult(_action, _controller, routeValue);
			}
		}
	}
}
