using System.Net;

namespace SistemaCliente.Exceptions.Base;

public abstract class SistemaClienteException : SystemException
{
    protected SistemaClienteException(string mensagem) : base(mensagem) { }

    public abstract IList<string> RecuperarMensagensDeErro();
    public abstract HttpStatusCode RecuperarStatusCode();
}
