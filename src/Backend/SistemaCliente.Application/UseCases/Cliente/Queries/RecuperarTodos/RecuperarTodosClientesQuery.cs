namespace SistemaCliente.Application.UseCases.Cliente.Queries.RecuperarTodos;

public record RecuperarTodosClientesQuery() : IRequest<IEnumerable<RespostaClienteJson>>;

public class RecuperarTodosClientesQueryHandler(IClienteReadOnlyRepositorio repositorio) : IRequestHandler<RecuperarTodosClientesQuery, IEnumerable<RespostaClienteJson>>
{
    public async Task<IEnumerable<RespostaClienteJson>> Handle(RecuperarTodosClientesQuery request, CancellationToken cancellationToken)
    {
        var clientes = await repositorio.RecuperarTodos();

        var resultado = clientes.Select(c => new RespostaClienteJson(c.Id, c.NomeEmpresa, (Communication.Enums.Porte)c.Porte, c.DataCriacao)).ToList();

        return resultado;
    }
}

