namespace SistemaCliente.Application;

public static class DependencyInjectionExtension
{
    public static void AdicionarApplication(this IServiceCollection services)
    {
        AdicionarMediatR(services);
    }

    private static void AdicionarMediatR(IServiceCollection services)
    {
        var myHandlers = AppDomain.CurrentDomain.Load("SistemaCliente.Application");

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(myHandlers);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("SistemaCliente.Application"));
    }
}
