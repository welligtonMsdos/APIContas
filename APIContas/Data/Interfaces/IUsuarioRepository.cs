using APIContas.Model;

namespace APIContas.Data.Interfaces;

public interface IUsuarioRepository: IQuery<Usuario>, ICommand<Usuario>
{   
}
