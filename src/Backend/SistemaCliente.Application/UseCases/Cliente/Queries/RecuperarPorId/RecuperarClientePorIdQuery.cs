namespace SistemaCliente.Application.UseCases.Cliente.Queries.RecuperarPorId;

public record RecuperarClientePorIdQuery(long ClienteId) : IRequest<RespostaClienteJson>;

public class RecuperarClientePorIdQueryHandler(IClienteReadOnlyRepositorio repositorio) : IRequestHandler<RecuperarClientePorIdQuery, RespostaClienteJson>
{
    public async Task<RespostaClienteJson> Handle(RecuperarClientePorIdQuery request, CancellationToken cancellationToken)
    {
        var cliente = await repositorio.RecuperarPorId(request.ClienteId);

        if(cliente is null)
            throw new NaoEncontradoException(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO);

        return new RespostaClienteJson
        (
            cliente.Id,
            cliente.NomeEmpresa,
            (Communication.Enums.Porte)cliente.Porte,
            cliente.DataCriacao
        );
    }
}

