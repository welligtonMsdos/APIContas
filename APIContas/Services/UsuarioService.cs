using APIContas.Data.Interfaces;
using APIContas.Data.ValidatorFluent;
using APIContas.Enum;
using APIContas.Model;
using FluentValidation;
using FluentValidation.Results;

namespace APIContas.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository) => (_repository) = (repository);

    public async Task<bool> Alterar(Usuario entity)
    {
        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        ValidationResult validResult = new UsuarioValidator().Validate(entity);

        string[] erros = validResult.ToString("~").Split('~');

        if (!validResult.IsValid) throw new Exception("error" + erros[0]);

        return await _repository.Alterar(entity);
    }

    public async Task<bool> Ativar(Usuario entity)
    {
        if (entity == null) throw new Exception(EMensagem.IS_NULL);

        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Ativar(entity);
    }

    public async Task<Usuario> BuscarPorId(int id)
    {
        if (id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.BuscarPorId(id);
    }

    public async Task<ICollection<Usuario>> BuscarPorValores(string values)
    {
        return await _repository.BuscarPorValores(values);
    }

    public async Task<ICollection<Usuario>> BuscarTodos()
    {
        return await _repository.BuscarTodos();
    }

    public async Task<bool> Excluir(Usuario entity)
    {
        if (entity == null) throw new Exception(EMensagem.IS_NULL);

        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Excluir(entity);
    }

    public async Task<bool> Inativar(Usuario entity)
    {
        if (entity == null) throw new Exception(EMensagem.IS_NULL);

        if (entity.Id == 0) throw new Exception(EMensagem.ID_ZERADO);

        return await _repository.Inativar(entity);
    }

    public async Task<bool> Incluir(Usuario entity)
    {
        ValidationResult validResult = new UsuarioValidator().Validate(entity);

        string[] erros = validResult.ToString("~").Split('~');

        if (!validResult.IsValid) throw new Exception("error" + erros[0]);

        return await _repository.Incluir(entity);
    }
}
