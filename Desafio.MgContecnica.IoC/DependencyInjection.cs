using Desafio.MgContecnica.Application.Interfaces;
using Desafio.MgContecnica.Application.Services;
using Desafio.MgContecnica.Domain.Repositorios;
using Desafio.MgContecnica.Infrastructure.Context;
using Desafio.MgContecnica.Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.MgContecnica.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

           services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
           services.AddScoped<ICategoriaService,CategoriaService>();

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
