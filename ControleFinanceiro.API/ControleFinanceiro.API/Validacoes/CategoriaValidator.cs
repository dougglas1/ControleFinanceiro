using ControleFinanceiro.BLL.Models;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Nome)
                .NotNull().WithMessage("Informe o nome")
                .NotEmpty().WithMessage("Informe o nome")
                .MinimumLength(6).WithMessage("Mínimo 6 caracteres")
                .MaximumLength(50).WithMessage("Máximo 50 caracteres");

            RuleFor(c => c.Icone)
                .NotNull().WithMessage("Informe o ícone")
                .NotEmpty().WithMessage("Informe o ícone")
                .MinimumLength(1).WithMessage("Mínimo 1 caracteres")
                .MaximumLength(15).WithMessage("Máximo 15 caracteres");

            RuleFor(c => c.TipoId)
                .NotNull().WithMessage("Informe o tipo")
                .NotEmpty().WithMessage("Informe o tipo");
        }
    }
}
