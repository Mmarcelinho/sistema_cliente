namespace SistemaCliente.Application.UseCases.Cliente.Queries.RecuperarPorId;

public record RecuperarClientePorIdQuery(long ClienteId) : IRequest<RespostaClienteJson>;

public class RecuperarClientePorIdQueryHandler(IClienteReadOnlyRepositorio repositorio) : IRequestHandler<RecuperarClientePorIdQuery, RespostaClienteJson>
{
    public async Task<RespostaClienteJson> Handle(RecuperarClientePorIdQuery request, CancellationToken cancellationToken)
    {
        var cliente = await repositorio.RecuperarPorId(request.ClienteId);

        if(cliente is null)
            throw new Exception(ClienteErrorsConstants.CLIENTE_NAO_ENCONTRADO);

        var _cliente = ClienteConversion.FromEntity(cliente);

        return _cliente!;
    }
}

