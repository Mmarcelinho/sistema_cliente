namespace SistemaCliente.Application.UseCases.Cliente.Queries.RecuperarPorId;

public record RecuperarClientePorIdQuery(long clienteId) : IRequest<RespostaClienteJson>;

public class RecuperarClientePorIdQueryHandler : IRequestHandler<RecuperarClientePorIdQuery, RespostaClienteJson>
{
    private readonly IClienteReadOnlyRepositorio _repositorio;

        public RecuperarClientePorIdQueryHandler(IClienteReadOnlyRepositorio repositorio) => _repositorio = repositorio;

    public async Task<RespostaClienteJson> Handle(RecuperarClientePorIdQuery request, CancellationToken cancellationToken)
    {
        var cliente = await _repositorio.RecuperarPorId(request.clienteId);

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

