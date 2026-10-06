using Desafio1.Api.Models;
using Desafio1.Interfaces.Repositories;
using Desafio1.Interfaces.Services;
using Desafio1.ViewModels.Requests;

namespace Desafio1.Services;

public class VendaService : IVendaService
{
    private readonly IVendaRepository _vendaRepository;
    public VendaService(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }
    public async Task<Venda> GetVendaPorIdentificadorAsync(int id)
    {
        return await _vendaRepository.GetVendaPorIdentificadorAsync(id);
    }

    public async Task<IEnumerable<Venda>> GetVendasAsync()
    {
        return await _vendaRepository.GetVendasAsync();
    }

    public async Task<IEnumerable<Venda>> GetVendasPorVendedorAsync(string vendedor)
    {
        return await _vendaRepository.GetVendasPorVendedorAsync(vendedor);
    }
    public async Task<IEnumerable<Venda>> PostVendaAsync(ListPostVendasRequest vendas)
    {
        if (vendas == null || vendas.vendas == null || vendas.vendas.Count == 0)
        {
            throw new ArgumentException("A lista de vendas não pode ser nula ou vazia.");
        }
        var vendasList = vendas.vendas.Select(v => (Venda)v).ToList();
        await _vendaRepository.PostVendaAsync(vendasList);
        return vendasList;
    }
    public async Task<Venda> AtualizarVendaAsync(int id, PostVendasRequest request)
    {
        var entity = await GetVendaPorIdentificadorAsync(id) ?? throw new ArgumentException($"Venda com ID {id} não encontrada.");
        
        entity.SetVendedor(request.vendedor);
        entity.SetValor(request.valor);
        await _vendaRepository.AtualizarVendaAsync(id, entity);
        return Task.FromResult(entity).Result;
    }

    public async Task<bool> DeletarVendaAsync(int id)
    {
        var success = false;
        var entity = await GetVendaPorIdentificadorAsync(id) ?? throw new ArgumentException($"Venda com ID {id} não encontrada.");
        await _vendaRepository.DeletarVendaAsync(entity);
        success = true;
        return success;
    }




}