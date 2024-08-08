namespace UseCases.Test.Cliente.Registrar;

public class RegistrarClienteCommandTest
{
    [Fact]
    public async Task Sucesso()
    {
        var command = RegistrarClienteCommandBuilder.Instancia();

        var useCase = CriarUseCase();

        var resultado = await useCase.Handle(command, default);

        resultado.Should().NotBeNull();
        resultado.NomeEmpresa.Should().Be(command.RequisicaoCliente.NomeEmpresa);
        resultado.Porte.Should().Be(command.RequisicaoCliente.Porte);
    }

    private static RegistrarClienteCommandHandler CriarUseCase()
    {
        var repositorioWrite = ClienteWriteOnlyRepositorioBuilder.Instancia();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia();

        return new RegistrarClienteCommandHandler(repositorioWrite, unidadeDeTrabalho);
    }
}
