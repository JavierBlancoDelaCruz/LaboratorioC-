using Laboratorio_CSharp_LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_CSharp_LINQ
{
    /* Ejercicio 1:
     * 
     * Como primer paso, habrá que crear la clase Patient y la colección para almacenar dichos datos.
     * 
     * 1 - Extraer la lista de pacientes que sean de la especialidad pediatrics y que tengan menos de 10 años.
     * 2 - Queremos activar el protocolo de urgencia si hay algún paciente con ritmo cardíaco mayor que 100 o temperatura mayor a 39.
     * 3 - No podemos atender a todos los pacientes hoy por lo que vamos a crear una nueva coleccion y reasignar a los pacientes de pediatrics a general medicine
     * 4 - Queremos conocer de una sola consulta el numero de pacientes que estan asignado a general medicine y a pediatrics.
     * 5 - Devuelve una lista nueva que por cada paciente se indique si tiene prioridad o no.
     *     Se tendrá prioridad si el ritmo cardiaco es mayor 100 o la temperatura es mayor a 39.
     * 6 - Queremos conocer de una sola consulta La edad media de pacientes asignados a pediatrics y general medicine.
     *   
     */

    public class Patient
    {
        public int id;
        public string name;
        public string lastname;
        public string sex;
        public double temperature;
        public int heartRate;
        public string specialty;
        public int age;
    }

    internal class Ejercicio1
    {
        static void Main(string[] args)
        {
            //Lista de pacientes con sus datos:
            var pacientes = new Patient[]
            {
                new Patient
                {
                    id = 1,
                    name= "John",
                    lastname = "Doe",
                    sex = "Male",
                    temperature = 36.8,
                    heartRate =  80,
                    specialty = "general medicine",
                    age = 44,
                },
                new Patient
                {
                    id = 2,
                    name= "Jane",
                    lastname = "Doe",
                    sex = "Female",
                    temperature = 36.8,
                    heartRate =  70,
                    specialty = "general medicine",
                    age = 43,
                },
                new Patient
                {
                    id = 3,
                    name= "Junior",
                    lastname = "Doe",
                    sex = "Male",
                    temperature = 36.8,
                    heartRate =  90,
                    specialty = "pediatrics",
                    age = 8,
                },
                new Patient
                {
                    id = 4,
                    name= "Mary",
                    lastname = "Wien",
                    sex = "Female",
                    temperature = 36.8,
                    heartRate =  120,
                    specialty = "general medicine",
                    age = 20,
                },
                new Patient
                {
                    id = 5,
                    name= "Scarlett",
                    lastname = "Somez",
                    sex = "Female",
                    temperature = 36.8,
                    heartRate =  110,
                    specialty = "general medicine",
                    age = 30,
                },
                new Patient
                {
                    id = 6,
                    name= "Brian",
                    lastname = "Kid",
                    sex = "Male",
                    temperature = 39.8,
                    heartRate =  80,
                    specialty = "pediatrics",
                    age = 11,
                }
            };

            //1 - Extraer la lista de pacientes que sean de la especialidad pediatrics y que tengan menos de 10 años.
            Console.WriteLine("1- Lista de pacientes para la especialidad 'pediatrics' menores de 10 años:");
            var pac_pediatrics = pacientes.Where(e => e.specialty == "pediatrics" && e.age < 10).Select(p => $"- {p.name} ({p.age} años)");
            foreach (var pacs in pac_pediatrics)
                Console.WriteLine(pacs);

            //2 - Queremos activar el protocolo de urgencia si hay algún paciente con ritmo cardíaco mayor que 100 o temperatura mayor a 39.
            Console.WriteLine("\n2- Lista de protocolos de urgencia para pacientes con ritmo cardíaco > 100 o temperatura > 39:");
            var pac_urgencia = pacientes.Where(u => u.heartRate > 100 || u.temperature > 39);
            foreach (var pacs in pac_urgencia)
                Console.WriteLine($"- {pacs.name} - heartRate:{pacs.heartRate}, temperature:{pacs.temperature}");

            //3 - No podemos atender a todos los pacientes hoy por lo que vamos a crear una nueva coleccion y reasignar a los pacientes de pediatrics a general medicine
            Console.WriteLine("\n3- Lista de pacientes de 'pediatrics' reasigados a 'general medicine':");
            Console.WriteLine("Lista 'pacientes' normal:");
            foreach (var pacs in pacientes)
                Console.WriteLine($"- {pacs.id}: {pacs.name}, {pacs.lastname} (age:{pacs.age}, {pacs.sex}) - {pacs.specialty}");
            //* Forma 1 de hacerlo (dará problemas si se ejecuta junto a los demás ejercicios por cambiar el valor original de la lista pacientes):
            //var pac_reasignados = pacientes.Where(r => r.specialty == "pediatrics");
            //Console.WriteLine("Sin reasignar:");
            //foreach (var pacs in pac_reasignados)
            //    Console.WriteLine($"- {pacs.id}: {pacs.name}, {pacs.lastname} (age:{pacs.age}, {pacs.sex}) - {pacs.specialty}");
            //Console.WriteLine("Reasignados:");
            //foreach (var pacs in pac_reasignados)
            //    Console.WriteLine($"- {pacs.id}: {pacs.name}, {pacs.lastname} (age:{pacs.age}, {pacs.sex}) - {pacs.specialty = "general medicine"}");
            //* Forma 2 de hacerlo (no dará errores si se ejecuta junto a ejercicios posteriores porque no toca la lista original de pacientes)
            var pac_reasignados = pacientes.Select(r => r.specialty == "pediatrics" ? new Patient { id = r.id, name = r.name, lastname = r.lastname, sex = r.sex, temperature = r.temperature, heartRate = r.heartRate, specialty = "general medicine", age = r.age } : r).ToList();
            Console.WriteLine("Reasignados en lista 'pac_reasignados':");
            foreach (var pacs in pac_reasignados)
                Console.WriteLine($"- {pacs.id}: {pacs.name}, {pacs.lastname} (age:{pacs.age}, {pacs.sex}) - {pacs.specialty}");
            //Console.WriteLine("Lista 'pacientes' tras reasignado:");
            //foreach (var pacs in pacientes)
            //    Console.WriteLine($"- {pacs.id}: {pacs.name}, {pacs.lastname} (age:{pacs.age}, {pacs.sex}) - {pacs.specialty}");

            //4 - Queremos conocer de una sola consulta el numero de pacientes que estan asignado a general medicine y a pediatrics.
            Console.WriteLine("\n4- Número de pacientes asignados a 'general medicine' y a 'pediatrics':");
            var pac_asignados = pacientes.Where(a => a.specialty == "general medicine" || a.specialty == "pediatrics").GroupBy(a => a.specialty).Select(a => $"- {a.Key}: {a.Count()}");
            foreach (var pacs in pac_asignados)
                Console.WriteLine(pacs);

            //5 - Devuelve una lista nueva que por cada paciente se indique si tiene prioridad o no.
            //    Se tendrá prioridad si el ritmo cardiaco es mayor 100 o la temperatura es mayor a 39.
            Console.WriteLine("\n5- Nueva lista de pacientes indicando si tienen prioridad:");
            //var pac_prioridad = pacientes.Select(p => p.id + p.name + p.lastname + p.sex + p.temperature + p.heartRate + p.specialty + p.age).ToList(); //Con .Select() se crea una lista de cadenas con lo que se seleccione!
            var pac_prioridad = pacientes.Select(p => $"- {p.id}: {p.name}, {p.lastname} (age:{p.age}, {p.sex}) - {p.specialty} - (heartRate: {p.heartRate}, temperature: {p.temperature}) " + (p.heartRate > 100 || p.temperature > 39 ? $"- [PRIORIDAD]" : "")).ToList();
            foreach (string pacs in pac_prioridad)
                Console.WriteLine(pacs);

            //6 - Queremos conocer de una sola consulta La edad media de pacientes asignados a pediatrics y general medicine.
            Console.WriteLine("\n6- Edad media de pacientes asignados a 'general medicine' y a 'pediatrics':");
            var pac_edad = pacientes.Where(a => a.specialty == "general medicine" || a.specialty == "pediatrics").GroupBy(a => a.specialty).Select(a => $"- {a.Key}: {a.Average(e => e.age)} años");
            foreach (var pacs in pac_edad)
                Console.WriteLine(pacs);
        }
    }
}
