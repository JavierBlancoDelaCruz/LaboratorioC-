using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_SINTAXIS
{
    internal class Ejercicio1
    {
        /* Ejercicio 1:
         * 
         * Solicite el nombre de una persona, su edad y el nombre de una ciudad.
         * Después de solicitar estos datos deberá mostrar por pantalla el siguiente mensaje:
         *   Te llamas <nombre> y tienes <edad> años.Bienvenido a <ciudad>.
         *   
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("\nEdad: ");
            string edad = Console.ReadLine();

            Console.WriteLine("\nCiudad: ");
            string ciudad = Console.ReadLine();


            Console.WriteLine($"\n\nTe llamas {nombre} y tienes {edad} años. Bienvenido/a a {ciudad}.");
            Console.ReadLine();
        }
    }
}
