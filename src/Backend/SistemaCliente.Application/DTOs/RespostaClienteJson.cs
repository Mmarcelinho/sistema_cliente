using SistemaCliente.Application.DTOs.Enum;

namespace SistemaCliente.Application.DTOs;

public record RespostaClienteJson(long Id, string NomeEmpresa, Porte Porte, DateTime DataCriacao);