using DAL.Interface;
using DAL.Data;

using Microsoft.EntityFrameworkCore;
using Models.Models;
using Serilog;
using Project.middleWare;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string Cors = "_Cors";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IToDo, ToDoData>();
            builder.Services.AddScoped<IPost, PostData>();



            builder.Services.AddCors(op =>
            {
                op.AddPolicy(Cors, builder =>
                {
                    builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                });
            });


            builder.Services.AddDbContext<ProjectContext>(op => op.UseSqlServer("Data Source=DESKTOP-E0FAPSB\\SQLEXPRESS;Initial Catalog=projectReactAndCore;Integrated Security=SSPI;Trusted_Connection=True;"));
            Log.Logger = new LoggerConfiguration()
    .WriteTo.File(@"C:\Users\The user\Desktop\μιξεγιν\ιγ\react\projectFinal\Project.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseMiddleware<ErrorGlobalMiddleWare>();
            app.UseMiddleware<Middleware>();
            app.UseCors(Cors);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}