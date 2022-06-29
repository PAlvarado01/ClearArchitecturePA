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
using NorthWind.Entities.Specifications;

namespace NorthWind.UseCases.CreateOrder
{
    public class BulkLoadInteractor: IBulkLoadInputPort
    {
        readonly IBulkLoadOutputPort outputPort;
        readonly IUnitOfWork unitOfWork;
        readonly IBulkLoadRepository bulkLoadRepository;

        public BulkLoadInteractor(IBulkLoadOutputPort outputPort, IUnitOfWork unitOfWork, IBulkLoadRepository bulkLoadRepository)
        {
            this.outputPort = outputPort;
            this.unitOfWork = unitOfWork;
            this.bulkLoadRepository = bulkLoadRepository;
        }      

        public async Task Handle(IFormFile file)
        {
            var output = new BulkLoadOutputPort();

            var filePath = "C:\\Images\\" + file.FileName;

            using (var stream = File.Create(filePath))
            {
                file.CopyToAsync(stream);
            }

            double tamanio = file.Length;
            tamanio = tamanio / 1000000;
            tamanio = Math.Round(tamanio, 2);

            var Files = new Archivo
            {
                Nombre = Path.GetFileNameWithoutExtension(file.FileName),
                Extension = Path.GetExtension(file.FileName).Substring(1),
                Tamanio = tamanio,
                Ubicacion = filePath
            };

            bulkLoadRepository.Create(Files);
            
            //Leer Archivo
            StreamReader sr = new StreamReader(filePath);

            string line = sr.ReadLine();
            string[] separar = line.Split(new char[] { ' ' });

            /*foreach (string palabra in separar)
            {
                Console.WriteLine(palabra);
            }*/

            TextReader Leer = new StreamReader(line);

            Console.WriteLine(Leer.ReadToEnd());

            bulkLoadRepository.Upload(file.FileName, Files.ToString(), "C:\\Images\\");

            try
            {                
                await unitOfWork.SaveChangesAsync();

                output.Files = new List<BulkLoad>();

                var expressionBulkLoad = new Specification<Archivo>(od=> od.Id==Files.Id);
                var archivoBulk = bulkLoadRepository.GetBulkLoadByEspecification(expressionBulkLoad).ToList();
                var archivoId = archivoBulk.Select(p => p.Id).ToList();

                foreach (var id in archivoId)
                {
                    var files = archivoBulk
                        .Where(s => s.Id == id)
                        .Select(s => new BulkLoad(
                            s.Id,
                            s.Nombre,
                            s.Extension,
                            s.Tamanio,
                            s.Ubicacion
                            ))
                        .FirstOrDefault();

                    output.Files.Add(files);
                }
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error creating order", ex.Message);
            }

            await outputPort.Handle(output);
        }

    }
}
