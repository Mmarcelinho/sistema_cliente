namespace SistemaCliente.Application.UseCases.Cliente.Commands.Deletar;

public record DeletarClienteCommand(long ClienteId) : IRequest;

public class DeletarClienteCommandHandler(
    IClienteWriteOnlyRepositorio repositorioWrite, IClienteReadOnlyRepositorio repositorioRead,
    IUnidadeDeTrabalho unidadeDeTrabalho) : IRequestHandler<DeletarClienteCommand>
{
    public async Task Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await repositorioRead.RecuperarPorId(request.ClienteId);

        if (cliente is null)
            throw new NaoEncontradoException(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO);

        await repositorioWrite.Deletar(request.ClienteId);

        await unidadeDeTrabalho.Commit();
    }
}

