using System.Net;

namespace SistemaCliente.Exceptions.Base;

    public class ClienteJaRegistradoException : SistemaClienteException
{
    public ClienteJaRegistradoException(string mensagem) : base(mensagem) { }
    
    public override IList<string> RecuperarMensagensDeErro() => [Message];

    public override HttpStatusCode RecuperarStatusCode() => HttpStatusCode.BadRequest;
}
