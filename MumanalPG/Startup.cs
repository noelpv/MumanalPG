//dotnet publish --configuration Release

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var connectionString = Configuration.GetConnectionString("DefaultConnection");

			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.Lax;
			});

			//services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


			services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultUI()
				.AddDefaultTokenProviders();
			//services.AddIdentity<MumanalPG.Models.ApplicationUser, IdentityRole>()
			//	.AddEntityFrameworkStores<ApplicationDbContext>()
			//	.AddDefaultUI()
			//	.AddDefaultTokenProviders();

			services.AddScoped<IDbInitializer, DbInitializer>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddPaging(options => {
				options.ViewName = "Bootstrap4";
			});

			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30);
				options.Cookie.HttpOnly = true;
			});

			services.UseBreadcrumbs(GetType().Assembly);

			services.AddDistributedMemoryCache();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
				
			}
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

			
			dbInitializer.Initialize();
	        app.UseAuthentication();
            app.UseSession();

			//app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
			//{
			//	AuthenticationScheme = "oidc",
			//	SignInScheme = "Cookies"
			//	// other options omitted...
			//});

			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "areas",template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
				routes.MapRoute(name: "default", template: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");
			});
			
			app.UseStaticFiles();
	        
	        // Configuramos Rotativa indicándole el Path RELATIVO donde se
	        // encuentran los archivos de la herramienta wkhtmltopdf.
	        Rotativa.AspNetCore.RotativaConfiguration.Setup(env, "..\\Rotativa\\Windows\\");
		}
	}
}
