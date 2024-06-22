namespace SistemaCliente.Domain.Repositorios.Cliente;

public interface IClienteWriteOnlyRepositorio
{
    Task Registrar(Entidades.Cliente cliente);

    Task<bool> Deletar(long id);

    Task<bool> ExisteClienteComEmpresa(string nomeEmpresa);
}
