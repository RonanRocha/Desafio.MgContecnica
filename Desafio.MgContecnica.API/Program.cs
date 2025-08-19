
using Bogus;
using Desafio.MgContecnica.API.Converters;
using Desafio.MgContecnica.API.Response;
using Desafio.MgContecnica.Domain.Entities;
using Desafio.MgContecnica.Infrastructure.Context;
using Desafio.MgContecnica.Infrastructure.Seeds;
using Desafio.MgContecnica.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Desafio.MgContecnica.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers()
                 .ConfigureApiBehaviorOptions(options =>
                 {
                     options.InvalidModelStateResponseFactory = context =>
                     {
                         var erros = context.ModelState
                             .Where(e => e.Value?.Errors.Count > 0)
                             .ToDictionary(
                                 kvp => kvp.Key,
                                 kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                             );

                         var resposta = new RespostaPadraoApi<object>
                         {
                             Sucesso = false,
                             Mensagem = "Erro de validação",
                             Erros = erros.SelectMany(e => e.Value).ToList(),
                             Dados = null
                         };

                         return new BadRequestObjectResult(resposta);
                     };
             })
            .AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.Converters.Add(new JsonDateOnlyConverter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date",
                    Example = OpenApiAnyFactory.CreateFromJson("\"yyyy-MM-dd\"")
                });
            });

            DependencyInjection.AddInfrastructure(builder.Services, builder.Configuration);


       

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();


                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    context.Database.Migrate();

                    var categorias = new List<Categoria>();
                    var transacoes = new List<Transacao>();

                    if (!context.Categorias.Any())
                    {
                        categorias = SeedData.GerarCategorias(100); // Bogus aqui
                        context.Categorias.AddRange(categorias);
                        context.SaveChanges();
                    }

                    if (!context.Transacoes.Any())
                    {


                        transacoes = SeedData.GerarTransacoes(categorias, 350);
                        context.Transacoes.AddRange(transacoes);
                        context.SaveChanges();


                    }

                }

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
