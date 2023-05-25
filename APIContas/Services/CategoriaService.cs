using APIContas.Data.Interfaces;
using APIContas.Enum;
using APIContas.Model;

namespace APIContas.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repository;   

    public CategoriaService(ICategoriaRepository repository) => (_repository) = (repository);

    public async Task<bool> Alterar(Categoria entity)
    {
        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Alterar(entity);
    }

    public async Task<Categoria> BuscarPorId(int id)
    {
        if (id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.BuscarPorId(id);
    }

    public async Task<ICollection<Categoria>> BuscarPorValores(string values)
    {
        return await _repository.BuscarPorValores(values);
    }

    public async Task<ICollection<Categoria>> BuscarTodos()
    {
        return await _repository.BuscarTodos();
    }

    public async Task<bool> Excluir(Categoria entity)
    {
        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Excluir(entity);
    }

    public async Task<bool> Incluir(Categoria entity)
    {
        entity.Ativo = true;

        return await _repository.Incluir(entity);
    }
}
