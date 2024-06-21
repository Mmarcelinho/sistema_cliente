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

        builder.HasData(
            new Cliente
            {
                Id = 1,
                NomeEmpresa = "Empresa Pequena Ltda",
                Porte = Domain.Enum.Porte.PEQUENA
            },
            new Cliente
            {
                Id = 2,
                NomeEmpresa = "Empresa Media S.A.",
                Porte = Domain.Enum.Porte.MEDIA
            },
            new Cliente
            {
                Id = 3,
                NomeEmpresa = "Empresa Grande Corp.",
                Porte = Domain.Enum.Porte.GRANDE
            }
        );
    }
}
