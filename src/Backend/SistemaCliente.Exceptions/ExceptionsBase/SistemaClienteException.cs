namespace SistemaCliente.Exceptions.ExceptionsBase;

public abstract class SistemaClienteException(string mensagem) : SystemException(mensagem)
{
    public abstract int StatusCode { get; }

    public abstract List<string> RecuperarErros();
}
