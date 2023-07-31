using APIContas.Model;

namespace APIContas.Data.Interfaces;

public interface IPerfilRepository : IQuery<Perfil>, ICommand<Perfil>
{
}
