using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MumanalPG.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MumanalPG
{
	public class Program
	{
		public static int Main(string[] args)
		{
			try
			{
				var host = BuildWebHost(args);
				using (var scope = host.Services.CreateScope())
				{
					var services = scope.ServiceProvider;
					try
					{
						InitializeDatabase(services);
					}
					catch (Exception ex)
					{
						// something bad happened
					}
				}
				host.Run();
				return 0;
			}
			catch (Exception ex)
			{
				return 1;
			}
		}

		public static IWebHost BuildWebHost(string[] args) =>
		WebHost.CreateDefaultBuilder(args)
		.UseStartup<Startup>()
		.UseUrls("http://*:5000")
		.Build();

		private static void InitializeDatabase(IServiceProvider services)
		{
			using (var serviceScope = services.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
				context.Database.Migrate();
			}
		}
	}
}
