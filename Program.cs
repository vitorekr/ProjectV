using Microsoft.EntityFrameworkCore;
using ProjectV.Data;
using ProjectV.Interfaces;
using ProjectV.Repository;
using ProjectV.Repository.Interfaces;
using ProjectV.Services;

namespace ProjectV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<TravelDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();
            builder.Services.AddScoped<IContinentRepository, ContinentRepository>();

            builder.Services.AddScoped<CityService>();
            builder.Services.AddScoped<CountryService>();
            builder.Services.AddScoped<ContinentService>();

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
}