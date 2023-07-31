using APIContas.Model;

namespace APIContas.Data.Interfaces;

public interface IUsuarioService : IQuery<Usuario>, ICommand<Usuario>
{
}
