using FluentValidation;
using Project.Test.Domain.Entity;
using System;

namespace Project.Test.Domain.Validation
{
    public class ManobristaValidation : AbstractValidator<Manobrista>
    {
        public ManobristaValidation()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(x => { throw new ArgumentNullException("Manobrista não encontrado."); });

            RuleFor(c => c.Nome).NotEmpty().NotNull().Length(3, 255).WithMessage("Informe o Nome do Manobrista.");

            RuleFor(c => c.CPF).NotEmpty().NotNull().Length(11).WithMessage("Informe o CPF do Manobrista.");

            RuleFor(c => c.DataNascimento).Must(BeAValidDate).WithMessage("Informe a Data de Nascimento válida.");
        }

        protected static bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}