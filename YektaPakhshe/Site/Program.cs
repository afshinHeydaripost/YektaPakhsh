using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Identity;
using Site.Areas.Identity.Data;

namespace Site
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			string connection = builder.Configuration.GetConnectionString("MainConnection");
			// Add services to the container.
			builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
			#region Identity
			builder.Services.AddDbContext<UserContext>(options =>
							options.UseSqlServer(connection));

  // builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UserContext>();

			//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UserContext>();

			//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
			//	//.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedPhoneNumber = true)
			//	.AddEntityFrameworkStores<UserContext>()
			//	.AddDefaultTokenProviders();
			builder.Services.ConfigureApplicationCookie(options =>
			{
				// Cookie settings
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromDays(365);


				options.LoginPath = "/Identity/Account/Login";
				options.AccessDeniedPath = "/Identity/Account/AccessDenied";
			});

			builder.Services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 5;
				options.Password.RequiredUniqueChars = 0;
				options.SignIn.RequireConfirmedAccount = false;
				options.SignIn.RequireConfirmedEmail = false;
				options.SignIn.RequireConfirmedPhoneNumber = true;
			});
			builder.Services.Configure<SecurityStampValidatorOptions>(options =>
			{
				// enables immediate logout, after updating the user's stat.
				options.ValidationInterval = TimeSpan.Zero;
			});
			#endregion
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}