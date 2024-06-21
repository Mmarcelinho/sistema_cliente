namespace SistemaCliente.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AdicionarInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarContexto(services, configuration);
    }

    private static void AdicionarContexto(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Conexao");

        services.AddDbContext<SistemaClienteContext>(opcoes =>
        {
            opcoes.UseSqlServer(connectionString);
        });
    }
}
