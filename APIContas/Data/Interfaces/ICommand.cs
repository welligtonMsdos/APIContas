namespace APIContas.Data.Interfaces;

public interface ICommand<T>
{
    Task Incluir(T entity);
    Task Alterar(T entity);
    Task Excluir(T entity);
}
