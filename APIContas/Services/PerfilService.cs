using APIContas.Data.Interfaces;
using APIContas.Enum;
using APIContas.Model;

namespace APIContas.Services;

public class PerfilService : IPerfilService
{
    private readonly IPerfilRepository _repository;

    public PerfilService(IPerfilRepository repository) => (_repository) = (repository);

    public async Task<bool> Alterar(Perfil entity)
    {
        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        var entidade = await _repository.BuscarPorId(entity.Id);

        if (!entidade.Ativo) throw new Exception(EMensagem.ELEMENTO_INATIVADO);

        return await _repository.Alterar(entity);
    }

    public async Task<bool> Ativar(Perfil entity)
    {
        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Ativar(entity);
    }

    public async Task<Perfil> BuscarPorId(int id)
    {
        if (id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.BuscarPorId(id);
    }

    public async Task<ICollection<Perfil>> BuscarPorValores(string values)
    {
        return await _repository.BuscarPorValores(values);
    }

    public async Task<ICollection<Perfil>> BuscarTodos()
    {
        return await _repository.BuscarTodos();
    }

    public async Task<bool> Excluir(Perfil entity)
    {
        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Excluir(entity);
    }

    public async Task<bool> Inativar(Perfil entity)
    {
        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Inativar(entity);
    }

    public async Task<bool> Incluir(Perfil entity)
    {
        entity.Ativo = true;

        return await _repository.Incluir(entity);
    }
}
