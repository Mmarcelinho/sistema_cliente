namespace SistemaCliente.Application.UseCases.Cliente.Atualizar;

    public record AtualizarClienteCommand(long Id, RequisicaoClienteJson requisicaoCliente) : IRequest;

public class AtualizarClienteCommandHandler : IRequestHandler<AtualizarClienteCommand>
{
    private readonly IClienteUpdateOnlyRepositorio _repositorio;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AtualizarClienteCommandHandler(IClienteUpdateOnlyRepositorio repositorio, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorio = repositorio;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _repositorio.RecuperarPorId(request.Id);

        if(cliente is null)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO);

        cliente.NomeEmpresa = request.requisicaoCliente.NomeEmpresa;
        cliente.Porte = (Domain.Enum.Porte)request.requisicaoCliente.Porte;

        _repositorio.Atualizar(cliente);
        await _unidadeDeTrabalho.Commit();
    }
}
 
