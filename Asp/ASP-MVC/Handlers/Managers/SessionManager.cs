using System.Text.Json;

namespace ASP_MVC.Handlers.Managers
{
	public class SessionManager
	{
		private readonly ISession _session;
		public SessionManager(IHttpContextAccessor accessor)
		{
			_session = accessor.HttpContext.Session;
		}

		public ConnectedUser? ConnectedUser
		{
			get { return JsonSerializer.Deserialize<ConnectedUser?>(_session.GetString(nameof(ConnectedUser)) ?? "null"); }
			set
			{
				if (value is null)
				{
					_session.Remove(nameof(ConnectedUser));
				}
				else
				{
					_session.SetString(nameof(ConnectedUser), JsonSerializer.Serialize(value));
				}
			}
		}
		public void Login(ConnectedUser user)
		{
			ConnectedUser = user;
		}

		public void Logout()
		{
			ConnectedUser = null;
		}
	}
}
