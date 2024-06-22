namespace SistemaCliente.Application.UseCases.Cliente.Commands.Atualizar;

public record AtualizarClienteCommand(long Id, RequisicaoClienteJson requisicaoCliente) : IRequest;

public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand>
{
    private readonly IClienteUpdateOnlyRepositorio _repositorio;

    private readonly IClienteWriteOnlyRepositorio _repositorioWrite;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AtualizarClienteCommandHandler(IClienteUpdateOnlyRepositorio repositorio, IClienteWriteOnlyRepositorio repositorioWrite, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorio = repositorio;
        _repositorioWrite = repositorioWrite;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        await Validar(request.requisicaoCliente);

        var cliente = await _repositorio.RecuperarPorId(request.Id);

        if (cliente is null)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO);

        cliente.NomeEmpresa = request.requisicaoCliente.NomeEmpresa;
        cliente.Porte = (Domain.Enum.Porte)request.requisicaoCliente.Porte;

        _repositorio.Atualizar(cliente);
        await _unidadeDeTrabalho.Commit();
    }

    private async Task Validar(RequisicaoClienteJson requisicao)
    {
        var clienteExiste = await _repositorioWrite.ExisteClienteComEmpresa(requisicao.NomeEmpresa);

        if (clienteExiste)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_JA_REGISTRADO);
    }
}

