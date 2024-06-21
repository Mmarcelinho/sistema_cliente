namespace SistemaCliente.Domain.Repositorios.Cliente;

public interface IClienteUpdateOnlyRepositorio
{
    void Atualizar(Entidades.Cliente cliente);

    Task<Entidades.Cliente> RecuperarPorId(long clienteId);
}
