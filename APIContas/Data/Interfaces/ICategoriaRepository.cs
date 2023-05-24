using APIContas.Model;

namespace APIContas.Data.Interfaces;

public interface ICategoriaRepository:IQuery<Categoria>, ICommand<Categoria> 
{

}

