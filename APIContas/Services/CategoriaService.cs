using APIContas.Data.Interfaces;
using APIContas.Enum;
using APIContas.Model;
using AutoMapper;

namespace APIContas.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repository;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);
    
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
}
