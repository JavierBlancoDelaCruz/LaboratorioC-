using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_WEBAPI
{
    public class Program //Contendrá el método Main (PRIMER MÉTODO QUE SE VA A EJECUTAR EN EL PROYECTO DE LA APLICACIÓN)
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); //Llama al método CreateHostBuilder() donde se carga la configuración del host con la variable de entorno que tenga el prefijo dotnet.
        }

        /* CreateHostBuilder() carga la configuración del host con la variable de entorno que tenga el prefijo dotnet. Esto lo realiza automáticamente.
         * También carga la configuración de appsettings.
         * Agrega los proveedores registro de consola, de depuración
         * y carga la configuración del Startup*/
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //Indica que cargue la configuración del Startup
                });
    }
}
