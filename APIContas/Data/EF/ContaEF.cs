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
            .Where(x => x.Descricao.Contains(values))
            .ToListAsync();
    }

    public async Task<ICollection<Conta>> BuscarTodos()
    {
        return await _context.Conta           
            .OrderBy(x => x.Descricao)
            .ToListAsync();
    }

    public ICollection<Conta> BuscarTotalPorMes(int numeroMes)
    {
       return _context.Conta
            .Where(x => x.Mes == numeroMes)
            .GroupBy(x => x.Mes)
            .Select(g => new Conta()
            {       
                Descricao = GetNomeMes(numeroMes),
                Valor = g.Sum(x => x.Valor)
            })
            .ToList();
    }
    
    private string GetNomeMes(int numeroMes)
    {
        return numeroMes switch{
            1 => "Janeiro",
            2 => "Fevereiro",
            3 => "Março",
            4 => "Abril",
            5 => "Maio",
            6 => "Junho",
            7 => "Julho",
            8 => "Agosto",
            9 => "Setembro",
            10 => "Outubro",
            11 => "Novembro",
            12 => "Dezembro",
            _ => ""
        };
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

    public async Task<bool> Inativar(Conta entity)
    {
        entity.Ativo = false;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }

    public async Task<bool> Ativar(Conta entity)
    {
        entity.Ativo = true;

        _context.Update(entity);

        await _context.SaveChangesAsync();

        return entity.Id > 0 ? true : false;
    }
}
