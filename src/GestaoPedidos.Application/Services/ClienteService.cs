using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Domain.Interfaces.Services;
using GestaoPedidos.Domain.Interfaces.Repositories;

namespace GestaoPedidos.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task CadastrarCliente(Cliente cliente)
        {
            await _clienteRepository.Cadastrar(cliente);
        }

        public async Task AtualizarCliente(Cliente cliente)
        {
            await _clienteRepository.Atualizar(cliente);
        }

        public Task<Cliente?> ObterCliente(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public async Task DeletarCliente(int id)
        {
            await _clienteRepository.Remover(id);
        }
    }
}
