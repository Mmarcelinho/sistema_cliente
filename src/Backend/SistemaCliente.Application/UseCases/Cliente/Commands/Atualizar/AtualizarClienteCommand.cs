

namespace SistemaCliente.Application.UseCases.Cliente.Commands.Atualizar;

public record AtualizarClienteCommand(long Id, RequisicaoClienteJson RequisicaoCliente) : IRequest;

public class AtualizarClienteCommandHandler(
    IClienteUpdateOnlyRepositorio repositorioWrite,
    IClienteReadOnlyRepositorio repositorioRead,
    IUnidadeDeTrabalho unidadeDeTrabalho) : IRequestHandler<AtualizarClienteCommand>
{
    public async Task Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        await Validar(request.RequisicaoCliente);

        var cliente = await repositorioWrite.RecuperarPorId(request.Id);

        if (cliente is null)
            throw new Exception(ClienteErrorsConstants.CLIENTE_NAO_ENCONTRADO);

        cliente.NomeEmpresa = request.RequisicaoCliente.NomeEmpresa;
        cliente.Porte = (Domain.Enum.Porte)request.RequisicaoCliente.Porte;

        repositorioWrite.Atualizar(cliente);
        await unidadeDeTrabalho.Commit();
    }

    private async Task Validar(RequisicaoClienteJson requisicao)
    {
        var clienteExiste = await repositorioRead.ExisteClienteComEmpresa(requisicao.NomeEmpresa);

        if (clienteExiste)
            throw new Exception(ClienteErrorsConstants.CLIENTE_JA_REGISTRADO);
    }
}

