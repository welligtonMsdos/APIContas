using APIContas.Model;
using FluentValidation;

namespace APIContas.Data.ValidatorFluent;

public class PerfilValidator : AbstractValidator<Perfil>
{
    public PerfilValidator()
    {
        RuleFor(c => c.Descricao).NotEmpty().WithMessage("Descrição é obrigatório");
        RuleFor(c => c.Descricao).MinimumLength(5).WithMessage("Descrição necessário mínimo 5 caracteres");
        RuleFor(c => c.Descricao).MaximumLength(30).WithMessage("Descrição máximo 30 caracteres");
    }
}
