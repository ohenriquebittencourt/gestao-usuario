namespace GestaoPedidos.Application.DTOs.Cliente;

public class AtualizarClienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty; 
    public string CPF { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty; 
    public string Telefone { get; set; } = string.Empty; 
    public DateTime Aniversario { get; set; }
}
