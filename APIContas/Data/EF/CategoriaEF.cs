using APIContas.Data.Context;
using APIContas.Data.Interfaces;
using APIContas.Model;
using Microsoft.EntityFrameworkCore;

namespace APIContas.Data.EF;

public class CategoriaEF : ICategoriaRepository
{
    private readonly ContasContext _context;

    public CategoriaEF(ContasContext context) => (_context) = (context);
    
    public async Task Alterar(Categoria entity)
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Categoria> BuscarPorId(int id)
    {
        return await _context.Categoria
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
                .Where(x => x.Ativo)
                .OrderBy(x => x.Descricao)
                .ToListAsync();
    }

    public async Task Excluir(Categoria entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Incluir(Categoria entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }
}
