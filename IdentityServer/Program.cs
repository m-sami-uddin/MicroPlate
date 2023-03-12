
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var assembly = typeof(Program).Assembly.GetName().Name;
            var connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
            {
                options.UseSqlServer(connString, b => b.MigrationsAssembly(assembly));

            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AspNetIdentityDbContext>();

            builder.Services.AddIdentityServer().AddAspNetIdentity<IdentityUser>()
                .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b =>
                b.UseSqlServer(connString, options => options.MigrationsAssembly(assembly));
            })
              .AddOperationalStore(options =>
              {
                  options.ConfigureDbContext = b =>
                  b.UseSqlServer(connString, options => options.MigrationsAssembly(assembly));
              }).AddDeveloperSigningCredential();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseIdentityServer();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.Run();
        }
    }
}