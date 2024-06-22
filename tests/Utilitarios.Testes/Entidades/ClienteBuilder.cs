namespace Utilitarios.Testes.Entidades;

    public class ClienteBuilder
    {
        public static Cliente Build()
        {
            return new Faker<Cliente>()
            .RuleFor(c => c.Id, _ => 1)
            .RuleFor(c => c.NomeEmpresa, faker => faker.Company.CompanyName())
            .RuleFor(c => (int)c.Porte, faker => faker.Random.Int(0,2));
        }
    }
