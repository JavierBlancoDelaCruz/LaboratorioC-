using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laboratorio_CSharp_TESTUNITARIO_programa
{
    /* Ejercicio 1:
     * Crear una aplicación de consola que tiene como funcionalidad solicitar al usuario un correo electrónicoy comprobará si es válido.
     * La aplicación seguirá solicitando correos al usuario hasta que se escriba como correo electrónico el comando "quit".
     */
    public class Correo
    {
        public bool Validar1(string correo)
        {
            var formato = @"^[a-zA-Z0-9_.]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$"; //EXPRESIÓN REGULAR: buscará una o más apariciones de [letras, números, barras bajas o puntos] seguido de un @  y luego una o varias apariciones de [letras] seguido de un . y luego una o varias apariciones de [letras]

            Regex expresion = new(formato); //Como poner new Regex(formato), no hace falta porqu ya se indica el tipo que será la variable
            bool correcto = expresion.IsMatch(correo);

            if (correcto)
            {
                //Console.WriteLine("El correo introducido es válido.");
                return true;
            }
            return false;
        }


        /* Ejercicio 2:
         * Modificamos el ejercicio anterior para ir almacenando los correos electrónicos en memoria y en el caso
         * de que el usuario introduzca un correo repetido mostrar el siguiente mensaje:
         *      "Ya se ha validado el correo electrónico".
         */
        public bool Validar2(string correo, List<string> listaCorreos)
        {
            if (listaCorreos.Contains(correo)) //Si se repite el correo introducido
            {
                Console.WriteLine("Ya se ha validado el correo electrónico.");
                return true; //true porque el correo es válido igualmente.
            }

            var formato = @"^[a-zA-Z0-9_.]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$";

            Regex expresion = new(formato);
            bool correcto = expresion.IsMatch(correo);

            if (correcto)
            {
                //Console.WriteLine("El correo introducido es válido.");
                listaCorreos.Add(correo);
                return true;
            }
            //correosValidados.Add(correo); //No tendría sentido almacenar todos los correos incluyendo los inválidos, pero si se quisiera hacer se pondría el .Add() aquí en lugar de en el if..
            return false;
        }
    }
}