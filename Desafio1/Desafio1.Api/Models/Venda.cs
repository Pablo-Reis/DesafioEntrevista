using Desafio1.ViewModels.Requests;

namespace Desafio1.Api.Models;

public class Venda
{
    public int Id { get; private set; }
    public string vendedor { get; private set; }
    public decimal valor { get; private set; }
    public decimal Comissao => CalcularComissao();
    public string NormalizedComissao => Comissao.ToString("C");

    public Venda()
    {
        vendedor = string.Empty;
        valor = 0;
    }
    public Venda(string vendedor, decimal valor)
    {
        if (valor < 0)
        {
            throw new ArgumentException("O valor da venda não pode ser negativo.");
        }
        if (string.IsNullOrWhiteSpace(vendedor))
        {
            throw new ArgumentException("O nome do vendedor não pode ser vazio.");
        }

        this.vendedor = vendedor;
        this.valor = valor;
    }
    public void SetVendedor(string vendedor)
    {
        this.vendedor = vendedor;
    }

    public void SetValor(decimal valor)
    {
        if (valor < 0)
        {
            throw new ArgumentException("O valor da venda não pode ser negativo.");
        }
        this.valor = valor;
    }

    private decimal CalcularComissao()
    {
        var comissao = 0m;
        comissao = (valor) switch
        {
            < 100 => valor * 0.00m,
            >= 100 and < 500 => valor * 0.01m,
            >= 500 => valor * 0.05m
        };
        return Math.Round(comissao, 2);
    }

    public static implicit operator Venda(PostVendasRequest request)
    {
        return new Venda(request.vendedor, request.valor);
    }
}