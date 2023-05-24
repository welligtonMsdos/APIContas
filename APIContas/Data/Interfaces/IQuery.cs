using Microsoft.VisualBasic;

namespace APIContas.Data.Interfaces;

public interface IQuery<T>
{
    Task<ICollection<T>> BuscarTodos();
    Task<ICollection<T>> BuscarPorValores(string values);
    Task<T> BuscarPorId(int id);    
}
