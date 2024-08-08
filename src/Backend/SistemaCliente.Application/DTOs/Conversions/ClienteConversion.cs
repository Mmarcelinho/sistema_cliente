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

    public static (RespostaClienteJson?, IEnumerable<RespostaClienteJson>?) FromEntity(Cliente cliente, IEnumerable<Cliente>? clientes)
    {
        if (cliente is not null || clientes is null)
        {
            var _cliente = new RespostaClienteJson(
                cliente!.Id,
                cliente.NomeEmpresa,
                (Enum.Porte)cliente.Porte,
                cliente.DataCriacao
            );

            return (_cliente, null);
        }

        if (clientes is not null || cliente is null)
        {
            var _clientes = clientes!.Select(c =>
            new RespostaClienteJson
            (
                c!.Id,
                c.NomeEmpresa,
                (Enum.Porte)c.Porte,
                c.DataCriacao
            )).ToList();

            return (null, _clientes);
        }

        return (null, null);
    }
}
