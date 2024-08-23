using SistemaCliente.Exceptions.Base;

namespace SistemaCliente.Application.UseCases.Cliente.Commands.Atualizar;

public record AtualizarClienteCommand(long Id, RequisicaoClienteJson RequisicaoCliente) : IRequest;

public class AtualizarClienteCommandHandler(
    IClienteUpdateOnlyRepositorio repositorio,
    IUnidadeDeTrabalho unidadeDeTrabalho) : IRequestHandler<AtualizarClienteCommand>
{
    public async Task Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await repositorio.RecuperarPorId(request.Id);

        if (cliente is null)
            throw new NaoEncontradoException(ClienteErrorsConstants.CLIENTE_NAO_ENCONTRADO);

        cliente = cliente.Atualizar(request.RequisicaoCliente);

        repositorio.Atualizar(cliente);
        await unidadeDeTrabalho.Commit();
    }
}

