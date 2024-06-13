using AutomobiliuNuoma.Services;
using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Repositories;
using MongoDB.Driver;
using Serilog;
using System.Text.Json;


public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        string connectionString = "Server=DESKTOP-8V5PSN2;Database=AutomobiliuNuoma;Integrated Security=True;";
       

        // Register your services and repositories
        builder.Services.AddScoped<IDatabaseRepository, DatabaseRepository>(_=> new DatabaseRepository(connectionString));
        builder.Services.AddScoped<INuomaService, NuomaService>();
        builder.Services.AddScoped<IMongoClient, MongoClient>(sp => new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));
        builder.Services.AddScoped<IMongoDBRepository, MongoDBRepository>();

        Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

        builder.Host.UseSerilog();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        

        app.UseCors("AllowOrigin");
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

  


}
