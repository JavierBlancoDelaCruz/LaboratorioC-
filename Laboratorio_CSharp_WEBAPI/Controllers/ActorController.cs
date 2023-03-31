using Laboratorio_CSharp_WEBAPI.Contracts;
using Laboratorio_CSharp_WEBAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Laboratorio_CSharp_WEBAPI.Controllers //En nuestro controlador vamos a querer utilizar cualquier clase que implemente la interfaz (contrato), esta clase llegará por el constructor.
                                                //Aquí es donde vamos a introducir todas las rutas de la Api (URLs de los request)
{
    [Route("api/[controller]")] //Route es la ruta de acceso al controlador que estamos creando. Coge el nombre de la clase, por ejemplo WeatherForecast, y para poder acceder a mi endpoint habría que poner mi URL api/WeatherForecast
    [ApiController] //Este atributo ayuda a habilitar algunas características por defecto.

    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository; //Variable privada de solo lectura en nuestra clase, para poder utilizar los métodos de la interfaz dentro del controlador.
        public ActorController(IActorRepository actorRepository) //Se crea vacio escribiendo ctor y pulsando Tab.
        {
            _actorRepository = actorRepository; //Así se podrán utilizar los métodos de la interfaz dentro de este controlador.
        }

        //Ahora aquí se pondrán los métodos que se quieran usar de la interfaz:
        [HttpGet] //Cada vez que creamos un método dentro del controlador tenemos que poner el atributo del tipo de la acción que vamos a hacer. En este caso será HttpGet.
        public ActionResult<List<Actor>> GetAll()
        {
            return _actorRepository.GetActors(); //Devolverá una llamada al método GetActors() de nuestro repositorio [en Repositories, que es donde se implementarán las interfaces y sus métodos]
        }
        [HttpPost]
        public ActionResult CreateActor(Actor actor) //Nuevo método (no está en la interfaz) para añadir al actor en los datos de Actores.json mandando un POST al servidor.
        {
            try
            {
                _actorRepository.AddActor(actor);
                return Ok($"Nuevo actor añadido! - (Id:{actor.Id}, Nombre:{actor.Nombre})");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(":id")] //Si se le quita el ("...") Swagger no abrirá dando error por haber tipos de request igual! (No puede haber 2 veces [HttpGet], hay que variar la URL o dará error)
        public ActionResult<Actor> GetIdActor(int id) //No se pone GetIdActor([FromBody] int id) porque no procede del body, pero hay que ponerlo cuando sea string o int y sí esté en el body
        {
            try
            {
                return _actorRepository.GetActorById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult ModifyActor(Actor actor)
        {
            try
            {
                _actorRepository.UpdateActor(actor);
                return Ok($"Actor con Id = {actor.Id} ({actor.Nombre}) actualizado con exito!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete(":id")]
        public ActionResult DeleteActorById(int id)
        {
            try
            {
                _actorRepository.DeleteActor(id);
                return Ok($"Actor con id = {id} eliminado con exito!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
