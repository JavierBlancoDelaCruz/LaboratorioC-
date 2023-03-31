using Laboratorio_CSharp_WEBAPI2.Models;
using System.Collections.Generic;

namespace Laboratorio_CSharp_WEBAPI2.Contracts
{
    public interface IAlmacen
    {
        List<Articulo> GetArticulos();
        void NuevoArticulo(Articulo articulo);
        void AumentarCantidad(int id, int cantidad);
        void DisminuirCantidad(int id, int cantidad);
    }
}
