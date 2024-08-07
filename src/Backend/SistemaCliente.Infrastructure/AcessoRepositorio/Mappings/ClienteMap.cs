namespace SistemaCliente.Infrastructure.AcessoRepositorio.Mappings;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.NomeEmpresa)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Porte)
            .IsRequired().
            HasConversion<string>();
    }
}
