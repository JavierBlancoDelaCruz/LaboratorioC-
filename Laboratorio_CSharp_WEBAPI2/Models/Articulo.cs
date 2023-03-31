using System;

namespace Laboratorio_CSharp_WEBAPI2.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaEntrada { get; set; }
        public int Cantidad { get; set; }
    }
}
