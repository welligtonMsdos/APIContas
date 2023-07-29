namespace APIContas.Data.Interfaces;

public interface ICommand<T>
{
    Task<bool> Incluir(T entity);
    Task<bool> Alterar(T entity);
    Task<bool> Excluir(T entity);
    Task<bool> Inativar(T entity);
    Task<bool> Ativar(T entity);
}
