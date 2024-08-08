namespace SistemaCliente.Domain.ValueObjects;

public abstract class ClienteErrorsConstants
{
    public const string EMPRESA_CLIENTE_NOME_EM_BRANCO = "O nome da empresa do cliente deve ser informado.";

    public const string EMPRESA_CLIENTE_PORTE_INVALIDO = "O porte da empresa do cliente é inválido.";

    public const string CLIENTE_NAO_ENCONTRADO = "Cliente não encontrado.";

    public const string CLIENTE_JA_REGISTRADO = "O cliente informado já está registrado na base de dados.";
}
