using ASP_MVC.Handlers.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace ASP_MVC.Handlers.ActionFilters
{
	[AttributeUsage(AttributeTargets.Method)]
	public class AccessProfileAttribute : Attribute, IAuthorizationFilter
	{


		public void OnAuthorization(AuthorizationFilterContext context)
		{
			string? json = context.HttpContext.Session.GetString(nameof(SessionManager.ConnectedUser));

			//If not connected, send to login
			if (json == null)
			{
				context.Result = new RedirectToActionResult("Login","Auth", null);
				return;
			}

			//Otherwise send him to his profile page
			ConnectedUser user = JsonSerializer.Deserialize<ConnectedUser>(json);
			context.Result = new RedirectToActionResult("Details","User", new {id = user.User_Id});

		}
	}
}
