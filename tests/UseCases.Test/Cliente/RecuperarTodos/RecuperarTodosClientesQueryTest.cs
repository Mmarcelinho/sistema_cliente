namespace UseCases.Test.Cliente.RecuperarTodos;

public class RecuperarTodosClientesQueryTest
{
    [Fact]
    public async Task Sucesso()
    {
        var query = new RecuperarTodosClientesQuery();

        var clientes = ClienteBuilder.Colecao();

        var useCase = CriarUseCase(clientes);

        var resultado = await useCase.Handle(query, default);

        resultado.Should().NotBeNull();
    }

    private static RecuperarTodosClientesQueryHandler CriarUseCase(List<SistemaCliente.Domain.Entidades.Cliente> clientes)
    {
        var repositorio = new ClienteReadOnlyRepositorioBuilder().RecuperarTodos(clientes).Build();
        return new RecuperarTodosClientesQueryHandler(repositorio);
    }
}
