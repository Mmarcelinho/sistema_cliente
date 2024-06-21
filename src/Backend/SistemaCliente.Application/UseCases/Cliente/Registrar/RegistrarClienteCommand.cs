namespace SistemaCliente.Application.UseCases.Cliente.Registrar;

    public record RegistrarClienteCommand(RequisicaoClienteJson requisicaoCliente) : IRequest<RespostaClienteJson>;

public class RegistrarClienteCommandHandler : IRequestHandler<RegistrarClienteCommand, RespostaClienteJson>
{
    private readonly IClienteWriteOnlyRepositorio _repositorio;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public RegistrarClienteCommandHandler(IClienteWriteOnlyRepositorio repositorio, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _repositorio = repositorio;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task<RespostaClienteJson> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Domain.Entidades.Cliente
        {
            NomeEmpresa = request.requisicaoCliente.NomeEmpresa,
            Porte = (Domain.Enum.Porte)request.requisicaoCliente.Porte
        };

        await _repositorio.Registrar(cliente);

        await _unidadeDeTrabalho.Commit();

        return new RespostaClienteJson
        (
            cliente.Id,
            cliente.NomeEmpresa,
            (Communication.Enums.Porte)cliente.Porte,
            cliente.DataCriacao
        );
    }
}
