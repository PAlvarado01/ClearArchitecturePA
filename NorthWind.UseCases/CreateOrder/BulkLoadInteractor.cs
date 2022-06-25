using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.UseCasesDTOs.BulkLoad;
using NorthWind.UseCasesPorts.BulkLoad;
using NorthWind.Entities.Exceptions;

namespace NorthWind.UseCases.CreateOrder
{
    public class BulkLoadInteractor: IBulkLoadInputPort
    {
        readonly IBulkLoadOutputPort outputPort;

        public BulkLoadInteractor(IBulkLoadOutputPort outputPort)
        {
            this.outputPort = outputPort;
        }      

        public async Task Handle(IFormFile file)
        {
            var output = new BulkLoadOutputPort();
            try
            {
                var filePath = "C:\\Images\\" + file.FileName;
                using (var stream = File.Create(filePath))
                {
                    file.CopyToAsync(stream);
                }
                double tamanio = file.Length;
                tamanio = tamanio / 1000000;
                tamanio = Math.Round(tamanio,2);

                var Files = new Archivo
                {
                    Id = 1,
                    Nombre = Path.GetFileNameWithoutExtension(file.FileName),
                    Extension = Path.GetExtension(file.FileName).Substring(1),
                    Tamanio = tamanio,
                    Ubicacion = filePath
                };
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error creating order", ex.Message);
            }
            await outputPort.Handle(output);
        }

    }
}
