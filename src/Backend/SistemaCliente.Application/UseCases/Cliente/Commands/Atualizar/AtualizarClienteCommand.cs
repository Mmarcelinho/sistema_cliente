namespace SistemaCliente.Application.UseCases.Cliente.Commands.Atualizar;

public record AtualizarClienteCommand(long Id, RequisicaoClienteJson requisicaoCliente) : IRequest;

public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand>
{
    private readonly IClienteUpdateOnlyRepositorio _repositorioWrite;

    private readonly IClienteReadOnlyRepositorio _repositorioRead;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AtualizarClienteCommandHandler(IClienteUpdateOnlyRepositorio repositorioWrite, IClienteReadOnlyRepositorio repositorioRead, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorioWrite = repositorioWrite;
        _repositorioRead = repositorioRead;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        await Validar(request.requisicaoCliente);

        var cliente = await _repositorioWrite.RecuperarPorId(request.Id);

        if (cliente is null)
            throw new NaoEncontradoException(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO);

        cliente.NomeEmpresa = request.requisicaoCliente.NomeEmpresa;
        cliente.Porte = (Domain.Enum.Porte)request.requisicaoCliente.Porte;

        _repositorioWrite.Atualizar(cliente);
        await _unidadeDeTrabalho.Commit();
    }

    private async Task Validar(RequisicaoClienteJson requisicao)
    {
        var clienteExiste = await _repositorioRead.ExisteClienteComEmpresa(requisicao.NomeEmpresa);

        if (clienteExiste)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_JA_REGISTRADO);
    }
}

