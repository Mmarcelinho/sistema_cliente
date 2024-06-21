using SistemaCliente.Communication.Enums;

namespace SistemaCliente.Communication.Respostas.Cliente;

public record RespostaClienteJson(long Id, string NomeEmpresa, Porte Porte, DateTime DataCriacao);