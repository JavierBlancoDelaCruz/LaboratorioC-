using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_SINTAXIS
{
    internal class Ejercicio4
    {
        /* Ejercicio 4:
         * Recorre los números del 1 al 100. Muestra los números pares.
         * Usar el tipo de bucle que quieras.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Números pares del 1 al 100: ");

            //Forma 1:
            for (var n = 1; n < 101; n++)
            {
                if (n % 2 == 0)
                {
                    Console.WriteLine(n);
                }
            }


            //Forma 2:
            //for (var n=2; n<101; n=n+2)
            //{
            //    Console.WriteLine(n);
            //}

            Console.ReadLine();
        }
    }
}
