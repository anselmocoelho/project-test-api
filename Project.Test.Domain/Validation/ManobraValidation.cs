using FluentValidation;
using Project.Test.Domain.Entity;
using System;

namespace Project.Test.Domain.Validation
{
    public class ManobraValidation : AbstractValidator<Manobra>
    {
        public ManobraValidation()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(x => { throw new ArgumentNullException("Manobra não encontrada."); });

            RuleFor(c => c.CarroId).NotNull().NotEqual(Guid.Empty);

            RuleFor(c => c.ManobristaId).NotNull().NotEqual(Guid.Empty);
        }
    }
}