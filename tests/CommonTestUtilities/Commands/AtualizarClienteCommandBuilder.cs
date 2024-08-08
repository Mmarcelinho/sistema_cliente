namespace CommonTestUtilities.Commands;

public class AtualizarClienteCommandBuilder
{
    public static AtualizarClienteCommand Instancia()
    {
        var faker = new Faker();

        return new AtualizarClienteCommand(
            1,
            new RequisicaoClienteJson(
            faker.Company.CompanyName(),
            (SistemaCliente.Application.DTOs.Enum.Porte)faker.Random.Int(0, 2)
        )
        );
    }
}
