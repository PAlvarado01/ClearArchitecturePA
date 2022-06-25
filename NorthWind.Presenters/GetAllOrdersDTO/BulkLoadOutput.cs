using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Presenters.GetAllOrdersDTO
{
    public class BulkLoadOutput
    {
        public List<File> File { get; set; }
    }
    public class File
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public double Tamanio { get; set; }
        public string Ubicacion { get; set; }
    }
}
