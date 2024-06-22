namespace SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio.EF;

public class ClienteEfRepositorio : IClienteWriteOnlyRepositorio, IClienteUpdateOnlyRepositorio
{
    private readonly SistemaClienteContext _contexto;

    public ClienteEfRepositorio(SistemaClienteContext contexto) => _contexto = contexto;

    public async Task Registrar(Cliente cliente) => await _contexto.Clientes.AddAsync(cliente);

    public void Atualizar(Cliente cliente) => _contexto.Clientes.Update(cliente);

    async Task<Cliente> IClienteUpdateOnlyRepositorio.RecuperarPorId(long clienteId) => await _contexto.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == clienteId);

    public async Task<bool> Deletar(long id)
    {
        var cliente = await _contexto.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);

        if (cliente is null)
            return false;

        _contexto.Clientes.Remove(cliente);
        return true;
    }

    public async Task<bool> ExisteClienteComEmpresa(string nomeEmpresa) => await _contexto.Clientes.AnyAsync(cliente => cliente.NomeEmpresa.Equals(nomeEmpresa));
}
