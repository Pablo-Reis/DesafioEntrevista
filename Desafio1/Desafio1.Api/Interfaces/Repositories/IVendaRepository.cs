using Desafio1.Api.Models;

namespace Desafio1.Interfaces.Repositories;

public interface IVendaRepository
{
    Task<IEnumerable<Venda>> GetVendasAsync();
    Task<IEnumerable<Venda>> GetVendasPorVendedorAsync(string vendedor);
    Task<Venda> GetVendaPorIdentificadorAsync(int id);
    Task<IEnumerable<Venda>> PostVendaAsync(List<Venda> vendas);
    Task<Venda> AtualizarVendaAsync(int id, Venda venda);
    Task<bool> DeletarVendaAsync(Venda venda);
}