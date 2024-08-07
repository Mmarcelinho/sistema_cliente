using System.Net;

namespace SistemaCliente.Exceptions.ExceptionsBase;

public class NaoEncontradoException(string mensagem) : SistemaClienteException(mensagem)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> RecuperarErros()
    => [Message];
}
