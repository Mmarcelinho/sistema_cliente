namespace CommonTestUtilities.Requisicoes;

    public class RequisicaoClienteJsonBuilder
    {
        public static RequisicaoClienteJson Instancia()
        {
            var faker = new Faker();

            return new RequisicaoClienteJson(
                faker.Company.CompanyName(),
                (SistemaCliente.Communication.Enums.Porte)faker.Random.Int(0,2)
            );
        }
    }
