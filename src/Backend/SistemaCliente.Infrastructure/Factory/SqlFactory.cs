namespace SistemaCliente.Infrastructure.Factory;

public class SqlFactory
{
    private readonly IConfiguration _configuration;

    public SqlFactory(IConfiguration configuration) => _configuration = configuration;


    public IDbConnection CreateSqlConnection()
    {
        var connectionString = _configuration.GetConnectionString("Conexao");
        return new SqlConnection(connectionString);
    }
}