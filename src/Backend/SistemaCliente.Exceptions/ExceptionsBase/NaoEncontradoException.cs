using System.Net;

namespace SistemaCliente.Exceptions.ExceptionsBase;

public class NaoEncontradoException : SistemaClienteException
{
    public NaoEncontradoException(string mensagem) : base(mensagem)
    { }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> RecuperarErros()
    => [Message];
}
