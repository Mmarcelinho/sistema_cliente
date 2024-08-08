namespace CommonTestUtilities.Commands;

public class RegistrarClienteCommandBuilder
{
    public static RegistrarClienteCommand Instancia()
    {
        var faker = new Faker();

        return new RegistrarClienteCommand(
            new RequisicaoClienteJson(
            faker.Company.CompanyName(),
            (SistemaCliente.Application.DTOs.Enum.Porte)faker.Random.Int(0, 2)
        )
        );
    }
}
