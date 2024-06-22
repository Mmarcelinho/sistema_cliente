var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(option => option.LowercaseUrls = true);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SISTEMA DE CLIENTE API", Version = "1.0" });
});

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AdicionarInfrastructure(builder.Configuration);
builder.Services.AdicionarApplication();

builder.Services.AddHealthChecks().AddDbContextCheck<SistemaClienteContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/Health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
    }
});

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

await AtualizarBaseDeDados();

app.Run();

async Task AtualizarBaseDeDados()
{
    await using var scope = app.Services.CreateAsyncScope();

    await MigrateExtension.MigrateBancoDeDados(scope.ServiceProvider);
}
