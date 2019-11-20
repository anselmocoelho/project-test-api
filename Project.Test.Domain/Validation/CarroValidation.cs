using FluentValidation;
using Project.Test.Domain.Entity;
using System;

namespace Project.Test.Domain.Validation
{
    public class CarroValidation : AbstractValidator<Carro>
    {
        public CarroValidation()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(x => { throw new ArgumentNullException("Carro não encontrado."); });

            RuleFor(c => c.Marca).NotEmpty().NotNull().Length(3, 255).WithMessage("Informe a Marca do Carro.");

            RuleFor(c => c.Modelo).NotEmpty().NotNull().Length(3, 255).WithMessage("Informe o Modelo do Carro.");

            RuleFor(c => c.Placa).NotEmpty().NotNull().Length(8).WithMessage("Informe a Placa do Carro.");
        }
    }
}