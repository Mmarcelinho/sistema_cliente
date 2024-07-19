namespace CommonTestUtilities.Repositorios;

    public class ClienteWriteOnlyRepositorioBuilder
    {
        public static IClienteWriteOnlyRepositorio Instancia()
        {
            var mock = new Mock<IClienteWriteOnlyRepositorio>();

            return mock.Object;
        }
    }
