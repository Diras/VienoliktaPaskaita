using AutomobiliuNuoma.Services;
using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Repositories;


public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplicationForAutoNuoma.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register your services and repositories
        builder.Services.AddScoped<IDatabaseRepository, DatabaseRepository>();
        builder.Services.AddScoped<INuomaService, NuomaService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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