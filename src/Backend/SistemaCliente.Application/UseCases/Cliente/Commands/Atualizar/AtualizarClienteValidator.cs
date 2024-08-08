namespace SistemaCliente.Application.UseCases.Cliente.Commands.Atualizar;

public class AtualizarClienteValidator : AbstractValidator<AtualizarClienteCommand>
{
    public AtualizarClienteValidator()
    {
        RuleFor(cliente => cliente.RequisicaoCliente.NomeEmpresa)
           .NotEmpty().WithMessage(ClienteErrorsConstants.EMPRESA_CLIENTE_NOME_EM_BRANCO);

        RuleFor(cliente => cliente.RequisicaoCliente.Porte)
        .IsInEnum().WithMessage(ClienteErrorsConstants.EMPRESA_CLIENTE_PORTE_INVALIDO);
    }
}
