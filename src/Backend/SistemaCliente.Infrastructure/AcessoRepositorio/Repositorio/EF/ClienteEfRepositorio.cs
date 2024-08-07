namespace SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio.EF;

public class ClienteEfRepositorio(SistemaClienteContext contexto) : IClienteWriteOnlyRepositorio, IClienteUpdateOnlyRepositorio
{
    public async Task Registrar(Cliente cliente) => await contexto.Clientes.AddAsync(cliente);

    public void Atualizar(Cliente cliente) => contexto.Clientes.Update(cliente);

    async Task<Cliente> IClienteUpdateOnlyRepositorio.RecuperarPorId(long clienteId) => await contexto.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == clienteId);

    public async Task Deletar(long id)
    {
        var cliente = await contexto.Clientes.FindAsync(id);

        contexto.Clientes.Remove(cliente!);
    }
}
