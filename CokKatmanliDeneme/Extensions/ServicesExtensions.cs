
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;

namespace CokKatmanliDeneme.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("CokKatmanliDeneme")));
        }
        public static void ConfigureRepositoryManager (this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager,RepositoryManager>();
        }
    }
}
