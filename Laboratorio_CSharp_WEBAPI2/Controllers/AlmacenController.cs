using Laboratorio_CSharp_WEBAPI2.Contracts;
using Laboratorio_CSharp_WEBAPI2.Models;
using Laboratorio_CSharp_WEBAPI2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Laboratorio_CSharp_WEBAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        private readonly IAlmacen _almacenRepository;
        public AlmacenController(IAlmacen almacenRepository)
        {
            _almacenRepository = almacenRepository;
        }

        //Métodos:
        [HttpGet]
        public ActionResult<List<Articulo>> GetArticulos()
        {
            return _almacenRepository.GetArticulos();
        }

        [HttpPost("add")]
        public ActionResult AddArticulo(Articulo articulo)
        {
            try
            {
                _almacenRepository.NuevoArticulo(articulo);
                return Ok($"Nuevo articulo (Id: {articulo.Id} - {articulo.Nombre}) añadido al almacén con éxito!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("increment")]
        public ActionResult IncrementArticulo(int id, int cantidad)
        {
            try
            {
                _almacenRepository.AumentarCantidad(id, cantidad);
                return Ok($"El artículo con Id = {id} ha incrementado su cantidad en +{cantidad}!");
            }
            catch (Exception e)
            {
                return NotFound("No se encuentra el artículo con Id = " + id);
            }
        }
        [HttpPut("decrement")]
        public ActionResult DecrementArticulo(int id, int cantidad)
        {
            try
            {
                if (cantidad < 0)
                    return BadRequest("ERROR. Debes introducir números positivos.");

                _almacenRepository.DisminuirCantidad(id, cantidad);
                return Ok($"El artículo con Id = {id} ha decrementado su cantidad en -{cantidad}...");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //Lanzará el mensaje que hay en el throw new Exception de DisminuirCantidad() en AlmacenRepository.cs
            }
        }
    }
}
