using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Implementations;
using Repository.Repositories.Interfaces;
using service.mappings;
using Service.Services.Implementations;
using Service.Services.Interfaces;
using System.Reflection;

namespace MinaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddFluentValidation(f => f.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()))
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new NetTopologySuite.IO.Converters.GeometryConverter());
                });



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<POIContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("defaultconnection"), o => o.UseNetTopologySuite());
            });


            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<IBuildRepository, BuildRepository>();
            builder.Services.AddScoped<IBuildService, BuildService>();




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