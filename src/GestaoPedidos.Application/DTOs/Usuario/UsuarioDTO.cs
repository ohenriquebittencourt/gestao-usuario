using System.Diagnostics.CodeAnalysis;

namespace GestaoPedidos.Application.DTOs.Usuario
{
    [ExcludeFromCodeCoverage]
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public int Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}
