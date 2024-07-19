namespace UseCases.Test.Cliente.Atualizar;

public class AtualizarClienteCommandTest
{
    [Fact]
    public async Task Sucesso()
    {
        var command = AtualizarClienteCommandBuilder.Instancia();

        var cliente = ClienteBuilder.Instancia();

        var requisicao = command with { Id = cliente.Id };

        var useCase = CriarUseCase(cliente);

        var acao = async () => await useCase.Handle(requisicao, default);

        await acao.Should().NotThrowAsync();

        cliente.NomeEmpresa.Should().Be(requisicao.requisicaoCliente.NomeEmpresa);
        cliente.Porte.Should().Be((SistemaCliente.Domain.Enum.Porte)requisicao.requisicaoCliente.Porte);
    }

    [Fact]
    public async Task ClienteExistente_DeveRetornarErro()
    {
        var cliente = ClienteBuilder.Instancia();

        var requisicao = new AtualizarClienteCommand(cliente.Id, RequisicaoClienteJsonBuilder.Instancia());

        var useCase = CriarUseCase(cliente, requisicao.requisicaoCliente.NomeEmpresa);

        Func<Task> acao = async () => await useCase.Handle(requisicao, default);

        var resultado = await acao.Should().ThrowAsync<Exception>();

        resultado.Where(ex => ex.Message.Contains(ClienteMensagensDeErro.CLIENTE_JA_REGISTRADO));
    }

    [Fact]
    public async Task ClienteNaoEncontrado_DeveRetornarErro()
    {
        var command = AtualizarClienteCommandBuilder.Instancia();

        var cliente = ClienteBuilder.Instancia();

        var requisicao = command with { Id = 100 };

        var useCase = CriarUseCase(cliente);

        Func<Task> acao = async () => await useCase.Handle(requisicao, default);

        var resultado = await acao.Should().ThrowAsync<Exception>();

        resultado.Where(ex => ex.Message.Contains(ClienteMensagensDeErro.CLIENTE_NAO_ENCONTRADO));
    }

    private static AtualizarClienteCommandHandler CriarUseCase(SistemaCliente.Domain.Entidades.Cliente cliente, string? nomeEmpresa = null)
    {
        var repositorioUpdate = new ClienteUpdateOnlyRepositorioBuilder().RecuperarPorId(cliente).Instancia();
        var repositorioRead = new ClienteReadOnlyRepositorioBuilder();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia();

        if (string.IsNullOrWhiteSpace(nomeEmpresa) == false)
            repositorioRead.RecuperarClienteExistente(nomeEmpresa);

        return new AtualizarClienteCommandHandler(repositorioUpdate, repositorioRead.Instancia(), unidadeDeTrabalho);
    }
}
