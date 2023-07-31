using APIContas.Model;
using FluentValidation;

namespace APIContas.Data.ValidatorFluent;

public class ContaValidator : AbstractValidator<Conta>
{
    public ContaValidator()
    {
        RuleFor(c => c.Descricao).NotEmpty().WithMessage("Descrição é obrigatório");
        RuleFor(c => c.Descricao).MinimumLength(5).WithMessage("Descrição necessário mínimo 5 caracteres");
        RuleFor(c => c.Descricao).MaximumLength(30).WithMessage("Descrição máximo 30 caracteres");

        RuleFor(c => c.Valor).NotEmpty().WithMessage("Valor é obrigatório");
        RuleFor(c => c.Valor).InclusiveBetween(1, 50000).WithMessage("Valor precisa estar entre R$ 1,00 e R$ 50.000,00");

        RuleFor(c => c.Mes).NotEmpty().WithMessage("Mês é obrigatório");
        RuleFor(c => c.Mes).InclusiveBetween(1, 12).WithMessage("Mês precisa estar entre 1 e 12");

        RuleFor(c => c.DataInclusao).NotEmpty().WithMessage("Data inclusão é obrigatória");       
    }
}
