using APIContas.Model;

namespace APIContas.Data.Interfaces;

public interface IContaRepository:IQuery<Conta>,ICommand<Conta>
{
    ICollection<Conta> BuscarTotalPorMes(int numeroMes);
}
