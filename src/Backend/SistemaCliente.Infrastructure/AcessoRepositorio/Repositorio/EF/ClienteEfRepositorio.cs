namespace SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio.EF;

public class ClienteEfRepositorio(SistemaClienteContext contexto) : IClienteWriteOnlyRepositorio, IClienteUpdateOnlyRepositorio
{
    public async Task Registrar(Cliente cliente)
    {
        var recuperarCliente = await RecuperarPor(_ => _.NomeEmpresa!.Equals(cliente.NomeEmpresa));

        if (recuperarCliente is not null && !string.IsNullOrEmpty(recuperarCliente.NomeEmpresa))
            throw new Exception(ClienteErrorsConstants.CLIENTE_JA_REGISTRADO);

        await contexto.Clientes.AddAsync(cliente);
    }

    public void Atualizar(Cliente cliente) => contexto.Clientes.Update(cliente);

    async Task<Cliente> IClienteUpdateOnlyRepositorio.RecuperarPorId(long clienteId) => await contexto.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == clienteId);

    public async Task Deletar(long id)
    {
        var cliente = await contexto.Clientes.FindAsync(id);

        contexto.Clientes.Remove(cliente!);
    }

    public async Task<Cliente> RecuperarPor(Expression<Func<Cliente, bool>> predicate)
    {
        var cliente = await contexto.Clientes.Where(predicate).FirstOrDefaultAsync()!;

        return cliente is not null ? cliente : null!;
    }
}
