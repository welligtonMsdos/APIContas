using APIContas.Model;
using FluentValidation;

namespace APIContas.Data.ValidatorFluent;

public class UsuarioValidator : AbstractValidator<Usuario>
{
    public UsuarioValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage("Descrição é obrigatório");
        RuleFor(c => c.Nome).MinimumLength(3).WithMessage("Descrição necessário mínimo 3 caracteres");
        RuleFor(c => c.Nome).MaximumLength(30).WithMessage("Descrição máximo 30 caracteres");

        RuleFor(c => c.Senha).NotEmpty().WithMessage("Senha é obrigatório");

        RuleFor(c => c.PerfilId).NotEmpty().WithMessage("Perfil é obrigatório");
        RuleFor(c => c.PerfilId).GreaterThan(0).WithMessage("Selecione um perfil");
    }
}
