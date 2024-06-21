namespace SistemaCliente.Infrastructure.Migrations;

public static class MigrateExtension
{
    public async static Task MigrateBancoDeDados(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<SistemaClienteContext>();

        await dbContext.Database.MigrateAsync();
    }
}