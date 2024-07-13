
namespace GestaoPedidos.Domain.Entities
{
    public class Cliente(string nome, string cpf, string email, string telefone, DateTime aniversario) : Entidade
    {
        public string Nome { get; private set; } = nome;
        public string CPF { get; private set; } = cpf;
        public string Email { get; private set; } = email;
        public string Telefone { get; private set; } = telefone;
        public DateTime Aniversario { get; private set; } = aniversario;

        public static implicit operator List<object>(Cliente? v)
        {
            throw new NotImplementedException();
        }
    }
}
