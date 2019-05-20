using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MumanalPG.Data.Seeders;

namespace MumanalPG.Data
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<ApplicationDbContext>();

                // now we have the DbContext. Run migrations
                context.Database.Migrate();

                // now that the database is up to date. Let's seed
                new UnidadEjecutoraSeeder(context).SeedData();
                new PuestoSeeder(context).SeedData();
                new FuncionariosPuestoSeeder(context).SeedData();

//#if DEBUG
//                // if we are debugging, then let's run the test data seeder
//                // alternatively, check against the environment to run this seeder
//                new TestDataSeeder(context).SeedData();
//#endif
            }

            return host;
        }
    }
}