using ASP_MVC.Handlers.Managers;
using Common.Repositories;

namespace ASP_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			//Session Manager
			builder.Services.AddHttpContextAccessor();
				//InMemory, for debug :
				builder.Services.AddDistributedMemoryCache();
			//With DB
			//builder.Services.AddDistributedSqlServerCache(
			//		options =>
			//		{
			//			options.ConnectionString = builder.Configuration.GetConnectionString("Session-DB");
			//			options.SchemaName = "dbo";
			//			options.TableName = "Session";
			//		}
			//		);

			//Cookie configs
			builder.Services.AddSession(
			options => {
				options.Cookie.Name = "CookieEpreuveAsp";
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
				options.IdleTimeout = TimeSpan.FromMinutes(10);
			});
			builder.Services.Configure<CookiePolicyOptions>(options => {
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
				options.Secure = CookieSecurePolicy.Always;
			});

			// Personalized Services

				//SessionManager
				builder.Services.AddScoped<SessionManager>();

				//User
				builder.Services.AddScoped<IUserRepository<DAL.Entities.User>,DAL.Services.UserService>();
				builder.Services.AddScoped<IUserRepository<BLL.Entities.User>,BLL.Services.UserService>();
			
				//Boardgame
				builder.Services.AddScoped<IBoardgameRepository<DAL.Entities.Boardgame>,DAL.Services.BoardgameService>();
				builder.Services.AddScoped<IBoardgameRepository<BLL.Entities.Boardgame>,BLL.Services.BoardgameService>();

				//Library
				builder.Services.AddScoped<ILibraryRepository<DAL.Entities.GameCopy>, DAL.Services.LibraryService>();
				builder.Services.AddScoped<ILibraryRepository<BLL.Entities.GameCopy>, BLL.Services.LibraryService>();
				

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseSession();
			app.UseCookiePolicy();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
