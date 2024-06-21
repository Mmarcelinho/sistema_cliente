namespace SistemaCliente.Application.UseCases.Cliente.RecuperarTodos;

public class RecuperarTodosClientesQuery : IRequest<IEnumerable<RespostaClienteJson>>
{
    public class RecuperarTodosClientesQueryHandler : IRequestHandler<RecuperarTodosClientesQuery, IEnumerable<RespostaClienteJson>>
    {
        private readonly IClienteReadOnlyRepositorio _repositorio;

        public RecuperarTodosClientesQueryHandler(IClienteReadOnlyRepositorio repositorio) => _repositorio = repositorio;

        public async Task<IEnumerable<RespostaClienteJson>> Handle(RecuperarTodosClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _repositorio.RecuperarTodos();

            var resultado = clientes.Select(c => new RespostaClienteJson(c.Id, c.NomeEmpresa, (Communication.Enums.Porte)c.Porte, c.DataCriacao)).ToList();

            return resultado;
        }
    }
}
