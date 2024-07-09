using GestaoPedidos.Domain.Entities;

namespace GestaoPedidos.Domain.Interfaces.Repositories;

public interface IClienteRepository
{
    Task<Cliente?> ObterPorCpf(string cpf);
    Task Cadastrar(Cliente cliente);
    Task Atualizar(Cliente cliente);
    Task Remover(int id);

}