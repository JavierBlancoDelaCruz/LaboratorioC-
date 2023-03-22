using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_SINTAXIS
{
    internal class Ejercicio5
    {
        /* Ejercicio 5:
         * Solicitar un número al usuario y generar un Array con N números aleatorios.
         * Por ejemplo, si el usuario introduce 4, el resultado por consola debería ser: 23, 34, 234, 11
         */
        static void Main(string[] args)
        {
            Console.Write("¿Cuántos número aleatorios quieres?: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            
            //Con semilla
            var seed = Environment.TickCount; //Semilla basada en el reloj del sistema
            var random = new Random(seed);

            //Sin semilla
            //Random random = new Random();

            //Rango de números aleatorios:
            int min = 0;
            int max = 100;
            
            for (int i = 0; i < cantidad; i++)
            {
                var numero = random.Next(min, max+1); //Números aleatorios entre 0 y 100
                if (i == 0)
                { 
                    Console.Write("\n" + numero); 
                }
                else
                {
                    Console.Write("," + numero);
                }
            }

            Console.ReadLine();
        }
    }
}
