namespace SistemaCliente.Api.Controllers;

public class ClienteController(IMediator mediator) : SistemaClienteController
{
    [HttpGet]
    [ProducesResponseType(typeof(RespostaClienteJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RecuperarTodos()
    {
        var resposta = await mediator.Send(new RecuperarTodosClientesQuery());

        return !resposta.Any()? NotFound() : Ok(resposta);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(RespostaClienteJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RecuperarPorId([FromRoute] long id)
    {
        if(id <= 0) return BadRequest();

        var resposta = await mediator.Send(new RecuperarClientePorIdQuery(id));

        return resposta is null? NotFound() : Ok(resposta);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RespostaClienteJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Registrar([FromBody] RequisicaoClienteJson requisicao)
    {
        var command = new RegistrarClienteCommand(requisicao);
        var resposta = await mediator.Send(command);

        return Created(string.Empty, resposta);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Atualizar([FromRoute] long id, [FromBody] RequisicaoClienteJson requisicao)
    {
        var command = new AtualizarClienteCommand(id, requisicao);
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Deletar([FromRoute] long id)
    {
        var command = new DeletarClienteCommand(id);
        await mediator.Send(command);

        return NoContent();
    }
}
