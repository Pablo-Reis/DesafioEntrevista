using Desafio1.Api.Models;
using Desafio1.Data;
using Desafio1.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Desafio1.Repositories;

public class VendaRepository(AppDbContext context) : IVendaRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Venda> AtualizarVendaAsync(int id, Venda venda)
    {
        _context.Vendas.Update(venda);
        await _context.SaveChangesAsync();
        return venda;
    }

    public async Task<bool> DeletarVendaAsync(Venda venda)
    {
        _context.Vendas.Remove(venda);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Venda> GetVendaPorIdentificadorAsync(int id)
    {
        return await _context.Vendas.FindAsync(id) ?? new Venda();
    }

    public async Task<IEnumerable<Venda>> GetVendasAsync()
    {
        return await Task.FromResult(_context.Vendas.AsNoTracking().ToList());
    }

    public async Task<IEnumerable<Venda>> GetVendasPorVendedorAsync(string vendedor)
    {
        return await Task.FromResult(_context.Vendas.AsNoTracking().Where(v => v.vendedor.Contains(vendedor)).ToList());
    }

    public async Task<IEnumerable<Venda>> PostVendaAsync(List<Venda> vendas)
    {
        _context.Vendas.AddRange(vendas);
        await _context.SaveChangesAsync();
        return vendas;
    }
}