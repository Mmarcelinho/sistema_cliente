namespace SistemaCliente.Api.Controllers;

public class ClienteController : SistemaClienteController
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(RespostaClienteJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarCliente([FromBody] RegistrarClienteCommand requisicao)
    {
        var resposta = await _mediator.Send(requisicao);

        return Created(string.Empty, resposta);
    }
}
