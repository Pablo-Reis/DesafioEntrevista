using Desafio1.Api.Models;
using Desafio1.Extensions;
using Desafio1.Interfaces.Services;
using Desafio1.ViewModels.Requests;
using Desafio1.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace Desafio1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendasController : ControllerBase
{
    private readonly IVendaService _vendaService;

    public VendasController(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVendas()
    {
        try
        {
            var vendas = await _vendaService.GetVendasAsync();
            return Ok(new ResultViewModel<IEnumerable<Venda>>(vendas));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResultViewModel<string>(ex.Message));
        }
    }
    [HttpGet("{vendedor}")]
    public async Task<IActionResult> GetVendaPorVendedorAsync(string vendedor)
    {
        try
        {
            var vendas = await _vendaService.GetVendasPorVendedorAsync(vendedor);
            return Ok(new ResultViewModel<IEnumerable<Venda>>(vendas));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResultViewModel<string>(ex.Message));
        }
    }
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetVendaPorIdentificadorAsync(int id)
    {
        try
        {
            var venda = await _vendaService.GetVendaPorIdentificadorAsync(id);
            return Ok(new ResultViewModel<Venda>(venda));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResultViewModel<string>(ex.Message));
        }
    }
    [HttpPost]
    public async Task<IActionResult> PostVendaAsync([FromBody] ListPostVendasRequest vendas)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest(new ResultViewModel<List<string>>(ModelState.GetErrors()));
        }
        try
        {
            var novasVendas = await _vendaService.PostVendaAsync(vendas);
            return Ok(new ResultViewModel<IEnumerable<Venda>>(novasVendas));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResultViewModel<string>(ex.Message));
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarVendaAsync(int id, [FromBody] PostVendasRequest request)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest(new ResultViewModel<List<string>>(ModelState.GetErrors()));
        }
        try
        {
            var venda = await _vendaService.AtualizarVendaAsync(id, request);
            return Ok(new ResultViewModel<Venda>(venda));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResultViewModel<string>(ex.Message));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarVendaAsync(int id)
    {
        try
        {
            var success = await _vendaService.DeletarVendaAsync(id);
            return Ok(new ResultViewModel<string>("Sucesso ao deletar a venda."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ResultViewModel<string>(ex.Message));
        }  
    }

}