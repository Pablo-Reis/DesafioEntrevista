using System.ComponentModel.DataAnnotations;

namespace Desafio1.ViewModels.Requests;

public class PostVendasRequest
{
    [Required(ErrorMessage = "O campo vendedor é obrigatório.")]
    public string vendedor { get; set; }
    [Required(ErrorMessage = "O campo valor é obrigatório.")]
    public decimal valor { get; set; }
}

public class ListPostVendasRequest
{
    [Required(ErrorMessage = "A lista de vendas é obrigatória.")]
    public List<PostVendasRequest> vendas { get; set; }
}