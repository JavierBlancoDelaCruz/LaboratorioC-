using Laboratorio_CSharp_WEBAPI.Contracts;
using Laboratorio_CSharp_WEBAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_WEBAPI
{
    public class Startup //Aquí podemos encontrar la configuración de todos los servicios que tengamos activos en nuestro servidor web.
                         //Por defecto, añade el servicio de los controladores, nos agrega Swagger
                         //y también podríamos incluir aquí todas las inyecciones de dependencia.
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(); //Servicio de los controladores
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Laboratorio_CSharp_WEBAPI", Version = "v1" }); //Servicio de Swagger (reglas, especificaciones y herramientas que nos ayudan a documentar nuestra API de forma automática
            });
            //Para evitar el acoplamiento entre clases utilizando interfaces (y así que no de errores de System.InvalidOperationException)
            //Registrar servicios e inyectar dependencias a todos los controladores:
            services.AddTransient<IActorRepository, ActorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Laboratorio_CSharp_WEBAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
