using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_EXCEPCIONES
{
    /* Ejercicio 1:
     * 
     * Crear una aplicación de consola que genere un numero aleatorio.
     * La aplicación solicitará al usuario un número, en el caso de que el número introducido sea:
     *  - Mayor --> mostrará un mensaje: El número es más pequeño.
     *  - Menor --> mostrará un mensaje: El número es más grande.
     *  
     * El usuario dispondrá de 10 intentos para adivinar el número.
     * 
     * 1 – Controla las excepciones posibles que se pueden producir en la aplicación.
     * 2 – Crea una excepción personalizada para lanzarla cuando el número es mayor o menor.
     *   
     */
    internal class Ejercicio1
    {
        public class ExcepcionMayorMenor : Exception
        {
            public ExcepcionMayorMenor(string mensaje) : base(mensaje)
            {
                Console.WriteLine(mensaje); //Se lanzará el trow en el main y en el catch se pondrá un cojntinue para que siga la ejecución.
            }
        }

        public class ExcepcionFueraRango : Exception
        {
            public ExcepcionFueraRango(string mensaje) : base(mensaje)
            {
                Console.WriteLine(mensaje); //Se lanzará el trow en el main y en el catch se pondrá un cojntinue para que siga la ejecución.
            }
        }
        private static bool FueraRango(int num, int numMin, int numMax)
        {
            if (num >= numMin && num <= numMax)
            {
                return true; //Número dentro del rango
            }
            else 
            {
                throw new ExcepcionFueraRango($"\nNúmero fuera de rango. Debes introducir un número entre {numMin} y {numMax}.");
            }
        }


        static void Main(string[] args)
        {
            //Nº de intentos para adivinar el número:
            int intentos = 10;

            //Rango de números aleatorios:
            int min = 0;
            int max = 20;

            //Número aleatorio (sin semilla):
            Random random = new Random();
            var numero_secreto = random.Next(min, max + 1);


            Console.Write($"¿Crees que puedes adivinar el número entre {min} y {max} que estoy pensando? (Nº de intentos: {intentos})\n> ");

            bool correcto = false;
            for (var i = 1; i < intentos; i++)
            {
                try
                {
                    var numero = Convert.ToInt32(Console.ReadLine());
                    FueraRango(numero, min, max);

                    if (numero > numero_secreto)
                    {
                        throw new ExcepcionMayorMenor($"\nEl número es más pequeño.");
                    }
                    else if (numero < numero_secreto)
                    {
                        throw new ExcepcionMayorMenor($"\nEl número es más grande.");
                    }
                    else //(numero == numero_secreto)
                    {
                        Console.Write("\nCORRECTO!!\n");
                        correcto = true;
                        break;
                    }
                }
                catch (FormatException fe)
                {
                    Console.Write($"\nERROR: { fe.Message} \nVuelve a intentarlo (Intentos restantes: {intentos - i})\n> ");
                }
                catch (OverflowException oe)
                {
                    Console.Write("\nERROR: {0}", oe.Message + $"\nVuelve a intentarlo (Intentos restantes: {intentos - i})\n> ");
                }
                catch (ExcepcionMayorMenor)
                {
                    Console.Write($"Vuelve a intentarlo (Intentos restantes: {intentos - i})\n> ");
                    continue;
                }
                catch (ExcepcionFueraRango)
                {
                    Console.Write($"Vuelve a intentarlo (Intentos restantes: {intentos - i})\n> ");
                    continue;
                }
            }
            Console.ReadLine();

            string mensaje_final = correcto ? "Enhorabuena. :)\n" : "\nTe has quedado sin intentos... :(\nMás suerte la próxima vez.\n"; //Operador ternario
            Console.WriteLine(mensaje_final);
        }
    }
}
