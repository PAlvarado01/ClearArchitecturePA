using FluentValidation;
using NorthWind.Entities.POCOEntities;
using System.Linq;

namespace NorthWind.UseCases.Common.Validators
{
    public class BulkLoadValidator : AbstractValidator<Archivo>
    {
        public BulkLoadValidator()
        {
            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("You must provide the Nombre")
                .NotNull().WithMessage("El campo Nombre no puede ser null");

            RuleFor(c => c.Extension)
                .NotEmpty().WithMessage("You must provide the Extension")
                .NotNull().WithMessage("El campo Extension no puede ser null")
                .Matches(@"(xls|xlsx|txt)$").WithMessage("Solo permite Extensin xls, xlsx y txt");

            RuleFor(c => c.Tamanio)
                .NotEmpty().WithMessage("You must provide the Tamanio")
                .NotNull().WithMessage("El campo Tamanio no puede ser null");

            RuleFor(c => c.Ubicacion)
                .NotEmpty().WithMessage("You must provide the Ubicacion")
                .NotNull().WithMessage("El campo Ubicacion no puede ser null");
        }
    }
}
