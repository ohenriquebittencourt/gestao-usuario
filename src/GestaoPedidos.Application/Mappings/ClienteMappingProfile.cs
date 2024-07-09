using AutoMapper;
using GestaoPedidos.Application.DTOs.Cliente;
using GestaoPedidos.Infrastructure.Data.Entities.Clientes;

namespace GestaoPedidos.Application.Mappings;

public class ClienteMappingProfile : Profile
{
    public ClienteMappingProfile()
    {
        CreateMap<Domain.Entities.Cliente, CadastroClienteDto>();
        CreateMap<CadastroClienteDto, Domain.Entities.Cliente>();

        CreateMap<Domain.Entities.Cliente, ClienteDto>();
        CreateMap<ClienteDto, Domain.Entities.Cliente>();

        CreateMap<AtualizarClienteDto, Domain.Entities.Cliente>();
        CreateMap<Domain.Entities.Cliente, AtualizarClienteDto>();

        CreateMap<ClienteEntity, Domain.Entities.Cliente>().ReverseMap();
    }
}