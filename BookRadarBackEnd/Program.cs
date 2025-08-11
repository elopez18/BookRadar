using BookRadarBackEnd.Context;
using BookRadarBackEnd.Extentions;
using BookRadarBackEnd.Helpers;
using BookRadarBackEnd.Repositories;
using BookRadarBackEnd.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var serviceProvider = new ServiceCollection()
               .AddScoped<IGetConfig, GetConfig>()
               .BuildServiceProvider();

        var ConfigProperties = serviceProvider.GetService<IGetConfig>();
        var Configuration = ConfigProperties.GetConfiguration();
        var ValidIssuer = Configuration["userSecret:Jwt:Issuer"];
        var ValidAudience = Configuration["userSecret:Jwt:Audience"];
        var IssuerSignIngKey = Configuration["userSecret:Jwt:Key"];
        var ConnectionString = Configuration["ConnectionStrings:Db:DefaultConnectionString"];
        var LogFilePath = !string.IsNullOrWhiteSpace(Configuration["FilePath"])
            ? Configuration["FilePath"]
            : "D:\\Proyectos\\Prueba Tecnica\\BookRadarBackEnd\\Logs\\LogBookRadar.txt";

        // Configurar Serilog antes de construir la aplicación
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(LogFilePath,
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 10,
            flushToDiskInterval: TimeSpan.FromSeconds(1))
            .CreateLogger();

        try
        {
            Log.Information("Iniciando la aplicación");
            Log.Information("Serilog ha sido configurado correctamente. LogPath: {LogPath}", LogFilePath);

            builder.Services.AddDbContext<BooksRadarContext>(options => options.UseSqlServer(ConnectionString));
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddMvc();
            // Agregar extensiones
            builder.Services.AddBooksExtentions();
            builder.Services.AddGetConfigExtentions();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Options =>
            {
                Options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = ValidIssuer,
                    ValidAudience = ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IssuerSignIngKey))
                };
            });

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "BookRadar.BackEnd", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token."
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            builder.Services.AddCors(options =>
            {

                options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();

                });
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment() || app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookRadar.BackEnd V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            app.UseCors("AllowAllOrigins");
            Log.Information("Aplicación iniciada correctamente");
            app.Run();
        }
        catch (Exception Ex)
        {
            Log.Fatal(Ex, $"La aplicación se detuvo debido a una excepción grave {Ex.Message}");
            throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}