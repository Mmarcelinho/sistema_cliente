namespace SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio;

public class ClienteRepositorio : IClienteReadOnlyRepositorio, IClienteWriteOnlyRepositorio, IClienteUpdateOnlyRepositorio
{
    private readonly SistemaClienteContext _contexto;

    private readonly IDbConnection _connection;

    public ClienteRepositorio(SistemaClienteContext contexto, IDbConnection connection)
    {
        _contexto = contexto;
        _connection = connection;
    }

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

    async Task<Cliente> IClienteUpdateOnlyRepositorio.RecuperarPorId(long clienteId) => await _contexto.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == clienteId);

    public async Task<bool> ExisteClienteComEmpresa(string nomeEmpresa)
    {
        var query = ClienteQueries.ExisteClienteComEmpresaQuery(nomeEmpresa);

        var count = await _connection.ExecuteScalarAsync<int>(query.Query, query.Parameters);
        return count > 0;
    }

    public async Task Registrar(Cliente cliente) => await _contexto.Clientes.AddAsync(cliente);

    public void Atualizar(Cliente cliente) => _contexto.Clientes.Update(cliente);

    public async Task<bool> Deletar(long clienteId)
    {
        var resultado = await _contexto.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == clienteId);

        if (resultado is null)
            return false;

        _contexto.Clientes.Remove(resultado);

        return true;
    }
}
