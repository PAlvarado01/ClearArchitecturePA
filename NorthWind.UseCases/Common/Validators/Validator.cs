using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.UseCases.Common.Validators
{
    public static class Validator<Model>
    {
        public static Task<List<ValidationFailure>> Validate(Model model, IEnumerable<IValidator<Model>> validators, bool causesException = false)
        {
            var failures = validators
               .Select(s => s.Validate(model))
               .SelectMany(m => m.Errors)
               .Where(f => f != null)
               .ToList();

            if (failures.Any() && causesException)
            {
                throw new ValidationException(failures);
            }
            return Task.FromResult(failures);
            //bulkload
        }
    }
}
