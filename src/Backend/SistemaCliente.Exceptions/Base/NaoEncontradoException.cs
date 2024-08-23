using System.Net;

namespace SistemaCliente.Exceptions.Base;

public class NaoEncontradoException : SistemaClienteException
{
    public NaoEncontradoException(string mensagem) : base(mensagem) { }
    
    public override IList<string> RecuperarMensagensDeErro() => [Message];

    public override HttpStatusCode RecuperarStatusCode() => HttpStatusCode.NotFound;
}
