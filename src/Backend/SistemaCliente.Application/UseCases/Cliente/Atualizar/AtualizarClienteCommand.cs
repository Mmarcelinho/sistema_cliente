namespace SistemaCliente.Application.UseCases.Cliente.Atualizar;

    public record AtualizarClienteCommand(long Id, RequisicaoClienteJson requisicaoCliente) : IRequest;

public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand>
{
    private readonly IClienteUpdateOnlyRepositorio _repositorioUpdate;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AtualizarClienteCommandHandler(IClienteUpdateOnlyRepositorio repositorioUpdate, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorioUpdate = repositorioUpdate;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repositorioUpdate.RecuperarPorId(request.Id);

        if(cliente is null)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO);

        cliente.NomeEmpresa = request.requisicaoCliente.NomeEmpresa;
        cliente.Porte = (Domain.Enum.Porte)request.requisicaoCliente.Porte;

        await _unidadeDeTrabalho.Commit();
    }
}
 
