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

        services.AddScoped<IContaRepository, ContaEF>();
        services.AddScoped<IContaService, ContaService>();

        services.AddScoped<IPerfilRepository, PerfilEF>();
        services.AddScoped<IPerfilService, PerfilService>();

        services.AddScoped<IUsuarioRepository, UsuarioEF>();
        services.AddScoped<IUsuarioService, UsuarioService>();

        return services;
    }
}
