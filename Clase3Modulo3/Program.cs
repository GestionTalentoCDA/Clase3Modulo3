using Clase3Modulo3.Repository;
using Clase3Modulo3.Services;
using Clase3Modulo3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clase3Modulo3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var connection =  builder.Configuration.GetConnectionString("DefaultConnection");
            //Diferentes formas de recuperar la configuracion...
            //var connection = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            //var connection = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;


            //AddSingleton
            builder.Services.AddDbContext<Clase3Modulo3Context>(opt =>
                    opt.UseSqlServer(connection));

            // Contenedor de dependencias => 
            //New ClienteService()

            builder.Services.AddScoped<IClienteService,ClienteService>();
                    
            
            //new prueba
            //builder.Services.AddSingleton<Prueba>();
            //builder.Services.AddScoped<Prueba>();

           builder.Services.AddTransient<Prueba>();

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