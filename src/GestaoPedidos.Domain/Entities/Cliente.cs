namespace GestaoPedidos.Domain.Entities
{
    public class Cliente(string nome, string cpf) : Entidade
    {
        public string Nome { get; private set; } = nome;
        public string CPF { get; private set; } = cpf;
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public DateTime Aniversario { get; private set; }
    }
}
