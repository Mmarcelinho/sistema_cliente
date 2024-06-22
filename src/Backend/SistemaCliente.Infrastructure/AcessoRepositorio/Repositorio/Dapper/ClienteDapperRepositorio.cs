using SistemaCliente.Infrastructure.Factory;

namespace SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio.Dapper;

public class ClienteDapperRepositorio : IClienteReadOnlyRepositorio
{
    private readonly IDbConnection _connection;

    public ClienteDapperRepositorio(SqlFactory sqlFactory) => _connection = sqlFactory.CreateSqlConnection();
    

    public async Task<IEnumerable<Cliente>> RecuperarTodos()
    {
        var query = ClienteQueries.RecuperarTodosQuery();
        var resultado = await _connection.QueryAsync<Cliente>(query.Query, query.Parameters);

        return resultado;
    }

    public async Task<Cliente> RecuperarPorId(long clienteId)
    {
        var query = ClienteQueries.RecuperarPorIdQuery(clienteId);
        var resultado = await _connection.QueryFirstOrDefaultAsync<Cliente>(query.Query, query.Parameters);

        return resultado;
    }
}

