namespace CommonTestUtilities.Entidades;

public class ClienteBuilder
{
    public static List<Cliente> Colecao(uint count = 2)
    {
        var listaClientes = new List<Cliente>();

        if (count == 0)
            count = 1;

        for (int i = 0; i < count; i++)
        {
            var cliente = Instancia();

            listaClientes.Add(cliente);
        }
        return listaClientes;
    }

    public static Cliente Instancia()
    {
        return new Faker<Cliente>()
        .RuleFor(c => c.Id, faker => faker.UniqueIndex + 1) 
        .RuleFor(c => c.NomeEmpresa, faker => faker.Company.CompanyName())
        .RuleFor(c => (int)c.Porte, faker => faker.Random.Int(0, 2));
    }

    public static Cliente InstanciaSemId()
    {
        return new Faker<Cliente>()
        .RuleFor(c => c.NomeEmpresa, faker => faker.Company.CompanyName())
        .RuleFor(c => (int)c.Porte, faker => faker.Random.Int(0, 2));
    }
}
