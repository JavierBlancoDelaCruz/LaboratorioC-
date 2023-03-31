using Laboratorio_CSharp_WEBAPI2.Contracts;
using Laboratorio_CSharp_WEBAPI2.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laboratorio_CSharp_WEBAPI2.Repositories
{
    public class AlmacenRepository : IAlmacen
    {
        const string JSON_PATH = @"C:\Users\eljav\source\repos\Laboratorio_CSharp\Laboratorio_CSharp_WEBAPI2\Resources\Articulos.json";
        private string GetArticulosFromResources()
        {
            var datosjsonSTR = File.ReadAllText(JSON_PATH);
            return datosjsonSTR;
        }

        public List<Articulo> GetArticulos()
        {
            try
            {
                var articulosFomResorces = GetArticulosFromResources();
                List<Articulo> listArticulos = JsonConvert.DeserializeObject<List<Articulo>>(articulosFomResorces);
                return listArticulos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void UpdateArticulos(List<Articulo> articulos)
        {
            var articulosJSON = JsonConvert.SerializeObject(articulos, Formatting.Indented);
            File.WriteAllText(JSON_PATH, articulosJSON);
        }
        public void NuevoArticulo(Articulo articulo)
        {
            var listArticulos = GetArticulos();
            var existeArticulo = listArticulos.Exists(a => a.Id == articulo.Id);
            if (existeArticulo)
            {
                throw new Exception("Ya existe un articulo con id = " + articulo.Id);
            }
            listArticulos.Add(articulo);
            UpdateArticulos(listArticulos);
        }
        public void AumentarCantidad(int id, int cantidad)
        {
            var listArticulos = GetArticulos();
            var articulo = listArticulos.FirstOrDefault(a => a.Id == id);
            if (articulo == null)
            {
                throw new Exception("No existe el artículo con Id = " + id);
            }
            articulo.Cantidad += cantidad;
            UpdateArticulos(listArticulos);
        }

        public void DisminuirCantidad(int id, int cantidad)
        {
            var listArticulos = GetArticulos();
            var articulo = listArticulos.FirstOrDefault(a => a.Id == id);
            if (articulo.Cantidad < cantidad)
            {
                throw new Exception($"No hay suficiente género del producto con Id = {id} para retirar una cantidad de -{cantidad}");
            }
            articulo.Cantidad -= cantidad;
            UpdateArticulos(listArticulos);
        }
    }
}
