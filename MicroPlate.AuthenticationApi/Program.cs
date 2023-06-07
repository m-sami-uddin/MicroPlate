
using MicroPlate.JwtAuthenticationManager;
using MicroPlate.JwtAuthenticationManager.Data;
using MicroPlate.JwtAuthenticationManager.Mapper;
using MicroPlate.JwtAuthenticationManager.Models.Login;
using MicroPlate.JwtAuthenticationManager.Models.Register;
using MicroPlate.JwtAuthenticationManager.Repository;

namespace MicroPlate.AuthenticationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AuthenticationContext>();
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
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

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("LocalReact");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPost("Account/Login", (LoginRequestDto loginRequestDto, IUserRepository userRepository) =>

               userRepository.Login(loginRequestDto) is LoginResponseDto loginResponseDto
                   ? Results.Ok(loginResponseDto)
                   : Results.Unauthorized())
            .WithName("Login")
            .WithOpenApi();
            app.MapPost("/Account/Register", (RegisterRequestDto registerRequestDto, IUserRepository userRepository) =>
                userRepository.Register(registerRequestDto)
                   ? Results.Ok("Registered Successfully")
                   : Results.BadRequest("Failed")

            )
            .WithName("Register")
            .WithOpenApi();

            app.Run();
        }
    }
}