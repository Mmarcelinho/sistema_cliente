namespace SistemaCliente.Application.UseCases.Cliente.Commands.Registrar;

public record RegistrarClienteCommand(RequisicaoClienteJson RequisicaoCliente) : IRequest<RespostaClienteJson>;

public class RegistrarClienteCommandHandler(
    IClienteWriteOnlyRepositorio repositorio,
    IUnidadeDeTrabalho unidadeDeTrabalho) : IRequestHandler<RegistrarClienteCommand, RespostaClienteJson>
{
    public async Task<RespostaClienteJson> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = ClienteConversion.ToEntity(request.RequisicaoCliente);

        await repositorio.Registrar(cliente);

        await unidadeDeTrabalho.Commit();

        var (_cliente, _) = ClienteConversion.FromEntity(cliente, null!);

        return _cliente!;
    }
}
