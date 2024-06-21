using SistemaCliente.Infrastructure.AcessoRepositorio.Mappings;

namespace SistemaCliente.Infrastructure.AcessoRepositorio.Queries;

public class ClienteQueries
{
    public static QueryModel ExisteClienteComEmpresaQuery(string nomeEmpresa)
    {
        string tabela = ContextMapping.RecuperarTabelaCliente();

        string query = @$"SELECT COUNT(*) FROM {tabela} WHERE NomeEmpresa = @NomeEmpresa";

        var parameters = new
        {
            NomeEmpresa = nomeEmpresa
        };

        return new QueryModel(query, parameters);
    }

    public static QueryModel RecuperarTodosQuery()
    {
        string tabela = ContextMapping.RecuperarTabelaCliente();

        string query = @$"SELECT 
        [Id],
        [NomeEmpresa],
        [Porte],
        [DataCriacao] FROM {tabela}";

        var parameters = new { };

        return new QueryModel(query, parameters);
    }

    public static QueryModel RecuperarPorIdQuery(long id)
    {
        string tabela = ContextMapping.RecuperarTabelaCliente();


        string query = @$"SELECT 
        [Id],
        [NomeEmpresa],
        [Porte],
        [DataCriacao] FROM {tabela} WITH (READPAST) WHERE Id @Id";

        var parameters = new
        {
            Id = id
        };

        return new QueryModel(query, parameters);
    }
}

