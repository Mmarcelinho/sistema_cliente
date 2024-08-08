namespace SistemaCliente.Domain.Repositorios.Cliente;

public interface IClienteReadOnlyRepositorio
{
    Task<IEnumerable<Entidades.Cliente>> RecuperarTodos();

    Task<Entidades.Cliente> RecuperarPorId(long clienteId);
}
