using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NorthWind.Entities.POCOEntities
{
    public class Archivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public double Tamanio { get; set; }
        public string Ubicacion { get; set; }
    }
}
