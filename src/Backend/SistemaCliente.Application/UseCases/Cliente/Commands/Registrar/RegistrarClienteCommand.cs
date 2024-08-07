namespace SistemaCliente.Application.UseCases.Cliente.Commands.Registrar;

public record RegistrarClienteCommand(RequisicaoClienteJson RequisicaoCliente) : IRequest<RespostaClienteJson>;

public class RegistrarClienteCommandHandler(
    IClienteWriteOnlyRepositorio repositorioWrite, IClienteReadOnlyRepositorio repositorioRead,
    IUnidadeDeTrabalho unidadeDeTrabalho) : IRequestHandler<RegistrarClienteCommand, RespostaClienteJson>
{
    public async Task<RespostaClienteJson> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
    {
        await Validar(request.RequisicaoCliente);

        var cliente = new Domain.Entidades.Cliente
        {
            NomeEmpresa = request.RequisicaoCliente.NomeEmpresa,
            Porte = (Domain.Enum.Porte)request.RequisicaoCliente.Porte
        };

        await repositorioWrite.Registrar(cliente);

        await unidadeDeTrabalho.Commit();

        return new RespostaClienteJson
        (
            cliente.Id,
            cliente.NomeEmpresa,
            (Communication.Enums.Porte)cliente.Porte,
            cliente.DataCriacao
        );
    }

    private async Task Validar(RequisicaoClienteJson requisicao)
    {
        var clienteExiste = await repositorioRead.ExisteClienteComEmpresa(requisicao.NomeEmpresa);

        if (clienteExiste)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_JA_REGISTRADO);
    }
}
