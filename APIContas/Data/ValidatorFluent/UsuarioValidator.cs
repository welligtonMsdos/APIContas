using APIContas.Model;
using FluentValidation;

namespace APIContas.Data.ValidatorFluent;

public class UsuarioValidator : AbstractValidator<Usuario>
{
    public UsuarioValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        RuleFor(c => c.Nome).MinimumLength(3).WithMessage("Nome necessário mínimo 3 caracteres");
        RuleFor(c => c.Nome).MaximumLength(30).WithMessage("Nome máximo 30 caracteres");

        RuleFor(c => c.Senha).NotEmpty().WithMessage("Senha é obrigatória");       

        RuleFor(c => c.PerfilId).NotEmpty().WithMessage("Perfil é obrigatório");
        RuleFor(c => c.PerfilId).GreaterThan(0).WithMessage("Selecione um perfil");
    }
}
