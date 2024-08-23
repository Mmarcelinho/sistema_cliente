using SistemaCliente.Exceptions.Base;

namespace SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio.Dapper;

public class ClienteDapperRepositorio(SqlFactory sqlFactory) : IClienteReadOnlyRepositorio
{
    private readonly IDbConnection _connection = sqlFactory.CriaSqlConnection();

    public async Task<IEnumerable<Cliente>> RecuperarTodos()
    {
        var query = ClienteQueries.RecuperarTodosQuery();
        var resultado = await _connection.QueryAsync<Cliente>(query.Query, query.Parameters);

        if(resultado is null)
            throw new NaoEncontradoException(ClienteErrorsConstants.CLIENTE_NAO_ENCONTRADO);

        return resultado;
    }

    public async Task<Cliente> RecuperarPorId(long clienteId)
    {
        var query = ClienteQueries.RecuperarPorIdQuery(clienteId);
        var resultado = await _connection.QueryFirstOrDefaultAsync<Cliente>(query.Query, query.Parameters);

        if(resultado is null)
            throw new NaoEncontradoException(ClienteErrorsConstants.CLIENTE_NAO_ENCONTRADO);

        return resultado;
    }
}

