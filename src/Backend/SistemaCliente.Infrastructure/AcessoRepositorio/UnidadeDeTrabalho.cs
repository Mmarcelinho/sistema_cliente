namespace SistemaCliente.Infrastructure.AcessoRepositorio;

public class UnidadeDeTrabalho : IDisposable, IUnidadeDeTrabalho
{
    private readonly SistemaClienteContext _contexto;

    private bool _disposed;

    public UnidadeDeTrabalho(SistemaClienteContext contexto) =>
    _contexto = contexto;

    public async Task Commit() => await _contexto.SaveChangesAsync();

    public void Dispose() => Dispose(true);

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
            _contexto.Dispose();

        _disposed = true;
    }
}
