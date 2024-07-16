namespace SistemaCliente.Application.UseCases.Cliente.Commands.Registrar;

public record RegistrarClienteCommand(RequisicaoClienteJson requisicaoCliente) : IRequest<RespostaClienteJson>;

public class RegistrarClienteCommandHandler : IRequestHandler<RegistrarClienteCommand, RespostaClienteJson>
{
    private readonly IClienteWriteOnlyRepositorio _repositorioWrite;

    private readonly IClienteReadOnlyRepositorio _repositorioRead;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public RegistrarClienteCommandHandler(IClienteWriteOnlyRepositorio repositorioWrite, IClienteReadOnlyRepositorio repositorioRead, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorioWrite = repositorioWrite;
        _repositorioRead = repositorioRead;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task<RespostaClienteJson> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
    {
        await Validar(request.requisicaoCliente);

        var cliente = new Domain.Entidades.Cliente
        {
            NomeEmpresa = request.requisicaoCliente.NomeEmpresa,
            Porte = (Domain.Enum.Porte)request.requisicaoCliente.Porte
        };

        await _repositorioWrite.Registrar(cliente);

        await _unidadeDeTrabalho.Commit();

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
        var clienteExiste = await _repositorioRead.ExisteClienteComEmpresa(requisicao.NomeEmpresa);

        if (clienteExiste)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_JA_REGISTRADO);
    }
}
