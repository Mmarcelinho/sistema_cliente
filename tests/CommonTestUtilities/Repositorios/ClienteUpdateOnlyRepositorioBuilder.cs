namespace CommonTestUtilities.Repositorios;

public class ClienteUpdateOnlyRepositorioBuilder
{
    private readonly Mock<IClienteUpdateOnlyRepositorio> _repositorio;

    public ClienteUpdateOnlyRepositorioBuilder() => _repositorio = new Mock<IClienteUpdateOnlyRepositorio>();

    public ClienteUpdateOnlyRepositorioBuilder RecuperarPorId(Cliente cliente)
    {
        if (cliente is not null)
            _repositorio.Setup(repositorio => repositorio.RecuperarPorId(cliente.Id)).ReturnsAsync(cliente);

        return this;
    }

    public IClienteUpdateOnlyRepositorio Build() => _repositorio.Object;
}
