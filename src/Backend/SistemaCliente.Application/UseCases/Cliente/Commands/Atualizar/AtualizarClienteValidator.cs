namespace SistemaCliente.Application.UseCases.Cliente.Commands.Atualizar;

public class AtualizarClienteValidator : AbstractValidator<AtualizarClienteCommand>
{
    public AtualizarClienteValidator()
    {
        RuleFor(cliente => cliente.requisicaoCliente.NomeEmpresa)
           .NotEmpty().WithMessage(ClienteMensagensDeErro.EMPRESA_CLIENTE_NOME_EM_BRANCO);

        RuleFor(cliente => cliente.requisicaoCliente.Porte)
        .IsInEnum().WithMessage(ClienteMensagensDeErro.EMPRESA_CLIENTE_PORTE_INVALIDO);
    }
}
