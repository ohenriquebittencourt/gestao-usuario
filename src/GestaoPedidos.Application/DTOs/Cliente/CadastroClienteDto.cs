using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Cliente;

[ExcludeFromCodeCoverage]
public class CadastroClienteDto
{
    public string Nome { get; set; } = string.Empty; 
    public string CPF { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty; 
    public DateTime Aniversario { get; set; }
}
