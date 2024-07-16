namespace CommonTestUtilities.Repositorios;

    public class ClienteWriteOnlyRepositorioBuilder
    {
        public static IClienteWriteOnlyRepositorio Build()
        {
            var mock = new Mock<IClienteWriteOnlyRepositorio>();

            return mock.Object;
        }
    }
