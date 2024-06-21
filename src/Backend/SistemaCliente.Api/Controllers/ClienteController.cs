using SistemaCliente.Application.UseCases.Cliente.Deletar;

namespace SistemaCliente.Api.Controllers;

public class ClienteController : SistemaClienteController
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(typeof(RespostaClienteJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RecuperarTodos()
    {
        var resposta = await _mediator.Send(new RecuperarTodosClientesQuery());

        return Ok(resposta);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(RespostaClienteJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RecuperarPorId([FromRoute] long id)
    {
        var resposta = await _mediator.Send(new RecuperarClientePorIdQuery(id));

        return Ok(resposta);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RespostaClienteJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarCliente([FromBody] RegistrarClienteCommand requisicao)
    {
        var resposta = await _mediator.Send(requisicao);

        return Created(string.Empty, resposta);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RegistrarCliente([FromRoute] long id)
    {
        var command = new DeletarClienteCommand(id);
        await _mediator.Send(command);

        return NoContent();
    }
}
