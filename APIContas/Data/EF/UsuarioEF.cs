using APIContas.Data.Context;
using APIContas.Data.Interfaces;
using APIContas.Model;
using Microsoft.EntityFrameworkCore;

namespace APIContas.Data.EF;

public class UsuarioEF : IUsuarioRepository
{
    private readonly ContasContext _context;
    public UsuarioEF(ContasContext context) => (_context) = (context);

    public async Task<bool> Alterar(Usuario entity)
    {
        entity.Ativo = true;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<bool> Ativar(Usuario entity)
    {
        entity.Ativo = true;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<Usuario> BuscarPorId(int id)
    {
        return await _context.Usuario
            .IgnoreQueryFilters()
            .FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<Usuario>> BuscarPorValores(string values)
    {
        if (values == null) return await BuscarTodos();

        return await _context.Usuario
            .Where(x => x.Nome.Contains(values))
            .ToListAsync();
    }

    public async Task<ICollection<Usuario>> BuscarTodos()
    {
        return await _context.Usuario
           .OrderBy(x => x.Nome)
           .ToListAsync();
    }

    public async Task<bool> Excluir(Usuario entity)
    {
        _context.Remove(entity);

        return await _context.SaveChangesAsync() > 1 ? true : false;
    }

    public async Task<bool> Inativar(Usuario entity)
    {
        entity.Ativo = false;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<bool> Incluir(Usuario entity)
    {
        _context.Add(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }
}
