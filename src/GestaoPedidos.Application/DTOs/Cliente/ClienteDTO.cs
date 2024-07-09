using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Cliente;

[ExcludeFromCodeCoverage]
public class ClienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty; 
    public string CPF { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty; 
    public string Telefone { get; set; } = string.Empty;
    public DateTime Aniversario { get; set; }
}
