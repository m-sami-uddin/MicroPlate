using Microsoft.OpenApi.Models;
using MMLib.Ocelot.Provider.AppConfiguration;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotApiGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Configuration.AddOcelotWithSwaggerSupport(o =>
            o.Folder = "Configurations");
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddOcelot(builder.Configuration).AddAppConfiguration();
            builder.Services.AddSwaggerForOcelot(builder.Configuration);
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("LocalReact",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            var app = builder.Build();
            int negative = 0, positive = 0, zero = 0;
            var a = new List<int>() { 1, 2 };
            a.ForEach(x =>
            {
                if (x < 0)
                    negative++;
                else if (x > 0)
                    positive++;
                else
                    zero++;
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                //        app.UseSwaggerUI();
            }
            app.UseCors("LocalReact");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.DownstreamSwaggerHeaders = new[]
                {
                        new KeyValuePair<string, string>("Key", "Value"),
                        new KeyValuePair<string, string>("Key2", "Value2"),
                    };
            })
                .UseOcelot()
                .Wait();
            app.MapControllers();
            app.Run();
        }
    }
}