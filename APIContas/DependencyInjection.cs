using APIContas.Data.EF;
using APIContas.Data.Interfaces;
using APIContas.Services;

namespace APIContas;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoriaRepository, CategoriaEF>();
        services.AddScoped<ICategoriaService, CategoriaService>();

        return services;
    }
}
