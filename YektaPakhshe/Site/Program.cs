using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Identity;
using Repository.Interface;
using Repository.Repositories;
using Site.Areas.Identity.Data;

namespace Site
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			string connection = builder.Configuration.GetConnectionString("MainConnection");
			builder.Services.AddDbContext<YektaPakhshContext>(options => options.UseSqlServer(connection).EnableSensitiveDataLogging());
			// Add services to the container.
			builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
			//Post in Ajax
			builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

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
				options.SignIn.RequireConfirmedEmail = true;
				options.SignIn.RequireConfirmedPhoneNumber = true;
			});
			builder.Services.Configure<SecurityStampValidatorOptions>(options =>
			{
				// enables immediate logout, after updating the user's stat.
				options.ValidationInterval = TimeSpan.Zero;
			});
			#endregion
			// Dependency Injection
			RegisterRepositories(builder.Services);
			builder.Services.AddCors();
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


		static void RegisterRepositories(IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
			services.AddScoped<IPersonRepository, PersonRepository>();
			services.AddScoped<IPreInvoiceRepository, PreInvoiceRepository>();
		}
	}
}