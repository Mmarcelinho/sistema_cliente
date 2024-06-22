using SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio.Dapper;
using SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio.EF;
using SistemaCliente.Infrastructure.Factory;

namespace SistemaCliente.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AdicionarInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarContexto(services, configuration);
        AdicionarSqlFactory(services);
        AdicionarRepositorios(services);
    }

    private static void AdicionarContexto(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Conexao");

        services.AddDbContext<SistemaClienteContext>(opcoes =>
        {
            opcoes.UseSqlServer(connectionString);
        });
    }

    private static void AdicionarSqlFactory(IServiceCollection services)
    => services.AddScoped<SqlFactory>();


    private static void AdicionarRepositorios(IServiceCollection services)
    {
        services.AddScoped<IClienteReadOnlyRepositorio, ClienteDapperRepositorio>();
        services.AddScoped<IClienteWriteOnlyRepositorio, ClienteEfRepositorio>();
        services.AddScoped<IClienteUpdateOnlyRepositorio, ClienteEfRepositorio>();

        services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
    }
}
