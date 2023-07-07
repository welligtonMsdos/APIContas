using APIContas.Data.Context;
using APIContas.Data.Interfaces;
using APIContas.Model;
using Microsoft.EntityFrameworkCore;

namespace APIContas.Data.EF;

public class ContaEF: IContaRepository
{
    private readonly ContasContext _context;

    public ContaEF(ContasContext context) => (_context) = (context);

    public async Task<bool> Alterar(Conta entity)
    {
        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<Conta> BuscarPorId(int id)
    {
        return await _context.Conta
            .FirstAsync(x => x.Id == id);
    }

    public async Task<ICollection<Conta>> BuscarPorValores(string values)
    {
        if (values == null) return await BuscarTodos();

        return await _context.Conta
            .Where(x => x.Descricao.Contains(values) && x.Ativo)
            .ToListAsync();
    }

    public async Task<ICollection<Conta>> BuscarTodos()
    {
        return await _context.Conta
            .Where(x => x.Ativo)
            .OrderBy(x => x.Descricao)
            .ToListAsync();
    }

    public async Task<bool> Excluir(Conta entity)
    {
        _context.Remove(entity);

        return await _context.SaveChangesAsync() > 1 ? true : false;
    }

    public async Task<bool> Incluir(Conta entity)
    {
        _context.Add(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }
}
