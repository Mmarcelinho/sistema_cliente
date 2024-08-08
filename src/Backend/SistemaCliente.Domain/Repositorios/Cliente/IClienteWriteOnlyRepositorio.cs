using System.Linq.Expressions;

namespace SistemaCliente.Domain.Repositorios.Cliente;

public interface IClienteWriteOnlyRepositorio
{
    Task<Entidades.Cliente> RecuperarPor(Expression<Func<Entidades.Cliente, bool>> predicate);
    
    Task Registrar(Entidades.Cliente cliente);

    Task Deletar(long id);
}
