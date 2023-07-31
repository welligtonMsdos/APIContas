using APIContas.Model;

namespace APIContas.Data.Interfaces;

public interface IPerfilService : IQuery<Perfil>, ICommand<Perfil>
{
}
