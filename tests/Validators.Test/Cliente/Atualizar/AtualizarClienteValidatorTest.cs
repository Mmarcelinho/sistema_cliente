namespace Validators.Test.Cliente.Atualizar;

public class AtualizarClienteValidatorTest
{
    [Fact]
    public void Sucesso()
    {
        var validator = new AtualizarClienteValidator();

        var requisicao = AtualizarClienteCommandBuilder.Instancia();

        var resultado = validator.Validate(requisicao);

        resultado.IsValid.Should().BeTrue();
    }

    [Fact]
    public void NomeEmpresa_EmBranco_DeveRetornarErro()
    {
        var validator = new AtualizarClienteValidator();

        var requisicao = RequisicaoClienteJsonBuilder.Instancia() with { NomeEmpresa = string.Empty };

        var command = new AtualizarClienteCommand(1, requisicao);

        var resultado = validator.Validate(command);

        resultado.IsValid.Should().BeFalse();

        resultado.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ClienteErrorsConstants.EMPRESA_CLIENTE_NOME_EM_BRANCO));
    }

    [Fact]
    public void Porte_Invalido_DeveRetornarErro()
    {
        var validator = new AtualizarClienteValidator();

        var requisicao = RequisicaoClienteJsonBuilder.Instancia() with { Porte = (SistemaCliente.Application.DTOs.Enum.Porte)3 };

        var command = new AtualizarClienteCommand(1, requisicao);

        var resultado = validator.Validate(command);

        resultado.IsValid.Should().BeFalse();

        resultado.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ClienteErrorsConstants.EMPRESA_CLIENTE_PORTE_INVALIDO));
    }
}
