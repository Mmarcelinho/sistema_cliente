namespace SistemaCliente.Application.UseCases.Cliente.Commands.Registrar;

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
        await Validar(request.requisicaoCliente);
        
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

    private async Task Validar(RequisicaoClienteJson requisicao)
    {
        var clienteExiste = await _repositorio.ExisteClienteComEmpresa(requisicao.NomeEmpresa);

        if(clienteExiste)
            throw new Exception(ClienteMensagensDeErro.CLIENTE_JA_REGISTRADO);
    }
}
