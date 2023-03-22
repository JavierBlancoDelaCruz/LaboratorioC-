using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_SINTAXIS
{
    internal class Ejercicio6
    {
        /* Ejercicio 6:
         * Solicitar un número al usuario y un carácter. Crear una pirámide con N filas y el carácter solicitado. 
         */
        static void Main(string[] args)
        {
            Console.Write("Introduce un número de filas para la pirámide: ");
            int filas = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduce un caracter para dibujar la pirámide: ");
            string caracter = Console.ReadLine();
            //Si se quisiera hacer para que solo se pudiese introducir un único caracter:
            //char caracter = Convert.ToChar(Console.ReadLine()); //Y habría que controlar la excepción en caso de que metiese más de un caracter

            string espacios = " ";
            for (var i=1; i<=filas; i++)
            { 
                if (i == 1)
                {
                    Console.WriteLine(caracter);
                }
                else if (i == filas)
                {
                    string fin = string.Concat(Enumerable.Repeat(caracter, filas));
                    Console.WriteLine(fin);
                }
                else
                {
                    string hueco = string.Concat(Enumerable.Repeat(espacios, i-2));
                    Console.WriteLine(caracter + hueco + caracter);
                }
            }

            Console.ReadLine();
        }
    }
}
