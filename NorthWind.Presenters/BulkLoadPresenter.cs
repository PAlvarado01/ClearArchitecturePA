using NorthWind.UseCasesDTOs.BulkLoad;
using NorthWind.UseCasesPorts.BulkLoad;
using NorthWind.Presenters.GetAllOrdersDTO;
using System.Threading.Tasks;
using System.Linq;


namespace NorthWind.Presenters
{
    public class BulkLoadPresenter : IBulkLoadOutputPort, IPresenter<BulkLoadOutput>
    {
        public BulkLoadOutput Content { get; private set; }

        public Task Handle(BulkLoadOutputPort outputPort)
        {
            var archivos = outputPort.Files
                .Select(s => new File
                {
                    Id =s.Id,
                    Nombre = s.Nombre,
                    Extension = s.Extension,
                    Tamanio = s.Tamanio,
                    Ubicacion = s.Ubicacion
                }).ToList();

            Content = new BulkLoadOutput()
            {
                File = archivos
            };

            return Task.CompletedTask;
        }
    }
}
