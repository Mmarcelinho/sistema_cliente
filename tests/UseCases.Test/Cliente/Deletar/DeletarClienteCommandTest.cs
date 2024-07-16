namespace UseCases.Test.Cliente.Deletar;

public class DeletarClienteCommandTest
{
    [Fact]
    public async Task Sucesso()
    {
        var cliente = ClienteBuilder.Instancia();

        var command = new DeletarClienteCommand(cliente.Id);

        var useCase = CriarUseCase(cliente);

        var acao = async () => await useCase.Handle(command, default);

        await acao.Should().NotThrowAsync();
    }

    [Fact]
    public async Task ClienteNaoEncontrado_DeveRetornarErro()
    {
        var cliente = ClienteBuilder.Instancia();

        var command = new DeletarClienteCommand(100);

        var useCase = CriarUseCase(cliente);

        Func<Task> acao = async () => await useCase.Handle(command, default);

        var resultado = await acao.Should().ThrowAsync<Exception>();

        resultado.Where(ex => ex.Message.Contains(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO));
    }

    private static DeletarClienteCommandHandler CriarUseCase(SistemaCliente.Domain.Entidades.Cliente cliente)
    {
        var repositorioWrite = ClienteWriteOnlyRepositorioBuilder.Build();
        var repositorioRead = new ClienteReadOnlyRepositorioBuilder().RecuperarPorId(cliente);
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Build();

        return new DeletarClienteCommandHandler(repositorioWrite, repositorioRead.Build(), unidadeDeTrabalho);
    }
}

