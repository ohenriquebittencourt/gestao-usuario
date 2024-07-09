using GestaoPedidos.Application.Mappings;
using GestaoPedidos.Application.Services;
using GestaoPedidos.Domain.Interfaces.Services;

namespace GestaoPedidos.Web.DependencyInjections
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IClienteService, ClienteService>();
        }

        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ClienteMappingProfile));
            services.AddAutoMapper(typeof(UsuarioMappingProfile));
        }
    }
}
