namespace SistemaCliente.Application.UseCases.Cliente.Deletar;

    public record DeletarClienteCommand(long clienteId) : IRequest;

public class DeletarClienteCommandHandler : IRequestHandler<DeletarClienteCommand>
{
    private readonly IClienteReadOnlyRepositorio _repositorioRead;

    private readonly IClienteWriteOnlyRepositorio _repositorioWrite;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public DeletarClienteCommandHandler(IClienteReadOnlyRepositorio repositorioRead, IClienteWriteOnlyRepositorio repositorioWrite, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorioRead = repositorioRead;
        _repositorioWrite = repositorioWrite;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repositorioRead.RecuperarPorId(request.clienteId);

        if(cliente is null)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO);

        await _repositorioWrite.Deletar(request.clienteId);

        await _unidadeDeTrabalho.Commit();
    }
}
 
