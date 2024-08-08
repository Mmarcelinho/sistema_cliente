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

        cliente.NomeEmpresa.Should().Be(requisicao.RequisicaoCliente.NomeEmpresa);
        cliente.Porte.Should().Be((SistemaCliente.Domain.Enum.Porte)requisicao.RequisicaoCliente.Porte);
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

        resultado.Where(ex => ex.Message.Contains(ClienteErrorsConstants.CLIENTE_NAO_ENCONTRADO));
    }

    private static AtualizarClienteCommandHandler CriarUseCase(SistemaCliente.Domain.Entidades.Cliente cliente)
    {
        var repositorioUpdate = new ClienteUpdateOnlyRepositorioBuilder().RecuperarPorId(cliente).Instancia();
        var unidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia();

        return new AtualizarClienteCommandHandler(repositorioUpdate, unidadeDeTrabalho);
    }
}
