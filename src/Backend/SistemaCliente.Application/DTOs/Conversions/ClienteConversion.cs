using SistemaCliente.Domain.Entidades;

namespace SistemaCliente.Application.DTOs.Conversions;

public static class ClienteConversion
{
    public static Cliente Atualizar(this Cliente cliente, RequisicaoClienteJson requisicaoCliente)
    {
        cliente.NomeEmpresa = requisicaoCliente.NomeEmpresa;
        cliente.Porte = (Domain.Enum.Porte)requisicaoCliente.Porte;

        return cliente;
    }

    public static Cliente ToEntity(RequisicaoClienteJson cliente) => new()
    {
        NomeEmpresa = cliente.NomeEmpresa,
        Porte = (Domain.Enum.Porte)cliente.Porte
    };

    public static RespostaClienteJson FromEntity(Cliente cliente)
    {
        return new RespostaClienteJson(
            cliente.Id,
            cliente.NomeEmpresa,
            (Enum.Porte)cliente.Porte,
            cliente.DataCriacao
        );
    }

    public static IEnumerable<RespostaClienteJson> FromEntities(IEnumerable<Cliente> clientes)
    {
        return clientes.Select(c =>
            new RespostaClienteJson(
                c.Id,
                c.NomeEmpresa,
                (Enum.Porte)c.Porte,
                c.DataCriacao
            )
        ).ToList();
    }
}
