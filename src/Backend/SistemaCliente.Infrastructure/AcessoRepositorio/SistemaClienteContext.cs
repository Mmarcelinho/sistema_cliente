namespace SistemaCliente.Infrastructure.AcessoRepositorio;

public class SistemaClienteContext(DbContextOptions<SistemaClienteContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaClienteContext).Assembly);
    
}
