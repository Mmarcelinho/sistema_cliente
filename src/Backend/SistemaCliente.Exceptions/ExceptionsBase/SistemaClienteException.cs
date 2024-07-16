namespace SistemaCliente.Exceptions.ExceptionsBase;

public abstract class SistemaClienteException : SystemException
{
    protected SistemaClienteException(string mensagem) : base(mensagem) { }

    public abstract int StatusCode { get; }

    public abstract List<string> RecuperarErros();
}
