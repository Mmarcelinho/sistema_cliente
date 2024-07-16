namespace SistemaCliente.Domain.Repositorios.Cliente;

public interface IClienteWriteOnlyRepositorio
{
    Task Registrar(Entidades.Cliente cliente);

    Task Deletar(long id);
}
