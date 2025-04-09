using ASP_MVC.Handlers.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_MVC.Handlers.ActionFilters
{
	[AttributeUsage(AttributeTargets.Method)]
	public class AnonymousNeededAttribute : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			return;
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			//We block the way if the user is logged in
			if (context.HttpContext.Session.GetString(nameof(SessionManager.ConnectedUser)) is not null)
			{
				context.Result = new RedirectToActionResult("Index", "Home", null);
			}
		}
	}
}
