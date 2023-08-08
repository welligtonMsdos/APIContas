using APIContas.Model;

namespace APIContas.Data.Interfaces;

public interface IUsuarioService : IQuery<Usuario>, ICommand<Usuario>
{
    Usuario BuscarPorNomeSenha(string nome, string senha);
}
