
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Repository;
using Talabat.Repository.Data;
using Talabat.Repository.Repos;

namespace Talabat.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddSingleton<IConnectionMultiplexer>((ServiceProvider) =>
            {
                var connection = builder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);
            }
            
            );
            builder.Services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
            builder.Services.AddScoped<IgenericRepository<Product>,GenericRepository<Product>>();
            var app = builder.Build();


            //code insteade of doing update-database in Package Manager Console
            //once run this code will automatic migrate any migrations
            var scope=app.Services.CreateScope();
            var serveces = scope.ServiceProvider;
            var _dbcontext=serveces.GetRequiredService<StoreContext>();
            var logger=serveces.GetRequiredService<ILoggerFactory>();
            try
            {
                _dbcontext.Database.Migrate();
              await  SeedData.Seed(_dbcontext);
            }
            catch (Exception ex)
            {
              var log=  logger.CreateLogger<Program>();
                log.LogError(ex, "an error occures");
            }
           ///////////////////////////////////////////////
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
