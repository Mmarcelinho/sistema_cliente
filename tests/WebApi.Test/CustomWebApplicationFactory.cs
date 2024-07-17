namespace WebApi.Test;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public Cliente Cliente { get; private set; } = default!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        _ = builder.UseEnvironment("Test")
        .ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<SistemaClienteContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<SistemaClienteContext>(options =>
            {
                options.UseSqlite("Data Source=InMemory;Mode=Memory;Cache=Shared");
            });

            var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SistemaClienteContext>();
            dbContext.Database.OpenConnection();
            dbContext.Database.EnsureCreated();
            dbContext.SaveChanges();
        });
    }
}
