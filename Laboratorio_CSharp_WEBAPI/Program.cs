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
    public class Program //Contendr� el m�todo Main (PRIMER M�TODO QUE SE VA A EJECUTAR EN EL PROYECTO DE LA APLICACI�N)
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); //Llama al m�todo CreateHostBuilder() donde se carga la configuraci�n del host con la variable de entorno que tenga el prefijo dotnet.
        }

        /* CreateHostBuilder() carga la configuraci�n del host con la variable de entorno que tenga el prefijo dotnet. Esto lo realiza autom�ticamente.
         * Tambi�n carga la configuraci�n de appsettings.
         * Agrega los proveedores registro de consola, de depuraci�n
         * y carga la configuraci�n del Startup*/
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //Indica que cargue la configuraci�n del Startup
                });
    }
}
