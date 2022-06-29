using System.Collections.Generic;

namespace NorthWind.UseCasesDTOs.BulkLoad
{
    public class BulkLoadOutputPort
    {
        public List<BulkLoad> Files { get; set; }
    }

    public class BulkLoad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public double Tamanio { get; set; }
        public string Ubicacion { get; set; }

        public BulkLoad(int id,string name, string extension, double tamanio, string ubicacion) { Id = id; Nombre = name; Extension= extension; Tamanio = tamanio; Ubicacion = ubicacion; }
    }
}
