using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_SINTAXIS
{
    internal class Ejercicio3
    {
        /* Ejercicio 3:
         * Pedir el nombre de la semana al usuario y decirle si es fin de semana o no. 
         * En caso de error, indicarlo.
         */
        static void Main(string[] args)
        {
            Console.Write("Introduce un nombre de la semana: ");
            string nombre = Console.ReadLine();
            //Quitar tildes y poner en minúsculas:
            string nombre_semana = Regex.Replace(nombre.Normalize(NormalizationForm.FormD), @"[^a-zA-z]", "").ToLower();

            switch (nombre_semana)
            {
                case "lunes":
                case "martes":
                case "miercoles":
                case "jueves":
                case "viernes":
                    Console.WriteLine("El " + nombre + " NO es fin de semana.");
                    break;
                case "sabado":
                case "domingo":
                    Console.WriteLine("El " + nombre + " SÍ es fin de semana!");
                    break;
                default:
                    Console.WriteLine("\nERROR.\n" + nombre + " no es un nombre de la semana.");
                    break;
            }

            Console.ReadLine();
        }
    }
}
