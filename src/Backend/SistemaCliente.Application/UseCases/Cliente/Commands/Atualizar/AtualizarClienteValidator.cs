namespace SistemaCliente.Application.UseCases.Cliente.Commands.Atualizar;

public class AtualizarClienteValidator : AbstractValidator<AtualizarClienteCommand>
{
    private readonly IClienteReadOnlyRepositorio _repositorio;

    public AtualizarClienteValidator(IClienteReadOnlyRepositorio repositorio)
    {
        _repositorio = repositorio;

        RuleFor(cliente => cliente.requisicaoCliente.NomeEmpresa)
           .NotEmpty().WithMessage(ClienteMensagensDeErro.EMPRESA_CLIENTE_NOME_EM_BRANCO);

        RuleFor(cliente => cliente.requisicaoCliente.NomeEmpresa)
            .MustAsync(async (nomeEmpresa, cancellation) => !await ExisteClienteComEmpresa(nomeEmpresa))
            .WithMessage(ClienteMensagensDeErro.CLIENTE_JA_REGISTRADO);

        RuleFor(cliente => cliente.requisicaoCliente.Porte)
        .IsInEnum().WithMessage(ClienteMensagensDeErro.EMPRESA_CLIENTE_PORTE_INVALIDO);
    }

    private async Task<bool> ExisteClienteComEmpresa(string nomeEmpresa) => await _repositorio.ExisteClienteComEmpresa(nomeEmpresa);
}
