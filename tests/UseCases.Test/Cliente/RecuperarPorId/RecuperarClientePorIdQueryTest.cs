namespace UseCases.Test.Cliente.RecuperarPorId;

public class RecuperarClientePorIdQueryTest
{
    [Fact]
    public async Task Sucesso()
    {
        var cliente = ClienteBuilder.Instancia();

        var query = new RecuperarClientePorIdQuery(cliente.Id);

        var useCase = CriarUseCase(cliente);

        var resultado = await useCase.Handle(query, default);

        resultado.Should().NotBeNull();
        resultado.Id.Should().Be(cliente.Id);
        resultado.NomeEmpresa.Should().Be(cliente.NomeEmpresa);
    }

    [Fact]
    public async Task ClienteNaoEncontrado_DeveRetornarErro()
    {
        var cliente = ClienteBuilder.Instancia();

        var query = new RecuperarClientePorIdQuery(100);

        var useCase = CriarUseCase(cliente);

        var acao = async () => await useCase.Handle(query, default);

        await acao.Should().ThrowAsync<Exception>()
       .Where(exception => exception.Message.Contains(ClienteErrorsConstants.CLIENTE_NAO_ENCONTRADO));
    }

    private static RecuperarClientePorIdQueryHandler CriarUseCase(SistemaCliente.Domain.Entidades.Cliente cliente)
    {
        var repositorio = new ClienteReadOnlyRepositorioBuilder().RecuperarPorId(cliente).Instancia();
        return new RecuperarClientePorIdQueryHandler(repositorio);
    }
}
