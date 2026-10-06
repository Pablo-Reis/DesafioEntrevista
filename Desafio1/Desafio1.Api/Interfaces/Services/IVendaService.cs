using Desafio1.Api.Models;
using Desafio1.ViewModels.Requests;

namespace Desafio1.Interfaces.Services;

public interface IVendaService
{
    Task<IEnumerable<Venda>> GetVendasAsync();
    Task<IEnumerable<Venda>> GetVendasPorVendedorAsync(string vendedor);
    Task<Venda> GetVendaPorIdentificadorAsync(int id);
    Task<IEnumerable<Venda>> PostVendaAsync(ListPostVendasRequest vendas);
    Task<Venda> AtualizarVendaAsync(int id, PostVendasRequest venda);
    Task<bool> DeletarVendaAsync(int id);
}