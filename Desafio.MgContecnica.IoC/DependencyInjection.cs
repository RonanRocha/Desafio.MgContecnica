using Desafio.MgContecnica.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.MgContecnica.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(configuration
                           .GetConnectionString("DefaultConnection"),
                               b => b.MigrationsAssembly(
                                       typeof(AppDbContext).Assembly.FullName))
           );


            return services;
        }
    }
}
