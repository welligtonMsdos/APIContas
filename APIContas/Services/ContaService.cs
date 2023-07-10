using APIContas.Data.Interfaces;
using APIContas.Enum;
using APIContas.Model;

namespace APIContas.Services;

public class ContaService : IContaService
{
    private readonly IContaRepository _repository;

    public ContaService(IContaRepository repository) => (_repository) = (repository);

    public async Task<bool> Alterar(Conta entity)
    {
        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Alterar(entity);
    }

    public async Task<Conta> BuscarPorId(int id)
    {
        if (id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.BuscarPorId(id);
    }

    public async Task<ICollection<Conta>> BuscarPorValores(string values)
    {
        return await _repository.BuscarPorValores(values);
    }

    public async Task<ICollection<Conta>> BuscarTodos()
    {
        return await _repository.BuscarTodos();
    }

    public ICollection<Conta> BuscarTotalPorMes(int numeroMes)
    {
        return _repository.BuscarTotalPorMes(numeroMes);
    }

    public async Task<bool> Excluir(Conta entity)
    {
        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Excluir(entity);
    }

    public async Task<bool> Incluir(Conta entity)
    {
        entity.Ativo = true;

        return await _repository.Incluir(entity);
    }   
}
