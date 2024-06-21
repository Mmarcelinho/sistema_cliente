namespace SistemaCliente.Infrastructure.AcessoRepositorio;

public class SistemaClienteContext : DbContext
{
    public SistemaClienteContext(DbContextOptions<SistemaClienteContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaClienteContext).Assembly);
    
}
