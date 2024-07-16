namespace CommonTestUtilities.Commands;

public class RegistrarClienteCommandBuilder
{
    public static RegistrarClienteCommand Build()
    {
        var faker = new Faker();

        return new RegistrarClienteCommand(
            new RequisicaoClienteJson(
            faker.Company.CompanyName(),
            (SistemaCliente.Communication.Enums.Porte)faker.Random.Int(0, 2)
        )
        );
    }
}
