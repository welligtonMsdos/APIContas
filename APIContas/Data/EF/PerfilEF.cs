using APIContas.Data.Context;
using APIContas.Data.Interfaces;
using APIContas.Model;
using Microsoft.EntityFrameworkCore;

namespace APIContas.Data.EF;

public class PerfilEF : IPerfilRepository
{
    private readonly ContasContext _context;

    public PerfilEF(ContasContext context) => (_context) = (context);

    public async Task<bool> Alterar(Perfil entity)
    {
        entity.Ativo = true;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<bool> Ativar(Perfil entity)
    {
        entity.Ativo = true;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<Perfil> BuscarPorId(int id)
    {
        return await _context.Perfil
            .IgnoreQueryFilters()
            .FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<Perfil>> BuscarPorValores(string values)
    {
        if (values == null) return await BuscarTodos();

        return await _context.Perfil
            .Where(x => x.Descricao.Contains(values))
            .ToListAsync();
    }

    public async Task<ICollection<Perfil>> BuscarTodos()
    {
        return await _context.Perfil
           .OrderBy(x => x.Descricao)
           .ToListAsync();
    }

    public async Task<bool> Excluir(Perfil entity)
    {
        _context.Remove(entity);

        return await _context.SaveChangesAsync() > 1 ? true : false;
    }

    public async Task<bool> Inativar(Perfil entity)
    {
        entity.Ativo = false;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<bool> Incluir(Perfil entity)
    {
        entity.Ativo = true;

        _context.Add(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }
}
