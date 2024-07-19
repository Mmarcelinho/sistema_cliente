namespace Validators.Test.Cliente.Registrar;

public class RegistrarClienteValidatorTest
{
    [Fact]
    public void Sucesso()
    {
        var validator = new RegistrarClienteValidator();

        var requisicao = RegistrarClienteCommandBuilder.Instancia();

        var resultado = validator.Validate(requisicao);

        resultado.IsValid.Should().BeTrue();
    }

    [Fact]
    public void NomeEmpresa_EmBranco_DeveRetornarErro()
    {
        var validator = new RegistrarClienteValidator();

        var requisicao = RequisicaoClienteJsonBuilder.Instancia() with { NomeEmpresa = string.Empty };

        var command = new RegistrarClienteCommand(requisicao);

        var resultado = validator.Validate(command);

        resultado.IsValid.Should().BeFalse();

        resultado.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ClienteMensagensDeErro.EMPRESA_CLIENTE_NOME_EM_BRANCO));
    }

    [Fact]
    public void Porte_Invalido_DeveRetornarErro()
    {
        var validator = new RegistrarClienteValidator();

        var requisicao = RequisicaoClienteJsonBuilder.Instancia() with { Porte = (SistemaCliente.Communication.Enums.Porte)3 };

        var command = new RegistrarClienteCommand(requisicao);

        var resultado = validator.Validate(command);

        resultado.IsValid.Should().BeFalse();

        resultado.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ClienteMensagensDeErro.EMPRESA_CLIENTE_PORTE_INVALIDO));
    }
}
