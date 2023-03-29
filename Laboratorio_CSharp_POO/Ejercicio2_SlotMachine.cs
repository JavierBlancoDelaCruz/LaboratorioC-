using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_POO
{
    /* Ejercicio2 - Slot Machine:
     * 
     * Crear una máquina tragaperras utilizando clases donde cada vez que juguemos insertemos una moneda.
     * Cada máquina tragaperras (instancia) tendrá un contador de monedas que automáticamente se irá incrementando conforme vayamos jugando.
     * 
     * Cuando se llame al método play el número de monedas se debe incrementar de forma automática y debe generar tres booleanos aleatorios
     * que representarán el estado de las 3 ruletas.
     * 
     * El usuario habrá ganado en caso de que los tres booleanos sean true, y por tanto deberá
     * mostrarse por consola el mensaje:
     *      "Congratulations!!!. You won <número de monedas> coins!!";
     * y reiniciar las monedas almacenadas, ya que las hemos conseguido y han salido de la máquina.
     * En caso contrario deberá mostrar otro mensaje:
     *      "Good luck next time!!".
     *      
     *      
     * Se preguntará al usuario si quiere jugar o dejar.
     * -    Si el usuario elige jugar. Se llamará al método play.
     * -    Si usuario elige cualquier otra opción se terminará la ejecución de la aplicación.
     * 
     */

    public class Maquina
    {
        public int Monedas;

        //Métodos 
        public void Play()
        {
            Monedas = Monedas +1;

            //Estado de las tres ruletas:
            Random random = new Random();
            //(3 formas de hacer lo mismo)
            bool ruleta1 = random.Next(0,2) == 1 ? true : false; //Utilizando operador ternario, si es == 1 dará true, si no dará false.
            bool ruleta2 = random.Next(0, 2) == 1; //Si es 1 dará true, si no dará false.
            bool ruleta3 = random.Next(2) == 1; //Dará entre 0 y 1, y si es 1 dará true, si no dará false.

            Console.WriteLine("\n----------------------------------------------------");
            Console.WriteLine("\nBote: " + Monedas);
            Console.WriteLine($"Ruletas: {ruleta1} | {ruleta2} | {ruleta3}\n");
            Console.WriteLine("----------------------------------------------------\n");

            if (ruleta1 && ruleta2 && ruleta3)
            {
                Console.WriteLine($"\nENHOBUENA!!!\nGanaste {Monedas} monedas!! :)");
                Monedas = 0;
            }
            else
            {
                Console.WriteLine("\nMás suerte la próxima vez!! :(");
            }
        }
    }

    internal class Ejercicio2_SlotMachine
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido/a.");
            var partida = new Maquina();

            while (true)
            {
                Console.Write("\n\nQué deseas hacer?\n1) Jugar (Insertando moneda)\n2) Salir\n(Inserta el número de la opción que elijas) > ");
                var opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion == 1)
                {
                    partida.Play();
                }
                else
                {
                    Console.WriteLine("\nHasta la próxima!");
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
