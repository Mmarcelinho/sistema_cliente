namespace SistemaCliente.Application.UseCases.Cliente.Commands.Deletar;

public record DeletarClienteCommand(long clienteId) : IRequest;

public class DeletarClienteCommandHandler : IRequestHandler<DeletarClienteCommand>
{
    private readonly IClienteWriteOnlyRepositorio _repositorioWrite;

    private readonly IClienteReadOnlyRepositorio _repositorioRead;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public DeletarClienteCommandHandler(IClienteWriteOnlyRepositorio repositorioWrite, IClienteReadOnlyRepositorio repositorioRead, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorioWrite = repositorioWrite;
        _repositorioRead = repositorioRead;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repositorioRead.RecuperarPorId(request.clienteId);

        if (cliente is null)
            throw new NaoEncontradoException(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO);

        await _repositorioWrite.Deletar(request.clienteId);
        
        await _unidadeDeTrabalho.Commit();
    }
}

