using Microsoft.Data.Sqlite;

namespace SistemaCliente.Infrastructure.Factory;

public class SqlFactory
{
    private readonly IConfiguration _configuration;

    public SqlFactory(IConfiguration configuration) => _configuration = configuration;


    public IDbConnection CriaSqlConnection()
    {
        var connectionString = _configuration.GetConnectionString("Conexao");

        if (_configuration.IsTestEnvironment())
            return new SqliteConnection(connectionString);

        return new SqlConnection(connectionString);
    }
}