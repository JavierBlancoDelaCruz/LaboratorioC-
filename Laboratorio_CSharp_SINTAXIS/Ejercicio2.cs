using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_SINTAXIS
{
    internal class Ejercicio2
    {
        /* Ejercicio 2:
         * Solicite dos números y diga cual es el mayor.
         */
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Introduce un número: ");
                int numero1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Introduce otro número: ");
                int numero2 = Convert.ToInt32(Console.ReadLine());

                if (numero1 > numero2)
                {
                    Console.WriteLine("\nEl número mayor es: {0}", numero1);
                }
                else if (numero2 > numero1)
                {
                    Console.WriteLine("\nEl número mayor es: {0}", numero2);
                }
                else
                {
                    Console.WriteLine($"\nLos números {numero1} y {numero2} son iguales");
                }
            }
            catch (FormatException err) 
            {
                Console.WriteLine("\nERROR. " + err.Message + "\nPor favor, introduce solo números.");
            }
            

            Console.ReadLine();
        }
    }
}
