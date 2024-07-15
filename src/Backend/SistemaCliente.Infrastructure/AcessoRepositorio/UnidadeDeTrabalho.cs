namespace SistemaCliente.Infrastructure.AcessoRepositorio;

public class UnidadeDeTrabalho : IUnidadeDeTrabalho
{
    private readonly SistemaClienteContext _contexto;

    public UnidadeDeTrabalho(SistemaClienteContext contexto) =>
    _contexto = contexto;

    public async Task Commit() => await _contexto.SaveChangesAsync();
}
