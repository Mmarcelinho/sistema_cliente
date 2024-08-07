using Microsoft.Data.Sqlite;

namespace SistemaCliente.Infrastructure.Factory;

public class SqlFactory(IConfiguration configuration)
{
    public IDbConnection CriaSqlConnection()
    {
        var connectionString = configuration.GetConnectionString("Conexao");

        if (configuration.IsTestEnvironment())
            return new SqliteConnection(connectionString);

        return new SqlConnection(connectionString);
    }
}