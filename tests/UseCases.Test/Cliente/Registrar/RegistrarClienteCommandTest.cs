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

    [Fact]
    public async Task ClienteExistente_DeveRetornarErro()
    {
        var command = RegistrarClienteCommandBuilder.Instancia();

        var useCase = CriarUseCase(command.RequisicaoCliente.NomeEmpresa);

        Func<Task> acao = async () => await useCase.Handle(command, default);

        var resultado = await acao.Should().ThrowAsync<Exception>();

        resultado.Where(ex => ex.Message.Contains(ClienteErrorsConstants.CLIENTE_JA_REGISTRADO));
    }

    private static RegistrarClienteCommandHandler CriarUseCase(string? nomeEmpresa = null)
    {
        var repositorioWrite = ClienteWriteOnlyRepositorioBuilder.Instancia();
        var repositorioRead = new ClienteReadOnlyRepositorioBuilder();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia();

        if(string.IsNullOrWhiteSpace(nomeEmpresa) == false)
            repositorioRead.RecuperarClienteExistente(nomeEmpresa);

        return new RegistrarClienteCommandHandler(repositorioWrite, repositorioRead.Instancia(), unidadeDeTrabalho);
    }
}
