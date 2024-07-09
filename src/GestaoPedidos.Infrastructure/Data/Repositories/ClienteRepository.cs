using AutoMapper;
using GestaoPedidos.Domain.Entities;
using GestaoPedidos.Infrastructure.Data.Contexts;
using GestaoPedidos.Domain.Interfaces.Repositories;
using GestaoPedidos.Infrastructure.Data.Entities.Clientes;

namespace GestaoPedidos.Infrastructure.Data.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly IMapper _mapper;
    private readonly ClienteContext _clienteContext;

    public ClienteRepository(IMapper mapper, ClienteContext clienteContext)
    {
        _mapper = mapper;
        _clienteContext = clienteContext;
    }
    public Task<Cliente?> ObterPorCpf(string cpf)
    {
        var entity = _clienteContext.Clientes.FirstOrDefault(c => c.CPF.Equals(cpf));
        if (entity == null)
            throw new KeyNotFoundException($"Identificador do usuario inexistente. {cpf}");

        var cliente = _mapper.Map<Cliente>(entity);
        return Task.FromResult(cliente);
    }
    public async Task Cadastrar(Cliente cliente)
    {
        var entity = _mapper.Map<ClienteEntity>(cliente);
        await _clienteContext.Clientes.AddAsync(entity);
        await _clienteContext.SaveChangesAsync();
    }
    public async Task Atualizar(Cliente cliente)
    {
        var entity = _mapper.Map<ClienteEntity>(cliente);
        _clienteContext.Clientes.Update(entity);
        await _clienteContext.SaveChangesAsync();
    }
    public async Task Remover(int id)
    {
        var entity = _clienteContext.Clientes.FirstOrDefault(p => p.Id.Equals(id));

        if (entity != null)
        {
            _clienteContext.Clientes.Remove(entity);
            await _clienteContext.SaveChangesAsync();
        }
        else
            throw new KeyNotFoundException($"Identificador do usuario inexistente. {id}");
    }
}