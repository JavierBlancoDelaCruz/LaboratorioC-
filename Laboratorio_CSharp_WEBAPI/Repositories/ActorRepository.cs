using Laboratorio_CSharp_WEBAPI.Contracts;
using Laboratorio_CSharp_WEBAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Laboratorio_CSharp_WEBAPI.Repositories
{
    public class ActorRepository : IActorRepository //Aquí [en Repositories/] se implementará la interfaz (contrato) [creada en Contracts/], heredándola y definiendo sus métodos que tenía creados.
    {
        //Para poder acceder a los datos de Resources/Actores.json hay que encontrar dónde están sabiendo su full path y hacer un método para poder leer el JSON como si fuera un string
        const string JSON_PATH = @"C:\Users\eljav\source\repos\Laboratorio_CSharp\Laboratorio_CSharp_WEBAPI\Resources\Actores.json"; //Se crea una variable constante y se le pone @ para leer literalmene sin problemas con el caracter ª\ª.

        private string GetActorsFromFile()
        {
            var strJSON = File.ReadAllText(JSON_PATH); //File.ReadAllText() leerá un json como si fuera un string.
            return strJSON;
        }

        //Métodos implementados de la interfaz:
        public List<Actor> GetActors()
        {
            try
            {
                var actoresFromFile = GetActorsFromFile(); //Cogerá la lista json de actores en tipo string.
                List<Actor> listActores = JsonConvert.DeserializeObject<List<Actor>>(actoresFromFile); //Convertir string en un listado de actores (Listz<Actores>)
                return listActores;
            }
            catch
            {
                throw;
            }
        }

        private void UpdateActors(List<Actor> listActores) //Nuevo método (no está en la interfaz) de escritura donde se pasa la lista de actores en string a JSON (serializar).
        {
            var actoresJson = JsonConvert.SerializeObject(listActores, Formatting.Indented); //Se pasa la lista de actores en string a JSON y se le da su formato.
            File.WriteAllText(JSON_PATH, actoresJson); //Se sobreescribe los datos de Actores.json por los nuevos
        }


        public void AddActor(Actor actor) //Se rellenará una estructura actor con formato Actor.json 
        {
            var listActores = GetActors(); //Devuelve un string convertido en List<Actor> con los datos de los Actores.json deserializados (string)
            var existeActor = listActores.Exists(a => a.Id == actor.Id);
            if (existeActor)
            {
                throw new Exception("Ya existe un actor con id = " + actor.Id);
            }
            listActores.Add(actor);
            UpdateActors(listActores);

        }
        public Actor GetActorById(int id)
        {
            var actores = GetActors(); //Datos deserializados (string)
            var actorDeterminado = actores.FirstOrDefault(a => a.Id == id); //Devuelve el 1º elemento (con toda su estructura) que encuentra con esa condición, y si no encuentra devolverá null
            if (actorDeterminado == null)
            {
                throw new Exception("No existe ningún actor con id = " + id);
            }
            //Actor actor = (Actor)(from Actor act in actores
            //              where act.Id ==  id
            //              select act);
            return actorDeterminado;
        }
        public void UpdateActor(Actor actor) //actor será lo que se le escriba desde cero (con estructura de Actor.json) para mandar.
        {
            var actores = GetActors(); //Datos deserializados (string)
            var actorDeterminado = actores.FirstOrDefault(a => a.Id == actor.Id); 
            if (actorDeterminado == null)
            {
                throw new Exception("No existe ningún actor con id = " + actor.Id);
            }

            actorDeterminado.Nombre = actor.Nombre;
            actorDeterminado.Apellido = actor.Apellido;
            actorDeterminado.Peliculas = actor.Peliculas;

            UpdateActors(actores); //Para serializar los datos antes de guardarlos (pasar a formato JSON)
        }
        public void DeleteActor(int id)
        {
            var actores = GetActors(); //Datos deserializados (string)
            var actorDeterminado = actores.FirstOrDefault(a => a.Id == id);
            if (actorDeterminado == null)
            {
                throw new Exception("No existe ningún actor con id = " + id);
            }

            actores.Remove(actorDeterminado);

            UpdateActors(actores);
        }

       

        
    }
}
