using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task CadastrarCliente(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task<Cliente?> ObterCliente(string cpf);
        Task DeletarCliente(int id);
    }
}
