using APIContas.Model;

namespace APIContas.Data.Interfaces;

public interface IContaService: IQuery<Conta>,ICommand<Conta>
{
    ICollection<Conta> BuscarTotalPorMes(int numeroMes);
}
