namespace WebApi.Test.V1.Registrar;

public class RegistrarClienteTest : SistemaDeClienteClassFixture
{
    private const string METODO = "cliente";

    public RegistrarClienteTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
    }

    [Fact]
    public async Task Sucesso()
    {
        var command = RequisicaoClienteJsonBuilder.Build();

        var resultado = await DoPost(requestUri: METODO, request: command);

        resultado.StatusCode.Should().Be(HttpStatusCode.Created);

        var body = await resultado.Content.ReadAsStreamAsync();

        var resposta = await JsonDocument.ParseAsync(body);

        resposta.RootElement.GetProperty("nomeEmpresa").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Erro_NomeEmpresa_EmBranco()
    {
        var requisicao = RequisicaoClienteJsonBuilder.Build();
        var command = requisicao with { NomeEmpresa = string.Empty };

        var resultado = await DoPost(requestUri: METODO, request: command);

        resultado.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var body = await resultado.Content.ReadAsStreamAsync();

        var resposta = await JsonDocument.ParseAsync(body);

        var erros = resposta.RootElement.GetProperty("errors").EnumerateArray();

        var mensagemEsperada = ClienteMensagensDeErro.EMPRESA_CLIENTE_NOME_EM_BRANCO;

        erros.Should().Contain(erro => erro.GetString()!.Equals(mensagemEsperada));
    }
}
