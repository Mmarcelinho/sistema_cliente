namespace CommonTestUtilities.Repositorios;

public class ClienteReadOnlyRepositorioBuilder
{
    private readonly Mock<IClienteReadOnlyRepositorio> _repositorio;

    public ClienteReadOnlyRepositorioBuilder() => _repositorio = new Mock<IClienteReadOnlyRepositorio>();

    public ClienteReadOnlyRepositorioBuilder RecuperarTodos(List<Cliente> clientes)
    {
        _repositorio.Setup(repositorio => repositorio.RecuperarTodos()).ReturnsAsync(clientes);

        return this;
    }

    public ClienteReadOnlyRepositorioBuilder RecuperarPorId(Cliente cliente)
    {
        _repositorio.Setup(repositorio => repositorio.RecuperarPorId(cliente.Id)).ReturnsAsync(cliente);

        return this;
    }

    public IClienteReadOnlyRepositorio Build() => _repositorio.Object;
}
