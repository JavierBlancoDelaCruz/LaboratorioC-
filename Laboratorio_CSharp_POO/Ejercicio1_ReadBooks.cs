using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_POO
{
    /* Ejercicio1 - Read Books:
     * 
     * Crea una función isBookRead que reciba una lista de libros y un título y devuelva si se ha leído o no dicho libro.
     * Un libro es un objeto con title como string y isRead como booleano. En caso de no existir el libro devolver false.
     * 
     */

    public class Book
    {
        public string Title;
        public bool IsRead;


        //CONSTRUCTOR SIN PARÁMETROS
        public Book()
        {
            Title = "Por defecto";
            IsRead = true;
        }

        //CONSTRUCTOR CON PARÁMETROS
        public Book(string title, bool isRead) //Si se quisieran inicializar con 2 argumentos 
        {
            Title = title;
            IsRead = isRead;
        }
    }

    internal class Ejercicio1_ReadBooks
    {

        public static bool IsBookRead(Book[] books, string titleToSearch)
        {
            for (int i = 0; i<books.Length; i++) // (Con un foreach sería más limpio)
            {
                if (books[i].Title == titleToSearch)
                {
                    return books[i].IsRead;
                }
            }
            return false; //Si no existe ningún libro con ese título.
        }

        static void Main(string[] args)
        {
            //Lista de libros de tipo Book:
            var lista_libros = new Book[] {
                //Inicialización con NUEVOS VALORES
                new Book
                {
                    Title = "El día que se perdió la cordura",
                    IsRead = true
                },
                new Book
                {
                    Title = "La estación",
                    IsRead = false
                },

                //Instanciación con VALORES POR DEFECTO (CONTRUCOR SIN PARÁMETROS)
                new Book(),

                //Instanciación con NUEVOS VALORES (CONTRUCOR CON PARÁMETROS)
                new Book("Hola", true),
                new Book("Adios", false)
            };

            Console.WriteLine("Libro 'El día que se perdió la cordura' leido? - " + IsBookRead(lista_libros, "El día que se perdió la cordura")); // true
            Console.WriteLine("Libro 'La estación' leido? - " + IsBookRead(lista_libros, "La estación")); // false
            Console.WriteLine("Libro 'Por defecto' leido? - " + IsBookRead(lista_libros, "Por defecto")); // true
            Console.WriteLine("Libro 'Hola' leido? - " + IsBookRead(lista_libros, "Hola")); // true
            Console.WriteLine("Libro 'Adios' leido? - " + IsBookRead(lista_libros, "Adios")); // false
            Console.WriteLine("Libro 'Inexistente' leido? - " + IsBookRead(lista_libros, "Inexistente")); // false --> Este libro NO lo encontrará en la lista

            Console.ReadLine();
        }
    }
}
