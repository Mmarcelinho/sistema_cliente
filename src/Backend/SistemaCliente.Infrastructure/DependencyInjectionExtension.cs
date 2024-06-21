namespace SistemaCliente.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AdicionarInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarContexto(services, configuration);
        AdicionarDbConnection(services, configuration);
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

    private static void AdicionarDbConnection(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Conexao");

        services.AddSingleton<IDbConnection>
        (provider =>
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        });
    }

    private static void AdicionarRepositorios(IServiceCollection services)
    {
        services.AddScoped<IClienteReadOnlyRepositorio, ClienteRepositorio>();
        services.AddScoped<IClienteWriteOnlyRepositorio, ClienteRepositorio>();
        services.AddScoped<IClienteUpdateOnlyRepositorio, ClienteRepositorio>();

        services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
    }
}
