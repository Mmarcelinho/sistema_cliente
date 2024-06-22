namespace SistemaCliente.Application.UseCases.Cliente.Deletar;

public record DeletarClienteCommand(long clienteId) : IRequest;

public class DeletarClienteCommandHandler : IRequestHandler<DeletarClienteCommand>
{
    private readonly IClienteWriteOnlyRepositorio _repositorio;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public DeletarClienteCommandHandler(IClienteWriteOnlyRepositorio repositorio, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorio = repositorio;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Handle(DeletarClienteCommand request, CancellationToken cancellationToken)
    {
        var resultado = await _repositorio.Deletar(request.clienteId);

        if (!resultado)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO);


        await _unidadeDeTrabalho.Commit();
    }
}

