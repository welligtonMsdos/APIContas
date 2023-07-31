using APIContas.Data.Context;
using APIContas.Data.Interfaces;
using APIContas.Model;
using Microsoft.EntityFrameworkCore;

namespace APIContas.Data.EF;

public class CategoriaEF : ICategoriaRepository
{
    private readonly ContasContext _context;

    public CategoriaEF(ContasContext context) => (_context) = (context);

    public async Task<bool> Alterar(Categoria entity)
    {
        entity.Ativo = true;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<bool> Ativar(Categoria entity)
    {
        entity.Ativo = true;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<Categoria> BuscarPorId(int id)
    {
        return await _context.Categoria
            .IgnoreQueryFilters()
            .FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<Categoria>> BuscarPorValores(string values)
    {
        if (values == null) return await BuscarTodos();

        return await _context.Categoria
            .Where(x => x.Descricao.Contains(values))
            .ToListAsync();
    }

    public async Task<ICollection<Categoria>> BuscarTodos()
    {
        return await _context.Categoria
                .OrderBy(x => x.Descricao)
                .ToListAsync();
    }

    public async Task<bool> Excluir(Categoria entity)
    {
        _context.Remove(entity);

        return await _context.SaveChangesAsync() > 1 ? true : false;
    }

    public async Task<bool> Inativar(Categoria entity)
    {
        entity.Ativo = false;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<bool> Incluir(Categoria entity)
    {
        entity.Ativo = true;

        _context.Add(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }
}
