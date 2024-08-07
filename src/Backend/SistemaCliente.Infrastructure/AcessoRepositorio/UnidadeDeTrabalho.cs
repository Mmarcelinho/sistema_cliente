namespace SistemaCliente.Infrastructure.AcessoRepositorio;

public class UnidadeDeTrabalho(SistemaClienteContext contexto) : IUnidadeDeTrabalho
{
    public async Task Commit() => await contexto.SaveChangesAsync();
}
