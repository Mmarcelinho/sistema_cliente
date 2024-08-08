namespace SistemaCliente.Application.UseCases.Cliente.Commands.Registrar;

public record RegistrarClienteCommand(RequisicaoClienteJson RequisicaoCliente) : IRequest<RespostaClienteJson>;

public class RegistrarClienteCommandHandler(
    IClienteWriteOnlyRepositorio repositorioWrite, IClienteReadOnlyRepositorio repositorioRead,
    IUnidadeDeTrabalho unidadeDeTrabalho) : IRequestHandler<RegistrarClienteCommand, RespostaClienteJson>
{
    public async Task<RespostaClienteJson> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
    {
        await Validar(request.RequisicaoCliente);

        var cliente = ClienteConversion.ToEntity(request.RequisicaoCliente);

        await repositorioWrite.Registrar(cliente);

        await unidadeDeTrabalho.Commit();

        var (_cliente, _) = ClienteConversion.FromEntity(cliente, null!);

        return _cliente!;
    }

    private async Task Validar(RequisicaoClienteJson requisicao)
    {
        var clienteExiste = await repositorioRead.ExisteClienteComEmpresa(requisicao.NomeEmpresa);

        if (clienteExiste)
            throw new Exception(ClienteErrorsConstants.CLIENTE_JA_REGISTRADO);
    }
}
